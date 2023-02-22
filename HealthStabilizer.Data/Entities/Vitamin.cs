using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthStabilizer.Data.Entities
{
    public class Vitamin
    {
        [Key]
        public int VitaminId { get; set; }

        public float VitaminA { get; set; }

        public float VitaminD { get; set; }

        public float VitaminE { get; set; }

        public float VitaminK { get; set; }

        public float VitaminC { get; set; }

        public float Thiamine { get; set; }

        public float Riboflavin { get; set; }

        public float Niacin { get; set; }

        public float VitaminB6 { get; set; }

        public float VitaminB12 { get; set; }

        //Vitamin B9
        public float FolicAcid { get; set; }

        public float Biotin { get; set; }

        public float PanotehnicAcid { get; set; }

        public float Choline { get; set; }


    }
}
