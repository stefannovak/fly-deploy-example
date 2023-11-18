using MassTransit;
using Test.Consumer.Consumers;
using Test.Consumer.Definitions;

namespace Test.Consumer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<LoginErrorConsumer, LoginErrorConsumerDefinition>();

                    x.UsingRabbitMq((context, config) =>
                    {
                        config.Host(
                            Environment.GetEnvironmentVariable("HOST"),
                            Environment.GetEnvironmentVariable("VHOST"),
                            hostConfig =>
                            {
                                hostConfig.Username(Environment.GetEnvironmentVariable("USERNAME"));
                                hostConfig.Password(Environment.GetEnvironmentVariable("PASSWORD"));
                            });
                        
                        config.ConfigureEndpoints(context);
                    });
                });
            })
            .Build()
            .RunAsync();
    }   
}