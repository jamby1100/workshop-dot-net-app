using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopApp.Models {
    public class Hint {
        [BindNever]
        public int HintId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Body { get; set; }

        public Workshop Workshop { get; set; } = new();

        public Challenge Challenge { get; set; } = new();

        public int ChallengeId { get; set; }

        public double Price { get; set; }

    }
}