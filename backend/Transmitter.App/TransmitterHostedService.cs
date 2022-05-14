using AutoMapper;
using Receiver.Lib;
using Microsoft.AspNetCore.SignalR;

namespace Transmitter.App;

public class TransmitterHostedService : IHostedService
{
    readonly ILogger<TransmitterHostedService> logger;
    readonly IHubContext<AisHub, IAisHub> aisHubContext;
    readonly IReceiver receiver;
    readonly IMapper mapper;

    public TransmitterHostedService(ILogger<TransmitterHostedService> logger, IHubContext<AisHub, IAisHub> aisHubContext, IReceiver receiver, IMapper mapper)
    {
        this.logger = logger;
        this.aisHubContext = aisHubContext;
        this.receiver = receiver;
        this.mapper = mapper;
    }

    async void HandleReceivedEvent(object? sender, DecodedMessage decodedMessage)
    {
        await aisHubContext.Clients.All.Receive(mapper.Map<DTOObjectData>(decodedMessage));
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        receiver.Received += HandleReceivedEvent;

        Task.Run(() => receiver.Run(stoppingToken));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        receiver.Received -= HandleReceivedEvent;

        return Task.CompletedTask;
    }
}