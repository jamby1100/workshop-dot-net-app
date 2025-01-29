namespace WorkshopApp.Models.ViewModels {
    public class WorkshopsListViewModel {
        public IEnumerable<Workshop> Workshops { get; set; } = Enumerable.Empty<Workshop>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory { get; set; }
    }
}