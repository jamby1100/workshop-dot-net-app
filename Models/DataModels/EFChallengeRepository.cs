namespace WorkshopApp.Models {
    public class EFChallengeRepository : IChallengeRepository {
        private WorkshopAppDbContext context;
        
        public EFChallengeRepository(WorkshopAppDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Challenge> Challenges => context.Challenges;

        public void CreateChallenge(Challenge p) {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteChallenge(Challenge p) {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveChallenge(Challenge p) {
            context.SaveChanges();
        }
    }
}