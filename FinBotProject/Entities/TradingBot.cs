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
        public IStrategy Strategy { get; set; }
        public TimeFrame TimeFrame { get; set; }
    }
}
