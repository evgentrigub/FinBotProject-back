using System;
using WebApi.Entities;

namespace WebApi.Interfaces
{
    public interface IUsersBots: IModelBase<Guid>
    {
        User User { get; set; }
        TradingBot TradingBot { get; set; }
    }
}
