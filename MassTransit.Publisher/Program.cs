using MassTransit.Contract;
using System;

namespace MassTransit.Publisher
{
    public class Program
    {
        static void Main()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            {
                config.Host("rabbitmq://localhost:5672/", hc =>
                {
                    hc.Username("guest");
                    hc.Password("guest");
                });
            });

            bus.Start();
            var rnd = new Random();
            var order = new OrderRegistered
            {
                OrderId = rnd.Next(1, 10),
                CustomerNumber = rnd.Next(10, 100).ToString(),
                OrderDate = DateTime.Now,
            };

            var (acceptResponse, rejectResponse) = bus.CreateRequestClient<OrderRegistered>()
                                                      .GetResponse<OrderAccepted, OrderRejected>(order).Result;
            if (acceptResponse.IsCompleted)
            {
                Console.WriteLine("accepted!");
                Console.WriteLine(acceptResponse.Result.Message);
            }
            else
            {
                Console.WriteLine("rejected!");
                Console.WriteLine(rejectResponse.Result.Message);
            }
            Console.ReadKey();

            bus.Stop();
        }
    }
}
