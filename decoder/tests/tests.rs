use std::collections::HashMap;

extern crate decoder;
use decoder::MessageData;
use decoder::error::NMEADecoderErrorType;

#[test]
fn decode_when_no_checksum_present_should_return_error() {
    let err = decoder::decode("!AIVDM,1,1,,B,177KQJ5000G?tO`K>RA1", &mut HashMap::new()).unwrap_err();

    assert_eq!(err.error_type, NMEADecoderErrorType::CheckSumNotPresent);
}

#[test]
fn decode_when_fields_are_missing_should_return_error() {
    let err = decoder::decode("!AIVDM,1,177KQJ5000G?tO`K>RA1wUbN0TKH,0*5C", &mut HashMap::new()).unwrap_err();

    assert_eq!(err.error_type, NMEADecoderErrorType::MissingFields);
}

#[test]
fn decode_when_fragment_count_field_is_of_incorrect_type_should_return_error() {
    assert_decode_when_field_is_of_incorrect_type_should_return_error("!AIVDM,invalid,1,,B,177KQJ5000G?tO`K>RA1wUbN0TKH,0*5C");
}

#[test]
fn decode_when_fragment_number_field_is_of_incorrect_type_should_return_error() {
    assert_decode_when_field_is_of_incorrect_type_should_return_error("!AIVDM,1,invalid,,B,177KQJ5000G?tO`K>RA1wUbN0TKH,0*5C");
}

#[test]
fn decode_when_fill_bits_field_is_of_incorrect_type_should_return_error() {
    assert_decode_when_field_is_of_incorrect_type_should_return_error("!AIVDM,1,1,,B,177KQJ5000G?tO`K>RA1wUbN0TKH,invalid*5C");
}

#[test]
fn decode_when_more_than_one_fragment_should_store_fragment_payload() {
    let mut h = HashMap::new();

    let result = decoder::decode("!AIVDM,2,1,3,B,55P5TL01VIaAL@7WKO@mBplU@<PDhh000000001S;AJ::4A80?4i@E53,0*3E", &mut h).unwrap();

    assert!(result.is_none());
    assert_eq!(h[&3].len(), 1);
    assert_eq!(h[&3][0], "55P5TL01VIaAL@7WKO@mBplU@<PDhh000000001S;AJ::4A80?4i@E53");
}

#[test]
fn decode_when_more_than_one_fragment_but_no_message_id_should_return_error() {
    let err = decoder::decode("!AIVDM,2,1,,B,55P5TL01VIaAL@7WKO@mBplU@<PDhh000000001S;AJ::4A80?4i@E53,0*3E", &mut HashMap::new()).unwrap_err();

    assert_eq!(err.error_type, NMEADecoderErrorType::MissingFields);
}

#[test]
fn decode_when_more_than_one_fragment_and_current_fragment_not_first_one_but_no_existing_key_for_message_id_should_return_error() {
    let err = decoder::decode("!AIVDM,2,2,3,B,55P5TL01VIaAL@7WKO@mBplU@<PDhh000000001S;AJ::4A80?4i@E53,0*3E", &mut HashMap::new()).unwrap_err();

    assert_eq!(err.error_type, NMEADecoderErrorType::PreviousFragmentsNotPresentForMessageId);
}

#[test]
fn decode_when_more_than_one_fragment_and_message_contains_last_fragment_should_clean_accumulator() {
    let mut h = HashMap::new();

    decoder::decode("!AIVDM,3,1,3,B,55P5TL01VIaAL@7WKO@mBplU@<PDhh000000001S;AJ::4A80?4i@E53,0*3E", &mut h).unwrap();
    assert_eq!(h[&3].len(), 1);
    decoder::decode("!AIVDM,3,2,3,B,55P5TL01VIaAL@7WKO@mBplU@<PDhh000000001S;AJ::4A80?4i@E53,0*3E", &mut h).unwrap();
    assert_eq!(h[&3].len(), 2);
    decoder::decode("!AIVDM,3,3,3,B,55P5TL01VIaAL@7WKO@mBplU@<PDhh000000001S;AJ::4A80?4i@E53,0*3E", &mut h).unwrap();
    assert_eq!(h.contains_key(&3), false);
}

#[test]
fn decode_should_decode_basic_message_info() {
    let message = decoder::decode("!AIVDM,1,1,,B,177KQJ5000G?tO`K>RA1wUbN0TKH,0*5C", &mut HashMap::new()).unwrap().unwrap();

    assert_eq!(message.message_type, 1);
    assert_eq!(message.repeat_indicator, 0);
    assert_eq!(message.mmsi, 477553000);
}

#[test]
fn decode_should_decode_position_report() {
    let message = decoder::decode("!AIVDM,1,1,,B,177KQJ5000G?tO`K>RA1wUbN0TKH,0*5C", &mut HashMap::new()).unwrap().unwrap();

    assert_eq!(message.message_type, 1);
    assert_eq!(message.repeat_indicator, 0);
    assert_eq!(message.mmsi, 477553000);
    
    match message.data {
        MessageData::PositionReport { 
            navigation_status, rate_of_turn, speed_over_ground,
            position_accuracy, longitude, latitude
        } => {
            assert_eq!(navigation_status, 5);
            assert_eq!(rate_of_turn, 0.0);
            assert_eq!(speed_over_ground, Some(0.0));
            assert_eq!(position_accuracy, false);
            assert!((-122.34584..-122.34583).contains(&longitude.unwrap()));
            assert_eq!(latitude, Some(47.5828333));
        },
        _ => panic!()
    };
}


#[test]
fn decode_should_decode_position_report2() {
    let message = decoder::decode("!AIVDM,1,1,,A,15RTgt0PAso;90TKcjM8h6g208CQ,0*4A", &mut HashMap::new()).unwrap().unwrap();

    assert_eq!(message.message_type, 1);
    assert_eq!(message.repeat_indicator, 0);
    assert_eq!(message.mmsi, 371798000);
    
    match message.data {
        MessageData::PositionReport { 
            navigation_status, rate_of_turn, speed_over_ground,
            position_accuracy, longitude, latitude
        } => {
            assert_eq!(navigation_status, 0);
            assert_eq!(rate_of_turn.round(), -720.0); 
            assert_eq!(speed_over_ground, Some(12.3));
            assert_eq!(position_accuracy, true);
            assert_eq!(longitude, Some(-123.3953833));
            assert_eq!(latitude, Some(48.3816333));
        },
        _ => panic!()
    };
}

#[test]
fn decode_should_decode_position_report3() {
    let message = decoder::decode("!AIVDM,1,1,,A,13u?etPv2;0n:dDPwUM1U1Cb069D,0*23", &mut HashMap::new()).unwrap().unwrap();

    assert_eq!(message.message_type, 1);
    assert_eq!(message.repeat_indicator, 0);
    assert_eq!(message.mmsi, 265547250);
    
    match message.data {
        MessageData::PositionReport { 
            navigation_status, rate_of_turn, speed_over_ground,
            position_accuracy, longitude, latitude
        } => {
            assert_eq!(navigation_status, 0);
            assert!((-2.9..-2.85).contains(&rate_of_turn));
            assert_eq!(speed_over_ground, Some(13.9));
            assert_eq!(position_accuracy, false);
            assert_eq!(longitude, Some(11.8329767));
            assert_eq!(latitude, Some(57.6603533));
        },
        _ => panic!()
    };
}

fn assert_decode_when_field_is_of_incorrect_type_should_return_error(input: &str) {
    let err = decoder::decode(input, &mut HashMap::new()).unwrap_err();

    assert_eq!(err.error_type, NMEADecoderErrorType::IncorrectFieldType);
}