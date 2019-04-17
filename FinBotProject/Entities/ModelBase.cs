using System;
using WebApi.Interfaces;

namespace WebApi.Entities
{
    public abstract class ModelBase<TId> : IModelBase<TId>
    {
        public ModelBase()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        public TId Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public abstract class ModelBase : ModelBase<Guid>
    {
        public ModelBase() : base()
        {
            Id = Guid.NewGuid();
        }
    }
}
