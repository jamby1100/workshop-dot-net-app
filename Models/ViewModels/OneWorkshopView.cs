namespace WorkshopApp.Models.ViewModels {
    public class OneWorkshopView {
        public Workshop WorkshopObject { get; set; } = new();
        
        public IEnumerable<Challenge> Challenges { get; set; } = Enumerable.Empty<Challenge>();

        public WorkshopProgress? WorkshopProgressObject { get; set; } = new();

        public ChallengeProgress? ChallengeProgressObject { get; set; } = new();
        
        public IEnumerable<ChallengeProgress> ChallengeProgressList { get; set; } = Enumerable.Empty<ChallengeProgress>();

        public IEnumerable<WorkshopProgress> WorkshopProgressList { get; set; } = Enumerable.Empty<WorkshopProgress>();

        

        public IEnumerable<HintProgress> HintProgressList { get; set; } = Enumerable.Empty<HintProgress>();

        public IEnumerable<PointsLedgerEntry> LedgerTable { get; set; } = Enumerable.Empty<PointsLedgerEntry>();

        public HintProgress HintProgressOne { get; set; } = new();

        public Dictionary<int,Challenge> ChallengesDictionary { get; set;} = new();

        public Dictionary<int,Hint> HintDictionary { get; set;} = new();
        
        public int WorkshopId { get; set; }

        public int ChallengeId  { get; set; }

        public int HintId { get; set; }

        public string sumOfPoints { get; set; }

        public double PointsValue { get; set; }

        public string RemarksValue { get; set; }

        public string UserId { get; set; }

        public string TargetStatus { get; set; }

    }
}