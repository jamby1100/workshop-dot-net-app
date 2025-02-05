namespace WorkshopApp.Models {
    public class EFPointsLedgerEntryRepository : IPointsLedgerEntryRepository {
        private WorkshopAppDbContext context;
        
        public EFPointsLedgerEntryRepository(WorkshopAppDbContext ctx) {
            context = ctx;
        }

        public IQueryable<PointsLedgerEntry> PointsLedgerEntries => context.PointsLedgerEntries;

        public void CreatePointsLedgerEntry(PointsLedgerEntry p) {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeletePointsLedgerEntry(PointsLedgerEntry p) {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SavePointsLedgerEntry(PointsLedgerEntry p) {
            context.SaveChanges();
        }
    }
}