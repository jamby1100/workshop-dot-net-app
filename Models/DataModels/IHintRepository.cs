namespace WorkshopApp.Models {
    public interface IHintRepository {
        IQueryable<Hint> Hints { get; }

        void SaveHint(Hint p);
        void CreateHint(Hint p);
        void DeleteHint(Hint p);
    }
}