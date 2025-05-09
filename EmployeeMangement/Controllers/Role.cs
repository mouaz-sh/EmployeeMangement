
using EmployeeMangement.Models.accountviewmodel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Controllers
{
    public class Role : Controller
    {
        private readonly UserManager<IdentityUser> usermanger;
        private readonly RoleManager<IdentityRole> rolemanger;
        private readonly SignInManager<IdentityUser> signInManager;

        public Role(UserManager<IdentityUser> usermanger, RoleManager<IdentityRole> rolemanger,
            SignInManager<IdentityUser> signInManager)
        {
            this.usermanger = usermanger;
            this.rolemanger = rolemanger;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleVm role)
        {
            IdentityRole rol = new IdentityRole();
            rol.Name = role.RoleName;

            await rolemanger.CreateAsync(rol);


            return RedirectToAction("Index", "Empolyees");
        }
        [HttpGet]

        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterVm register)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();

                user.UserName = register.Name;
                user.Email = register.Email;

                var result = await usermanger.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await usermanger.AddToRoleAsync(user, "admin");
                   // await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Login", "Account");

                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }


            }
            return View(register);


        }
    }


}

