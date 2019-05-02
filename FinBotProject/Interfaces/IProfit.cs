using System;
using System.Collections.Generic;

namespace WebApi.Interfaces.IViewModels
{
    public interface IProfit
    {
        ICollection<IAsset> Asset { get; set; }
        double Percentage { get; set; }
    }
}
