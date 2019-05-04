using System;
using System.Collections;
using System.Collections.Generic;
using WebApi.Interfaces;

namespace WebApi.Entities
{
    public class Strategy : ModelBase, IStrategy
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string StrategyOSEngine { get; set; }
    }
}
