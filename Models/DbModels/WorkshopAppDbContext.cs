using Microsoft.EntityFrameworkCore;

namespace WorkshopApp.Models {
    public class WorkshopAppDbContext : DbContext {
        public WorkshopAppDbContext(DbContextOptions<WorkshopAppDbContext> options): base(options) { }
        public DbSet<Workshop> Workshops => Set<Workshop>();

        public DbSet<Challenge> Challenges => Set<Challenge>();

        public DbSet<WorkshopProgress> WorkshopProgresses => Set<WorkshopProgress>();

        public DbSet<ChallengeProgress> ChallengeProgresses => Set<ChallengeProgress>();

        public DbSet<Hint> Hints => Set<Hint>();

        public DbSet<HintProgress> HintProgresses => Set<HintProgress>();

        public DbSet<PointsLedgerEntry> PointsLedgerEntries => Set<PointsLedgerEntry>();
    }
}
