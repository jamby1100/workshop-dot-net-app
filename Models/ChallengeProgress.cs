using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopApp.Models {
    public class ChallengeProgress {
        [BindNever]
        public int ChallengeProgressId { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? ChallengeStatus { get; set; }

        public Workshop Workshop { get; set; } = new();

        public Challenge Challenge { get; set; } = new();

        public int ChallengeId { get; set; }

    }
}