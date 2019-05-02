using System;
using WebApi.Interfaces.Enums;

namespace WebApi.Interfaces
{
    public interface IAsset: IModelBase<Guid>
    {
        string Name { get; set; }
        Industry Industry { get; set; }
    }
}
