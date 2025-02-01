using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopApp.Models {
    public class Workshop {
        [BindNever]
        public int WorkshopId { get; set; }

        [Required(ErrorMessage = "Pls enter a name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Pls enter description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Add an estimate")]
        public double EstimateTimeToFinish { get; set; }
        public bool Published { get; set; }

        public ICollection<Challenge> Challenges { get; set; } = new List<Challenge>();
    }
}