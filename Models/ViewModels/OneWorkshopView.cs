namespace WorkshopApp.Models.ViewModels {
    public class OneWorkshopView {
        public Workshop WorkshopObject { get; set; } = new();
        
        public IEnumerable<Challenge> Challenges { get; set; } = Enumerable.Empty<Challenge>();

        public WorkshopProgress? WorkshopProgressObject { get; set; } = new();

        public ChallengeProgress? ChallengeProgressObject { get; set; } = new();
        
        public IEnumerable<ChallengeProgress> ChallengeProgressList { get; set; } = Enumerable.Empty<ChallengeProgress>();

        public IEnumerable<HintProgress> HintProgressList { get; set; } = Enumerable.Empty<HintProgress>();

        public HintProgress HintProgressOne { get; set; } = new();

        public Dictionary<int,Challenge> ChallengesDictionary { get; set;} = new();

        public Dictionary<int,Hint> HintDictionary { get; set;} = new();
        
        public int WorkshopId { get; set; }

        public int ChallengeId  { get; set; }

        public int HintId { get; set; }
    }
}