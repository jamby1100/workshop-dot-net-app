namespace WorkshopApp.Models {
    public interface IWorkshopProgressRepository {
        IQueryable<WorkshopProgress> WorkshopProgresses { get; }

        void SaveWorkshopProgress(WorkshopProgress p);
        void CreateWorkshopProgress(WorkshopProgress p);
        void DeleteWorkshopProgress(WorkshopProgress p);
    }
}