using System;

namespace MassTransit.Contract
{
    public class OrderRegistered
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerNumber { get; set; }
    }
}
