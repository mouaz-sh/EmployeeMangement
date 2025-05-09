
using EmployeeMangement.Models.accountviewmodel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Medical.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<IdentityUser> usermanger;
        private readonly RoleManager<IdentityRole> rolemanger;
        private readonly SignInManager<IdentityUser> signInManager;

        public Account(UserManager<IdentityUser> usermanger, RoleManager<IdentityRole> rolemanger,
            SignInManager<IdentityUser> signInManager)
        {
            this.usermanger = usermanger;
            this.rolemanger = rolemanger;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm register)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();

                user.UserName = register.Name;
                user.Email = register.Email;

                var result = await usermanger.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, false);
                    return RedirectToAction(nameof(Login));

                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }


            }
            return View(register);


        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(loginVm register)
        {
            if (ModelState.IsValid)
            {
                var result = await usermanger.FindByNameAsync(register.Name);

                if (!(result is null))
                {

                    var Found = await usermanger.CheckPasswordAsync(result, register.Password);
                    if (Found)
                    {
                        await signInManager.SignInAsync(result, register.Rememberme);
                        return RedirectToAction("Index", "home");

                    }


                    ModelState.AddModelError("", "the pass or user is not valid");

                }

            }
            return View(register);

        }
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
