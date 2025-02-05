using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopApp.Models {
    public class HintProgress{
        [BindNever]
        public int HintProgressId { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? HintStatus { get; set; }

        public Hint Hint { get; set; } = new();

        public int HintId { get; set; }
    }
}