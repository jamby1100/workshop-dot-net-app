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
                    ChallengeBriefMarkdown = "Visit the <a href='https://www.notion.so/Challenge-1-18f9d79bc5b5808b936dea10dd94a269?pvs=4'> challenge brief here </a>",
                    Workshop = w1,
                    Points=10
                };

                Challenge c2 = new Challenge {
                    Name = "Adding DynamoDB Capability",
                    Description = "Let's add a real database",
                    EstimateTimeToFinish = 30,
                    ChallengeBriefMarkdown = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Challenge-2-18f9d79bc5b580cd9273fe2f745bfd1f?pvs=4'> challenge brief here </a>",
                    Workshop = w1,
                    Points=20
                };

                Challenge c3 = new Challenge {
                    Name = "Adding S3 File Batch Uploads",
                    Description = "Let's batch create S3 buckets",
                    EstimateTimeToFinish = 30,
                    ChallengeBriefMarkdown = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Challenge-3-18f9d79bc5b580dd82bfd4644022a275?pvs=4'> challenge brief here </a> ",
                    Workshop = w1,
                    Points=30
                };

                Challenge c4 = new Challenge {
                    Name = "Adding SQS Capability",
                    Description = "Let's create the SQS queue",
                    EstimateTimeToFinish = 30,
                    ChallengeBriefMarkdown = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Challenge-4-18f9d79bc5b5804c8f57f174a7cc9a52?pvs=4'> challenge brief here </a>",
                    Workshop = w1,
                    Points=40
                };

                Challenge c5 = new Challenge {
                    Name = "Productionizing your Serverless App",
                    Description = "Let's build a strong Python App!",
                    EstimateTimeToFinish = 30,
                    ChallengeBriefMarkdown = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Challenge-5-Productionize-your-Python-Serverless-Application-1929d79bc5b58088bd73e8bc7414784e'> challenge brief here </a>",
                    Workshop = w1,
                    Points=40
                };

                context.Challenges.AddRange(c1,c2, c3, c4);
                context.SaveChanges();

                // Hint h2_0 = new Hint {
                //     Name = "Hint 2.0: Creating DynamoDB using AWS Console",
                //     Body = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Hint-2-1-1pt-Creating-DynamoDB-using-AWS-Console-1929d79bc5b580fcbfccc2d70945418c?pvs=4'> hint here </a>",
                //     Challenge = c2,
                //     Workshop = w1,
                //     Price = 1
                // };

                // Hint h2_1 = new Hint {
                //     Name = "Hint 2.1: Accessing the request_body and the {product_id} in the url",
                //     Body = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Hint-2-1-18f9d79bc5b580c89563d1315d22ba69?pvs=4'> hint here </a>",
                //     Challenge = c2,
                //     Workshop = w1,
                //     Price = 1
                // };

                // Hint h2_2 = new Hint {
                //     Name = "Hint 2.2: How to create GET, POST, PUT, PATCH, and DELETE API endpoints in serverless.yml",
                //     Body = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Hint-2-2-18f9d79bc5b5803395d1e5aadf63750b?pvs=4'> hint here </a>",
                //     Challenge = c2,
                //     Workshop = w1,
                //     Price = 1
                // };

                // Hint h2_3 = new Hint {
                //     Name = "Hint 2.3: HINT: Using boto3 to connect the database",
                //     Body = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Hint-2-3-18f9d79bc5b580dbb53ff632dab6a689?pvs=4'> hint here </a>",
                //     Challenge = c2,
                //     Workshop = w1,
                //     Price = 3
                // };

                // Hint h3_1 = new Hint {
                //     Name = "Hint 3.1: Link AWS Lambda function to the s3 bucket ",
                //     Body = "Visit the <a href='https://www.serverless.com/framework/docs/providers/aws/events/s3#using-existing-buckets'> hint here </a>",
                //     Challenge = c3,
                //     Workshop = w1,
                //     Price = 1
                // };

                // Hint h3_2 = new Hint {
                //     Name = "Hint 3.2: Reading a CSV file from an AWS S3 Bucket",
                //     Body = "Visit the <a href='https://walnut-raccoon-d7a.notion.site/Hint-3-2-5pts-Reading-a-CSV-file-from-an-AWS-S3-Bucket-1929d79bc5b580ed9567d242cc805171?pvs=74s'> hint here </a>",
                //     Challenge = c3,
                //     Workshop = w1,
                //     Price = 3
                // };

                // context.Hints.AddRange(h2_0, h2_1, h2_2, h2_3, h3_1, h3_2);
                context.SaveChanges();
            }
        }
    } 
}