﻿using System;

namespace MassTransit.Contract
{
    public class OrderAccepted
    {
        public int OrderId { get; set; }
        public DateTime AcceptDate { get; set; }
        public string AcceptBy { get; set; }
    }
}
