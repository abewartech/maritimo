use amiquip::{
    Connection, ConsumerMessage, ConsumerOptions, ExchangeDeclareOptions, ExchangeType, Publish,
    QueueDeclareOptions, Result,
};
use decoder::error::IncorrectEnvironmentVariableValueError;
use decoder::error::MissingEnvironmentVariableError;
use env_logger::Builder;
use log::{debug, error, info, warn, LevelFilter};
use std::collections::HashMap;
use std::env;
use std::error::Error;

fn main() -> Result<(), Box<dyn Error>> {
    let rabbitmq_uri = "amqp://guest:guest@localhost:5672";
    let incoming_queue = "encoded_messages";
    let outgoing_exchange = "decoded_messages";
    let loglevel = "INFORMATION";

    let level_filter = match loglevel.to_uppercase().as_str() {
        "TRACE" => LevelFilter::Trace,
        "DEBUG" => LevelFilter::Debug,
        "INFORMATION" => LevelFilter::Info,
        "WARNING" => LevelFilter::Warn,
        "ERROR" => LevelFilter::Error,
        "CRITICAL" => LevelFilter::Error,
        "NONE" => LevelFilter::Off,
        _ => {
            return Err(IncorrectEnvironmentVariableValueError {
                message: format!(
                    "Minimum log level specified not a valid value (currently set to '{}'). Set log level to one of the following values: Trace, Debug, Information, Warning, Error, Critical, None.",
                    loglevel
                )
                .to_string(),
            }
            .into());
        }
    };

    Builder::new().filter_level(level_filter).init();

    let mut incoming_connection = Connection::insecure_open(rabbitmq_uri)?;

    let incoming_channel = incoming_connection.open_channel(None)?;

    let queue = incoming_channel.queue_declare(
        incoming_queue,
        QueueDeclareOptions {
            durable: false,
            ..QueueDeclareOptions::default()
        },
    )?;

    incoming_channel.qos(0, 1, false)?;

    let consumer = queue.consume(ConsumerOptions::default())?;

    let mut outgoing_connection = Connection::insecure_open(rabbitmq_uri)?;

    let outgoing_channel = outgoing_connection.open_channel(None)?;

    let outgoing_exchange = outgoing_channel.exchange_declare(
        ExchangeType::Fanout,
        outgoing_exchange,
        ExchangeDeclareOptions::default(),
    )?;

    let mut acc = HashMap::new();

    info!("Connected to {}", rabbitmq_uri);

    for (_, message) in consumer.receiver().iter().enumerate() {
        match message {
            ConsumerMessage::Delivery(delivery) => {
                let delivery_body = delivery.body.to_vec();
                let body_string = String::from_utf8_lossy(&delivery_body);
                let sentences = body_string.split('\n').collect::<Vec<&str>>();

                consumer.ack(delivery)?;

                for (_, sentence) in sentences
                    .iter()
                    .map(|x| x.trim())
                    .filter(|x| x.len() > 0)
                    .enumerate()
                {
                    debug!("{}", sentence);

                    match decoder::decode(&sentence, &mut acc, &incoming_queue) {
                        Ok(opt) => match opt {
                            Some(value) => match serde_json::to_string(&value) {
                                Ok(json) => {
                                    outgoing_exchange.publish(Publish::new(json.as_bytes(), ""))?;
                                    debug!("Sent {:?}", json);
                                }
                                Err(e) => error!("{:?}", e),
                            },
                            _ => (),
                        },
                        Err(e) => error!("{:?}", e),
                    }
                }
            }
            other => {
                warn!("Consumer ended: {:?}", other);
                break;
            }
        }
    }

    incoming_connection.close()?;
    outgoing_connection.close()?;

    Ok(())
}
