namespace WorkshopApp.Models.ViewModels {
    public class OneWorkshopView {
        public Workshop WorkshopObject { get; set; } = new();
        
        public IEnumerable<Challenge> Challenges { get; set; } = Enumerable.Empty<Challenge>();

        public WorkshopProgress? WorkshopProgressObject { get; set; } = new();

        public ChallengeProgress? ChallengeProgressObject { get; set; } = new();
        
        public int WorkshopId { get; set; }

        public int ChallengeId  { get; set; }
    }
}