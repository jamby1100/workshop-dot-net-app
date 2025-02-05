namespace WorkshopApp.Models {
    public interface IHintProgressRepository {
        IQueryable<HintProgress> HintProgresses { get; }

        void SaveHintProgress(HintProgress p);
        void CreateHintProgress(HintProgress p);
        void DeleteHintProgress(HintProgress p);

        void BatchCreateHintProgress(IList<HintProgress> pList);
    }
}