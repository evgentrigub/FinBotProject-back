using System;
namespace WebApi.Interfaces.IViewModels
{
    public interface IProfit
    {
        string Asset { get; set; }
        double Percentage { get; set; }
    }
}
