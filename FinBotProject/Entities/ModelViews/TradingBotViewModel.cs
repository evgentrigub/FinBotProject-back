using System;
using WebApi.Interfaces.Enums;
using WebApi.Interfaces.IViewModels;

namespace WebApi.Entities.ModelViews
{
    public class TradingBotViewModel : ModelBase<Guid>, ITradingBotViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public FinancialInstrument FinancialInstrument { get; set; }
        public TimeFrame TimeFrame { get; set; }
        public virtual Strategy Strategy { get; set; }
        public double Profit { get; set; }
        public int WorkedTime { get; set; }
    }
}
