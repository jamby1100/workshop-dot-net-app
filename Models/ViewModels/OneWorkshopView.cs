namespace WorkshopApp.Models.ViewModels {
    public class OneWorkshopView {
        public Workshop WorkshopObject { get; set; } = new();
        
        public IEnumerable<Challenge> Challenges { get; set; } = Enumerable.Empty<Challenge>();
    }
}