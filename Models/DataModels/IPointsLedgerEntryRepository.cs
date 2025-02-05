namespace WorkshopApp.Models {
    public interface IPointsLedgerEntryRepository {
        IQueryable<PointsLedgerEntry> PointsLedgerEntrys { get; }

        void SavePointsLedgerEntry(PointsLedgerEntry p);
        void CreatePointsLedgerEntry(PointsLedgerEntry p);
        void DeletePointsLedgerEntry(PointsLedgerEntry p);
    }
}