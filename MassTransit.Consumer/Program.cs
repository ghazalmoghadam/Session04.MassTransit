using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassTransit.Consumer
{
    public class Program
    {
        static async Task Main()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host("rabbitmq://localhost:5672/", hc =>
                {
                    hc.Username("guest");
                    hc.Password("guest");
                });

                config.ReceiveEndpoint("MyOrderConsumerQueueName", e =>
                {
                    e.Consumer<EvenOrderConsumer>();
                    //e.Consumer<OddOrderConsumer>();
                });
            });

            await busControl.StartAsync();
            try
            {

                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}
