using CollectionWebApp.Models;
using CollectionWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CollectionWebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserContext _context;
        public AccountController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //----
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == Hash.GetHashString(model.Password));
                //---
                if (user != null)
                {
                    user.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Users.Contains(user));
                    user.Status = await _context.Statuses.FirstOrDefaultAsync(r => r.Users.Contains(user));
                    await Authenticate(user);
                    user.LastLoginDate = System.DateTime.Now;
                    _context.SaveChanges();
                    //---
                    if (user.Status.Id == 2)                    
                        ModelState.AddModelError("", "Пользователь заблокирован");
                    else
                        return RedirectToAction("", "Home");                  
                    
                }
                else ModelState.AddModelError("", "Неверный логин или пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //--
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (user == null)
                {
                    user = new User
                    {
                        Login = model.Login,
                        Email = model.Email,
                        RegistrationDate = System.DateTime.Now,
                        Password = Hash.GetHashString(model.Password),
                        LastLoginDate = System.DateTime.Now,
                        Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == 1),
                        ItemHistory = new ItemHistory { User = user }
                    };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)                    
                        user.Role = userRole;                       
                    
                    //----
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    await Authenticate(user);
                    return RedirectToAction("", "Home");
                }
                ModelState.AddModelError("", "Неверный логин или пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("", "Home");
        }
    }
}
