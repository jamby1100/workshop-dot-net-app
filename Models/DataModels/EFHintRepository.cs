namespace WorkshopApp.Models {
    public class EFHintRepository : IHintRepository {
        private WorkshopAppDbContext context;
        
        public EFHintRepository(WorkshopAppDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Hint> Hints => context.Hints;

        public void CreateHint(Hint p) {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteHint(Hint p) {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveHint(Hint p) {
            context.SaveChanges();
        }
    }
}