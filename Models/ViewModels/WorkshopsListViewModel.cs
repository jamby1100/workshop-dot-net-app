namespace WorkshopApp.Models.ViewModels {
    public class WorkshopsListViewModel {
        public IEnumerable<Workshop> Workshops { get; set; } = Enumerable.Empty<Workshop>();
        public PagingInfo PagingInfo { get; set; } = new();
        public IEnumerable<Challenge> Challenges { get; set; } = Enumerable.Empty<Challenge>();
        public required UserDisplayViewModel UserDisplay { get; set; }
    }
}