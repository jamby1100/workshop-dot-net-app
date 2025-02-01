namespace WorkshopApp.Models {
    public interface IChallengeRepository {
        IQueryable<Challenge> Challenges { get; }

        void SaveChallenge(Challenge p);
        void CreateChallenge(Challenge p);
        void DeleteChallenge(Challenge p);
    }
}