namespace WorkshopApp.Models {
    public class EFChallengeProgressRepository : IChallengeProgressRepository {
        private WorkshopAppDbContext context;
        
        public EFChallengeProgressRepository(WorkshopAppDbContext ctx) {
            context = ctx;
        }

        public IQueryable<ChallengeProgress> ChallengeProgresses => context.ChallengeProgresses;

        public void CreateChallengeProgress(ChallengeProgress p) {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteChallengeProgress(ChallengeProgress p) {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveChallengeProgress(ChallengeProgress p) {
            context.SaveChanges();
        }
    }
}