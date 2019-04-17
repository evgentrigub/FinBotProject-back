using System;
namespace WebApi.Interfaces
{
    public interface IStrategy : IModelBase<Guid>
    {
        /// <summary> Название </summary>
        string Name { get; set; }
        /// <summary> Description </summary>
        string Description { get; set; }
        /// <summary> Стратегия </summary>
        string StrategyOSEngine { get; set; }
    }
}
