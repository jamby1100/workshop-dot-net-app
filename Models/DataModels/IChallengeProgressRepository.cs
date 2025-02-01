namespace WorkshopApp.Models {
    public interface IChallengeProgressRepository {
        IQueryable<ChallengeProgress> ChallengeProgresses { get; }

        void SaveChallengeProgress(ChallengeProgress p);
        void CreateChallengeProgress(ChallengeProgress p);
        void DeleteChallengeProgress(ChallengeProgress p);
    }
}