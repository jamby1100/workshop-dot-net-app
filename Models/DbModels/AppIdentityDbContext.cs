using Microsoft.AspNetCore.Identity;
       using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
       using Microsoft.EntityFrameworkCore;
       namespace WorkshopApp.Models {
           public class AppIdentityDbContext : IdentityDbContext<IdentityUser> {
               public AppIdentityDbContext(
                       DbContextOptions<AppIdentityDbContext> options)
                   : base(options) { }
} }