using System;
using System.Collections.Generic;
using System.Text;

namespace HealthStabilizer.Services.Models.User
{
    public class UserProfile
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public float Weight { get; set; }


    }
}
