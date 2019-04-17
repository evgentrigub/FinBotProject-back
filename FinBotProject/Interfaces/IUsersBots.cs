using System;
using WebApi.Entities;

namespace WebApi.Interfaces
{
    public interface IUsersBots: IModelBase<Guid>
    {
        User User_Id { get; set; }
        ITradibgBot TradingBot_Id { get; set; }
    }
}
