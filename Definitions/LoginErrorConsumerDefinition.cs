using MassTransit;
using Test.Consumer.Consumers;

namespace Test.Consumer.Definitions;

public class LoginErrorConsumerDefinition : ConsumerDefinition<LoginErrorConsumer>
{
    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<LoginErrorConsumer> consumerConfigurator,
        IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;
        endpointConfigurator.ClearSerialization();
        endpointConfigurator.UseRawJsonSerializer();

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rabbit) 
        {
            rabbit.Bind("amq.topic", ex =>
            {
                ex.ExchangeType = "topic";
                ex.RoutingKey = "KK.EVENT.CLIENT.ea5c79b5-e883-44e8-8259-af8c05d01e62.ERROR.*.LOGIN_ERROR";
            });
        }
    }
}