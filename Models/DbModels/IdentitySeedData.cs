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
            IdentityUser? user11;
            IdentityUser? user12;
            IdentityUser? user13;
            IdentityUser? user14;
            IdentityUser? user15;
            
            if (user == null) {
                user = new IdentityUser("Admin");
                user.Email = "Admin@example.com";
                user.PhoneNumber = "username: sls-group-1, password: adminPassword";
                await userManager.CreateAsync(user, adminPassword);

                user1 = new IdentityUser("Alpha");
                user1.Email = "Alpha@example.com";
                user1.PhoneNumber = "username: sls-group-1, password: oa9XQoZcUtS8e9v";
                await userManager.CreateAsync(user1, "pythonWorkshop$$1");

                user2 = new IdentityUser("Beta");
                user2.Email = "Beta@example.com";
                user2.PhoneNumber = "username: sls-group-2, password: 7SbDIeXwD0c92qX";
                await userManager.CreateAsync(user2, "pythonWorkshop$$2");

                user3 = new IdentityUser("Charlie");
                user3.Email = "Charlie@example.com";
                user3.PhoneNumber = "username: sls-group-3, password: 1QPUezhAwHOQsYX";
                await userManager.CreateAsync(user3, "pythonWorkshop$$3");

                user4 = new IdentityUser("Delta");
                user4.Email = "Delta@example.com";
                user4.PhoneNumber = "username: sls-group-4, password: mOvIXwuL9hlq9Fe";
                await userManager.CreateAsync(user4, "pythonWorkshop$$4");

                user5 = new IdentityUser("Echo");
                user5.Email = "Echo@example.com";
                user5.PhoneNumber = "username: sls-group-5, password: cKJ1YqyLnBk7vqp";
                await userManager.CreateAsync(user5, "pythonWorkshop$$5");

                user6 = new IdentityUser("Foxtrot");
                user6.Email = "Foxtrot@example.com";
                user6.PhoneNumber = "username: sls-group-6, password: SDgZBsK3RkILPfL";
                await userManager.CreateAsync(user6, "pythonWorkshop$$6");

                user7 = new IdentityUser("Golf");
                user7.Email = "Golf@example.com";
                user7.PhoneNumber = "username: sls-group-7, password: 2eHUWwTChoK32mU";
                await userManager.CreateAsync(user7, "pythonWorkshop$$7");

                user8 = new IdentityUser("Helsinki");
                user8.Email = "Helsinki@example.com";
                user8.PhoneNumber = "username: sls-group-8, password: skX7mycWAD7RdMa";
                await userManager.CreateAsync(user8, "pythonWorkshop$$8");

                user9 = new IdentityUser("Indigo");
                user9.Email = "Indigo@example.com";
                user9.PhoneNumber = "username: sls-group-9, password: wEWnHisK7UjPFwQ";
                await userManager.CreateAsync(user9, "pythonWorkshop$$9");

                user10 = new IdentityUser("Julia");
                user10.Email = "Julia@example.com";
                user10.PhoneNumber = "username: sls-group-10, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user10, "pythonWorkshop$$10");

                user11 = new IdentityUser("Kilo");
                user11.Email = "Kilo@example.com";
                user11.PhoneNumber = "username: sls-group-11, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user11, "pythonWorkshop$$11");

                user12 = new IdentityUser("Lima");
                user12.Email = "Lima@example.com";
                user12.PhoneNumber = "username: sls-group-12, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user12, "pythonWorkshop$$12");

                user13 = new IdentityUser("Manila");
                user13.Email = "Manila@example.com";
                user13.PhoneNumber = "username: sls-group-13, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user13, "pythonWorkshop$$13");

                user14 = new IdentityUser("North");
                user14.Email = "North@example.com";
                user14.PhoneNumber = "username: sls-group-14, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user13, "pythonWorkshop$$14");

                user15 = new IdentityUser("Oscar");
                user15.Email = "Oscar@example.com";
                user15.PhoneNumber = "username: sls-group-15, password: 0MLcWlcUlb89VBT";
                await userManager.CreateAsync(user13, "pythonWorkshop$$15");
            } 
        }
    }
}