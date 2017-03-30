using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebCourse.Models {
    public class MyIdentityDbContext : IdentityDbContext<User> {

        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options)
            : base(options) { }

    }
}
