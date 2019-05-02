using System;
using WebApi.Interfaces;
using WebApi.Interfaces.Enums;

namespace WebApi.Entities
{
    public class TradingBot : ModelBase, ITradibgBot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual FinancialInstrument FinancialInstrument { get; set; }
        public virtual TimeFrame TimeFrame { get; set; }
        public virtual Strategy Strategy { get; set; }
        public virtual Profit Profit { get; set; }
    }
}
