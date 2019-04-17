using System;
using WebApi.Interfaces;

namespace WebApi.Services.Base
{
    public abstract class RepositoryBase<T, TImplementation>
        where T : class, IModelBase<Guid>
        where TImplementation : class, T
    {
        public RepositoryBase()
        {
        }
    }
}
