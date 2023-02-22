using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthStabilizer.Data.Entities
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        //QrCode or BarCode
        public string QrCode { get; set; }

        public float? WeightPerPiece { get; set; }

        public float? PiecesInPackage { get; set; }

        public int MineralId { get; set; }

        public virtual Mineral Mineral { get; set; }

        public int VitaminId { get; set; }

        public Vitamin Vitamin { get; set; }

        public int? ForUserId { get; set; }

        public float Calories { get; set; }

        public float Protein { get; set; }

        public float Fat { get; set; }

        public float Carbs { get; set; }

        //public virtual User ForUser {get; set;}
    }
}
