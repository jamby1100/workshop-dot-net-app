namespace WorkshopApp.Models {
    public interface IWorkshopRepository {
        IQueryable<Workshop> Workshops { get; }

        void SaveWorkshop(Workshop p);
        void CreateWorkshop(Workshop p);
        void DeleteWorkshop(Workshop p);
    }
}