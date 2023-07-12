using fiorello_project.Attributes;
using fiorello_project.Models;
using fiorello_project.ViewModels.MyAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace fiorello_project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager; //user yaratmaq ucundur
        private readonly SignInManager<User> _signInManager; // userin login olmasi ucundur

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [OnlyAnonymous]
        public IActionResult Register()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("index", "Home");
            //}

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User
            {
                FullName=model.Fullname,
                Email = model.Email,
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            return RedirectToAction("login");
        }

        [HttpGet]
        [OnlyAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return View(model);
            }

            var result= await _signInManager.PasswordSignInAsync(user,model.Password, false,false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is incorrect");
                return View(model);
            }
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }


        [HttpGet]
    
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
    }
}
