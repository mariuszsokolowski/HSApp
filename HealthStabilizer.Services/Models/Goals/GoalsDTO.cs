using HealthStabilizer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthStabilizer.Services.Models.Goals
{
    public class GoalsDTO 
    {
        public Data.Entities.Goals Goals { get; set; }
        public Vitamin Vitamin {get;set;}
        public Mineral Mineral { get; set; }

    }
}
