using MassTransit;
using Test.Consumer.Models;

namespace Test.Consumer.Consumers;

public class LoginErrorConsumer : IConsumer<LoginError>
{
    private readonly ILogger<LoginErrorConsumer> _logger;

    public LoginErrorConsumer(ILogger<LoginErrorConsumer> logger)
    {
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<LoginError> context)
    {
        _logger.LogInformation($"Login Error: {context.Message.Details?.Username}");
    }
}