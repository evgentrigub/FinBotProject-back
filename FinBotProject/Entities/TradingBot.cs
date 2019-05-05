using System;
using System.Collections.Generic;
using WebApi.Interfaces;
using WebApi.Interfaces.Enums;

namespace WebApi.Entities
{
    public class TradingBot : ModelBase, ITradibgBot
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Sum { get; set; }
        public virtual FinancialInstrument FinancialInstrument { get; set; }
        public virtual TimeFrame TimeFrame { get; set; }
        public virtual Strategy Strategy { get; set; }
        public double Profit { get; set; }
        //public virtual ICollection<Asset> Assets {get; set;}
        public virtual User User { get; set; }
        public double ESValue { get; set; }
    }
}
