using Microsoft.EntityFrameworkCore;

namespace DockerTestProject.Models {
    public class DTPContext : DbContext {
        public DTPContext(DbContextOptions<DTPContext> options) : base(options) {

        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
