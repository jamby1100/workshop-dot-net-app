using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopApp.Models {
    public class Challenge {
        [BindNever]
        public int ChallengeId { get; set; }

        [Required(ErrorMessage = "Pls enter a name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Pls enter description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Add an estimate")]
        public double EstimateTimeToFinish { get; set; }

        [Required(ErrorMessage = "Pls enter a challenge brief markdown")]
        public string? ChallengeBriefMarkdown { get; set; }

        public Workshop Workshop { get; set; } = new();
    }
}