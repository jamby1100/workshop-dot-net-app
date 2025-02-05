namespace WorkshopApp.Models {
    public class EFHintProgressRepository : IHintProgressRepository {
        private WorkshopAppDbContext context;
        
        public EFHintProgressRepository(WorkshopAppDbContext ctx) {
            context = ctx;
        }

        public IQueryable<HintProgress> HintProgresses => context.HintProgresses;

        public void CreateHintProgress(HintProgress p) {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteHintProgress(HintProgress p) {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveHintProgress(HintProgress p) {
            context.SaveChanges();
        }

        public void BatchCreateHintProgress(IList<HintProgress> pList) {            
            foreach (var hp in pList) {
                context.Add(hp);
            };

            context.SaveChanges();
        }
    }
}