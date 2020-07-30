﻿using System;

namespace MassTransit.Contract
{
    public class OrderRejected
    {
        public int OrderId { get; set; }
        public DateTime RejectDate { get; set; }
        public string RejectBy { get; set; }
        public string Reason { get; set; }
    }
}
