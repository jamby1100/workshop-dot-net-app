using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkshopApp .Models.ViewModels;
namespace WorkshopApp.Controllers {
    public class AccountController : Controller {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr,
                SignInManager<IdentityUser> signInMgr) {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [HttpGet("/login")]
        public ViewResult Login(string returnUrl) {
            return View(new LoginModel {
                Name = string.Empty, Password = string.Empty,
                ReturnUrl = returnUrl
            });
        }

        [HttpPost("/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel) {
            System.Console.WriteLine("This is entered");
            if (ModelState.IsValid) {
                IdentityUser? user = await userManager.FindByNameAsync(loginModel.Name);
                
                if (user != null) {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,loginModel.Password, false, false)).Succeeded) {
                        return Redirect(loginModel?.ReturnUrl ?? "/workshops");
                    }
                }
                
                ModelState.AddModelError("", "Invalid name or password");
            }
            return View(loginModel);
        }
        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/") {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
} }