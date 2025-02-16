using Microsoft.EntityFrameworkCore;
namespace WorkshopApp.Models {
   public static class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            WorkshopAppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<WorkshopAppDbContext>();
            
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Workshops.Any()) {
                Workshop w1 = new Workshop {
                    Name = "Serverless Challenge",
                    Description = "This is a challenge that will teach you all you need to know about serverless.",
                    WorkshopBriefMarkdown = "Do these: <a href='https://walnut-raccoon-d7a.notion.site/Prerequisites-17f9d79bc5b580549da6d77b714b00fa?pvs=74'> pre-requisites first </a>",
                    EstimateTimeToFinish = 120,
                    Published = true
                };

                context.Workshops.AddRange(w1);

                context.SaveChanges();

                Challenge c1 = new Challenge {
                    Name = "Starting your Serverless Application",
                    Description = "Let's get started with your first serverless app deployment",
                    EstimateTimeToFinish = 10,
                    ChallengeBriefMarkdown = "Visit the url here: https://www.notion.so/Challenge-1-18f9d79bc5b5808b936dea10dd94a269?pvs=4",
                    Workshop = w1,
                    Points=10
                };

                Challenge c2 = new Challenge {
                    Name = "Adding DynamoDB Capability",
                    Description = "Let's add a real database",
                    EstimateTimeToFinish = 30,
                    ChallengeBriefMarkdown = "Visit the url here: https://walnut-raccoon-d7a.notion.site/Challenge-2-18f9d79bc5b580cd9273fe2f745bfd1f?pvs=4",
                    Workshop = w1,
                    Points=20
                };

                Challenge c3 = new Challenge {
                    Name = "Adding S3 File Batch Uploads",
                    Description = "Let's add a real database",
                    EstimateTimeToFinish = 30,
                    ChallengeBriefMarkdown = "Visit the url here: https://walnut-raccoon-d7a.notion.site/Challenge-3-18f9d79bc5b580dd82bfd4644022a275?pvs=4",
                    Workshop = w1,
                    Points=30
                };

                Challenge c4 = new Challenge {
                    Name = "Adding SQS Capability",
                    Description = "Let's add a real database",
                    EstimateTimeToFinish = 30,
                    ChallengeBriefMarkdown = "Visit the url here: https://walnut-raccoon-d7a.notion.site/Challenge-4-18f9d79bc5b5804c8f57f174a7cc9a52?pvs=4",
                    Workshop = w1,
                    Points=40
                };

                context.Challenges.AddRange(c1,c2, c3, c4);
                context.SaveChanges();

                Hint h2_1 = new Hint {
                    Name = "Hint 2.1: Accessing the request_body and the {product_id} in the url",
                    Body = "https://walnut-raccoon-d7a.notion.site/Hint-2-1-18f9d79bc5b580c89563d1315d22ba69?pvs=4",
                    Challenge = c2,
                    Workshop = w1,
                    Price = 1
                };

                Hint h2_2 = new Hint {
                    Name = "Hint 2.2: How to create GET, POST, PUT, PATCH, and DELETE API endpoints in serverless.yml",
                    Body = "https://walnut-raccoon-d7a.notion.site/Hint-2-2-18f9d79bc5b5803395d1e5aadf63750b?pvs=4",
                    Challenge = c2,
                    Workshop = w1,
                    Price = 1
                };

                Hint h2_3 = new Hint {
                    Name = "Hint 2.3: HINT: Using boto3 to connect the database",
                    Body = "https://walnut-raccoon-d7a.notion.site/Hint-2-3-18f9d79bc5b580dbb53ff632dab6a689?pvs=4",
                    Challenge = c2,
                    Workshop = w1,
                    Price = 1
                };

                context.Hints.AddRange(h2_1, h2_2, h2_3);
                context.SaveChanges();
            }



        }
    } 
}