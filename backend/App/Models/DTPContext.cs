using Microsoft.EntityFrameworkCore;

namespace DockerTestProject.Models {
    public class DTPContext : DbContext {
        public DTPContext(DbContextOptions<DTPContext> options) : base(options) {

        }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
          modelBuilder.Entity<Profile>(b => {
            b.HasKey(e => e.Id);
            b.Property(e => e.Id).ValueGeneratedOnAdd();
          });
        }
    }
}
