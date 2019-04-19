using System;
namespace WebApi.Interfaces
{
    public interface IResponse
    {
        ///<summary> Логическое значение </summary>
        bool IsSuccess { get; set; }
        /// <summary> Строковое сообщение </summary>
        string Message { get; set; }
        /// <summary> Совмещение результатов</summary>
        IResponse From(IResponse response);

    }

    public interface IResponse<T>: IResponse
    {
        T Data { get; set; }
        ///<summary> Совмещение результатов </summary>
        IResponse<T> From(IResponse<T> response);
    }
}
