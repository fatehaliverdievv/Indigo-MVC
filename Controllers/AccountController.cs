using indigo.Models;
using indigo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace indigo.Controllers
{
    public class AccountController:Controller
    {
        readonly UserManager<AppUser> _userManager ;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM registerVM) 
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            AppUser user = new AppUser { UserName = registerVM.Username, Name = registerVM.Name, Surname = registerVM.Surname, Email = registerVM.Email };
            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
            if(!result.Succeeded) 
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(loginVm.UsernameorEmail);
            if (user == null)
            {
                user=await _userManager.FindByNameAsync(loginVm.UsernameorEmail);
                if (user == null) 
                {
                    ModelState.AddModelError("", "ur username and password invalid");
                    return View();
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user,loginVm.Password,true,true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "ur username and password invalid");
                return View();
            }
            return RedirectToAction("Index","Home");
        }
    }
}
