using System;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Interfaces
{
    public interface IQuestions : IModelBase<Guid>
    {
        string ObjContent { get; set; }
        ICollection<Answers> Answers { get; set; }
    }
}