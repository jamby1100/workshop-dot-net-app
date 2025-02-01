using Microsoft.EntityFrameworkCore;
namespace WorkshopApp.Models {
   public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            WorkshopAppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WorkshopAppDbContext>();
            
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            Workshop w1 = new Workshop {
                Name = "Serverless Challenge",
                Description = "This is a challenge that will teach you all you need to know about serverless.",
                EstimateTimeToFinish = 120,
                Published = true
            };

            context.Workshops.AddRange(w1);

            context.SaveChanges();

            Challenge c1 = new Challenge {
                Name = "Starting your Serverless Application",
                Description = "Let's get started with your first serverless app deployment",
                EstimateTimeToFinish = 10,
                ChallengeBriefMarkdown = "# This is it [some link](https://google.com)",
                Workshop = w1
            };

            Challenge c2 = new Challenge {
                Name = "Adding DynamoDB Capability",
                Description = "Let's add a real database",
                EstimateTimeToFinish = 30,
                ChallengeBriefMarkdown = "# This is it [some link](https://google.com)",
                Workshop = w1
            };

            context.Challenges.AddRange(c1,c2);
            context.SaveChanges();
        }
    } 
}