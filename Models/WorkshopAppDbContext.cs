using Microsoft.EntityFrameworkCore;

namespace WorkshopApp.Models {
    public class WorkshopAppDbContext : DbContext {
        public WorkshopAppDbContext(DbContextOptions<WorkshopAppDbContext> options): base(options) { }
        public DbSet<Workshop> Workshops => Set<Workshop>();
    }
}
