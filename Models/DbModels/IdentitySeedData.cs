using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace WorkshopApp.Models {
    public static class IdentitySeedData {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app) {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();
            
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            
            IdentityUser? user = await userManager.FindByNameAsync(adminUser);
            IdentityUser? user1;
            IdentityUser? user2;
            IdentityUser? user3;
            IdentityUser? user4;
            IdentityUser? user5;
            IdentityUser? user6;
            IdentityUser? user7;
            IdentityUser? user8;
            IdentityUser? user9;
            IdentityUser? user10;
            
            if (user == null) {
                user = new IdentityUser("Admin");
                user.Email = "Admin@example.com";
                user.PhoneNumber = "username: sls-group-1, password: adminPassword";
                await userManager.CreateAsync(user, adminPassword);

                user1 = new IdentityUser("Alpha");
                user1.Email = "Alpha@example.com";
                user1.PhoneNumber = "username: sls-group-1, password: oa9XQoZcUtS8e9v";
                await userManager.CreateAsync(user1, "oa9XQoZcUtS8e9v$$");

                user2 = new IdentityUser("Beta");
                user2.Email = "Beta@example.com";
                user2.PhoneNumber = "username: sls-group-2, password: 7SbDIeXwD0c92qX";
                await userManager.CreateAsync(user2, "7SbDIeXwD0c92qX$$");

                user3 = new IdentityUser("Charlie");
                user3.Email = "Charlie@example.com";
                user3.PhoneNumber = "username: sls-group-3, password: 1QPUezhAwHOQsYX";
                await userManager.CreateAsync(user3, "1QPUezhAwHOQsYX$$");

                user4 = new IdentityUser("Delta");
                user4.Email = "Delta@example.com";
                user4.PhoneNumber = "username: sls-group-4, password: mOvIXwuL9hlq9Fe";
                await userManager.CreateAsync(user4, "mOvIXwuL9hlq9Fe$$");

                user5 = new IdentityUser("Echo");
                user5.Email = "Echo@example.com";
                user5.PhoneNumber = "username: sls-group-5, password: cKJ1YqyLnBk7vqp";
                await userManager.CreateAsync(user5, "cKJ1YqyLnBk7vqp$$");

                user6 = new IdentityUser("Foxtrot");
                user6.Email = "Foxtrot@example.com";
                user6.PhoneNumber = "username: sls-group-6, password: SDgZBsK3RkILPfL";
                await userManager.CreateAsync(user6, "SDgZBsK3RkILPfL$$");

                user7 = new IdentityUser("Golf");
                user7.Email = "Golf@example.com";
                user7.PhoneNumber = "username: sls-group-7, password: 2eHUWwTChoK32mU";
                await userManager.CreateAsync(user7, "2eHUWwTChoK32mU$$");

                user8 = new IdentityUser("Helsinki");
                user8.Email = "Helsinki@example.com";
                user8.PhoneNumber = "username: sls-group-8, password: skX7mycWAD7RdMa";
                await userManager.CreateAsync(user8, "skX7mycWAD7RdMa$$");

                user9 = new IdentityUser("Indigo");
                user9.Email = "Indigo@example.com";
                user9.PhoneNumber = "username: sls-group-9, password: wEWnHisK7UjPFwQ";
                await userManager.CreateAsync(user9, "wEWnHisK7UjPFwQ$$");

                user10 = new IdentityUser("Julia");
                user10.Email = "Julia@example.com";
                user10.PhoneNumber = "username: sls-group-10, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user10, "0MLcWlcUlb89VBT$$");
            } 
        }
    }
}