using System;
using WebApi.Interfaces.IViewModels;

namespace WebApi.Entities
{
    public class Profit : ModelBase<Guid>, IProfit
    {
        public string Asset { get; set; }
        public double Percentage { get; set; }
    }
}
