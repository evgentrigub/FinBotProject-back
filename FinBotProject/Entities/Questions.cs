using System;
using System.Collections.Generic;
using WebApi.Interfaces;

namespace WebApi.Entities
{
    public class Questions : ModelBase<Guid>, IQuestions
    {
        public string ObjContent { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
    }
}
