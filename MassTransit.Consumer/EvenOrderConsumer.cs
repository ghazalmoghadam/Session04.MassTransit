using MassTransit.Contract;
using System;
using System.Threading.Tasks;

namespace MassTransit.Consumer
{
    public class EvenOrderConsumer : IConsumer<OrderRegistered>
    {
        public async Task Consume(ConsumeContext<OrderRegistered> context)
        {
            System.Threading.Thread.Sleep(10);

            if (context.Message.OrderId % 2 != 0)
            {
                var orderRejectedMessage = new OrderRejected
                {
                    RejectBy = "EvenConsumer",
                    Reason = "i don't like odd request",
                    RejectDate = DateTime.Now,
                    OrderId = context.Message.OrderId

                };

                await context.RespondAsync(orderRejectedMessage);
            }
            else
            {
                var orderAcceptedMessage = new OrderAccepted
                {
                    AcceptBy = "OddConsumer",
                    AcceptDate = DateTime.Now,
                    OrderId = context.Message.OrderId

                };

                await context.RespondAsync(orderAcceptedMessage);
            }
        }
    }
}
