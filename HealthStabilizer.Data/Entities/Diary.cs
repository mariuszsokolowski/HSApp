using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthStabilizer.Data.Entities
{
    public class Diary
    {
        [Key]
        public int DiaryId { get; set; }

        [Required]

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]

        public DateTime Date { get; set; }

        [Required]

        public DateTime CreateDate { get; set; }

        [Required]

        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        [Required]
        public float Quantity { get; set; }

    }
}
