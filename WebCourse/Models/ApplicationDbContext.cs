using Microsoft.EntityFrameworkCore;

namespace WebCourse.Models {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<InnovativeProduct> InnovativeProducts { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
