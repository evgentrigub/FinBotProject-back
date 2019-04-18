using System;
using WebApi.Interfaces;

namespace WebApi.Entities
{
    public class UsersBots : ModelBase, IUsersBots
    {
        public virtual User User { get; set; }
        public virtual TradingBot TradingBot { get; set; }
    }
}
