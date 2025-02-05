namespace WorkshopApp.Models {
    public interface IPointsLedgerEntryRepository {
        IQueryable<PointsLedgerEntry> PointsLedgerEntries { get; }

        void SavePointsLedgerEntry(PointsLedgerEntry p);
        void CreatePointsLedgerEntry(PointsLedgerEntry p);
        void DeletePointsLedgerEntry(PointsLedgerEntry p);
    }
}