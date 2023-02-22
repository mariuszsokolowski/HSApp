using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthStabilizer.Data.Entities
{
    public partial class User : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public float Weight { get; set; }

    }

    public partial class UserRole : IdentityUserRole<string>
    {
        [JsonIgnore]
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }

    public partial class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
