using System;
namespace WebApi.Interfaces
{
    /// <summary>
    /// Базовые свойства присущие всем объектам
    /// </summary>
    public interface IModelBase<TId>
    {
        ///<summary> Идентификатор </summary>
        TId Id { get; set; }
        ///<summary> Флаг активности </summary>
        bool IsActive { get; set; }
        ///<summary> Дата создания </summary>
        DateTime CreatedDate { get; set; }
    }
}
