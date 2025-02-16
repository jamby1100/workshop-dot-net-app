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
            
            if (user == null) {
                user = new IdentityUser("Admin");
                user.Email = "Admin@example.com";
                user.PhoneNumber = "username: sls-group-1, password: adminPassword";
                await userManager.CreateAsync(user, adminPassword);

                user = new IdentityUser("Alpha");
                user.Email = "Alpha@example.com";
                user.PhoneNumber = "username: sls-group-1, password: oa9XQoZcUtS8e9v";
                await userManager.CreateAsync(user, "oa9XQoZcUtS8e9v");

                user = new IdentityUser("Beta");
                user.Email = "Beta@example.com";
                user.PhoneNumber = "username: sls-group-2, password: 7SbDIeXwD0c92qX";
                await userManager.CreateAsync(user, "7SbDIeXwD0c92qX");

                user = new IdentityUser("Charlie");
                user.Email = "Charlie@example.com";
                user.PhoneNumber = "username: sls-group-3, password: 1QPUezhAwHOQsYX";
                await userManager.CreateAsync(user, "1QPUezhAwHOQsYX");

                user = new IdentityUser("Delta");
                user.Email = "Delta@example.com";
                user.PhoneNumber = "username: sls-group-4, password: mOvIXwuL9hlq9Fe";
                await userManager.CreateAsync(user, "mOvIXwuL9hlq9Fe");

                user = new IdentityUser("Echo");
                user.Email = "Echo@example.com";
                user.PhoneNumber = "username: sls-group-5, password: cKJ1YqyLnBk7vqp";
                await userManager.CreateAsync(user, "cKJ1YqyLnBk7vqp");

                user = new IdentityUser("Foxtrot");
                user.Email = "Foxtrot@example.com";
                user.PhoneNumber = "username: sls-group-6, password: SDgZBsK3RkILPfL";
                await userManager.CreateAsync(user, "SDgZBsK3RkILPfL");

                user = new IdentityUser("Golf");
                user.Email = "Golf@example.com";
                user.PhoneNumber = "username: sls-group-7, password: 2eHUWwTChoK32mU";
                await userManager.CreateAsync(user, "2eHUWwTChoK32mU");

                user = new IdentityUser("Helsinki");
                user.Email = "Helsinki@example.com";
                user.PhoneNumber = "username: sls-group-8, password: skX7mycWAD7RdMa";
                await userManager.CreateAsync(user, "skX7mycWAD7RdMa");

                user = new IdentityUser("Indigo");
                user.Email = "Indigo@example.com";
                user.PhoneNumber = "username: sls-group-9, password: wEWnHisK7UjPFwQ";
                await userManager.CreateAsync(user, "wEWnHisK7UjPFwQ");

                user = new IdentityUser("Julia");
                user.Email = "Julia@example.com";
                user.PhoneNumber = "username: sls-group-10, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user, "0MLcWlcUlb89VBT");
            } 
        }
    }
}