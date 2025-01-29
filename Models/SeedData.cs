using Microsoft.EntityFrameworkCore;
namespace WorkshopApp.Models {
   public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            WorkshopAppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WorkshopAppDbContext>();
                   
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Workshops.Any()) {
                context.Workshops.AddRange(
                    new Workshop {
                        Name = "Serverless Challenge",
                        Description = "This is a challenge that will teach you all you need to know about serverless.",
                        EstimateTimeToFinish = 120,
                        Published = true
                    }
                );

                context.SaveChanges();
            }
        }
    } 
}