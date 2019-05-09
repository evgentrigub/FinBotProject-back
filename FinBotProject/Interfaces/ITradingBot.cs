using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Interfaces.Enums;

namespace WebApi.Interfaces
{
    public interface ITradingBot : IModelBase<Guid>
    {
        ///<summary>Название робота</summary>
        string Name { get; set; }
        /// <summary> Пользователь </summary>
        User User { get; set; }
        ///<summary> Тип </summary>
        string Type { get; set; }
        ///<summary> Идентификатор торгового горизонта</summary>
        TimeFrame TimeFrame { get; set; }
        ///<summary> Идентификатор стратегии</summary>
        Strategy Strategy { get; set; }
        ///<summary> Ожидаемая доходность </summary>
        double ESValue { get; set; }
        //<summary> Денежная сумма на бота </summary>
        int Sum { get; set; }
    }
}
