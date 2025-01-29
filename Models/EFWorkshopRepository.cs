namespace WorkshopApp.Models {
    public class EFWorkshopRepository : IWorkshopRepository {
        private WorkshopAppDbContext context;
        
        public EFWorkshopRepository(WorkshopAppDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Workshop> Workshops => context.Workshops;

        public void CreateWorkshop(Workshop p) {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteWorkshop(Workshop p) {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveWorkshop(Workshop p) {
            context.SaveChanges();
        }
    }
}