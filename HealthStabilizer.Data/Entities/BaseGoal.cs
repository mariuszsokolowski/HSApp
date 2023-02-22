using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthStabilizer.Data.Entities
{
    public class BaseGoal
    {
        [Key]
        public int BaseGoalsId { get; set; }

        public float Calories { get; set; }

        public float Carbs { get; set; }

        public float Fat { get; set; }

        public float Protein { get; set; }

        public int VitaminId { get; set; }

       public virtual Vitamin Vitamin { get; set; }

        public int MineralId { get; set; }

        public virtual Mineral Mineral { get; set; }

    }
}
