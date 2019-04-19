using System;
using WebApi.Interfaces;

namespace WebApi.Entities
{
    public class Response: IResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public IResponse From(IResponse response)
        {
            IsSuccess = response.IsSuccess;
            Message += response.Message + ";";
            return this;
        }

        public Response(string message = "", bool isSuccess = false)
        {
            Message = message + ";";
            IsSuccess = isSuccess;
        }
    }

    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }
        public Response(T data = default(T), string message = "", bool isSuccess = false) : base(message, isSuccess)
        {
            if (data == null)
            {
                IsSuccess = false;
                return;
            }
            Data = data;
            IsSuccess = true;
        } 
        public IResponse<T> From(IResponse<T> response)
        {
            base.From(response);
            Data = response.Data;
            return this;    
        }
    }
}
