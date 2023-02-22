using HealthStabilizer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthStabilizer.Services.Models.Diary
{
    public class DiaryIntakeSumDTO
    {
        public double GoalCalories { get; set; }
        public double SumCalories { get; set; }
        public double GoalFat { get; set; }
        public double SumFat { get; set; }
        public double GoalProtein { get; set; }
        public double SumProtein { get; set; }
        public double GoalCarbs { get; set; }
        public double SumCarbs { get; set; }

        public Vitamin GoalVitamin { get; set; } = new Vitamin();

        public Vitamin SumVitamin { get; set; } = new Vitamin();

        public Mineral GoalMineral { get; set; } = new Mineral();

        public Mineral SumMineral { get; set; } = new Mineral();

    }
}
