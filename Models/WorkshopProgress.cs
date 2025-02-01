using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorkshopApp.Models {
    public class WorkshopProgress {
        [BindNever]
        public int WorkshopProgressId { get; set; }

        public Workshop Workshop { get; set; } = new();

    }
}