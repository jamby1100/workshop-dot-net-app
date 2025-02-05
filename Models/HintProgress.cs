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

        public string RenderState(string status, double price) {
            if (status == "bought") {
                return $"Bought for {price} pts";
            } else if (status == "pending") {
                return $"Pending";
            }

            return "Unknown State";
        }
    }
}