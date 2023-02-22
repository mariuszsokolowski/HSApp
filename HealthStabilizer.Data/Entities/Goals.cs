 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthStabilizer.Data.Entities
{
    public class Goals
    {
        [Key]
        public int GoalsId { get; set; }


        public float Calories { get; set; }

        public float Carbs { get; set; }

        public float Fat { get; set; }

        public float Protein { get; set; }


        public string ForUserId { get; set; }

        public virtual User ForUser {get; set;}
    }
}
