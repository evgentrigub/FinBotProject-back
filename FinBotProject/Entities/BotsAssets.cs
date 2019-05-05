using System;
namespace WebApi.Entities
{
    public class BotsAssets: ModelBase
    {
        public virtual TradingBot TradingBot { get; set; }
        public virtual Asset Asset { get; set; }
    }
}
