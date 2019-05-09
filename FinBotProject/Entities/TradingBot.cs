using System;
using System.Collections.Generic;
using WebApi.Interfaces;
using WebApi.Interfaces.Enums;

namespace WebApi.Entities
{
    public class TradingBot : ModelBase, ITradingBot
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Sum { get; set; }
        public double Profit { get; set; }
        public double ESValue { get; set; }
        public virtual TimeFrame TimeFrame { get; set; }
        public virtual Strategy Strategy { get; set; }
        public virtual User User { get; set; }
    }
}
