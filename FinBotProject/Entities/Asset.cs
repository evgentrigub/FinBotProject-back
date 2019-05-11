using System;
using WebApi.Interfaces;
using WebApi.Interfaces.Enums;

namespace WebApi.Entities
{
    public class Asset : ModelBase<Guid>, IAsset
    {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public Industry Industry { get; set; }
        public FinancialInstrument FinancialInstrument { get; set; }
    }
}
