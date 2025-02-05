using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopApp.Models {
    public class PointsLedgerEntry{
        [BindNever]
        public int PointsLedgerEntryId { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? Remarks { get; set; }

        public Workshop Workshop { get; set; } = new();

        public int WorkshopId { get; set; }

        public double Points { get; set; }

    }
}