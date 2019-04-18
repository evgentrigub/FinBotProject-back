using System;
using WebApi.Entities;
using WebApi.Interfaces.Enums;

namespace WebApi.Interfaces
{
    public interface ITradibgBot : IModelBase<Guid>
    {
        ///<summary>Название робота</summary>
        string Name { get; set; }
        /// <summary>Gets or sets the description</summary>
        string Description { get; set; }
        ///<summary> Тип </summary>
        string Type { get; set; }
        ///<summary> Идентификатор торгового горизонта</summary>
        TimeFrame TimeFrame { get; set; }
        ///<summary> Идентификатор стратегии</summary>
        Strategy Strategy { get; set; }
    }
}
