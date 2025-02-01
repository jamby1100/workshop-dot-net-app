namespace WorkshopApp.Models {
    public class EFWorkshopProgressRepository : IWorkshopProgressRepository {
        private WorkshopAppDbContext context;
        
        public EFWorkshopProgressRepository(WorkshopAppDbContext ctx) {
            context = ctx;
        }

        public IQueryable<WorkshopProgress> WorkshopProgresses => context.WorkshopProgresses;

        public void CreateWorkshopProgress(WorkshopProgress p) {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteWorkshopProgress(WorkshopProgress p) {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveWorkshopProgress(WorkshopProgress p) {
            context.SaveChanges();
        }
    }
}