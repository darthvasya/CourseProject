using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebCourse.Models {
    public class User : IdentityUser {
        public string Name { get; set; }

        public DateTime Joined { get; set; }
        
    }
}
