using System;
namespace WebApi.Interfaces
{
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
