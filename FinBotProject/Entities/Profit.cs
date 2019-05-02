using System;
using System.Collections.Generic;
using WebApi.Entities.ModelViews;
using WebApi.Interfaces;
using WebApi.Interfaces.IViewModels;

namespace WebApi.Entities
{
    public class Profit : ModelBase<Guid>
    {
        public virtual ICollection<Asset> Asset { get; set; }
        public double Percentage { get; set; }

    }
}
