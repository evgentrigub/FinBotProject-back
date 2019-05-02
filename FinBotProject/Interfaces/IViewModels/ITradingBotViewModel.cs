using System;
using WebApi.Entities;
using WebApi.Interfaces.Enums;

namespace WebApi.Interfaces.IViewModels
{
    public interface ITradingBotViewModel: IModelBase<Guid>
    {
        string Name { get; set; }
        string Type { get; set; }
        FinancialInstrument FinancialInstrument { get; set; }
        TimeFrame TimeFrame { get; set; }
        string Strategy { get; set; }
        double Profit { get; set; }
    }
}
