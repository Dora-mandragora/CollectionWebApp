using CollectionWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionWebApp.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            ViewBag.User = user;
            ViewBag.User.Role = await _context.Roles.FirstOrDefaultAsync(u => u.Users.Contains(user));
            ViewBag.Collections = _context.Collections
                .Where(c => c.User == user)
                .ToList();
            return View();            
        }        
        
        public async Task<IActionResult> Display(int? id)
        {
            User user = null;
            if (id != null)
                user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            else if (User.Identity.IsAuthenticated)
                user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            else return RedirectToAction("");
            ViewBag.User = user;
            ViewBag.User.Role = await _context.Roles.FirstOrDefaultAsync(u => u.Users.Contains(user));
            var colls = _context.Collections
                .Where(c => c.User == user)
                .ToList();
            foreach(var col in colls)
                col.Items = _context.Items
                    .Where(i => i.Collection == col)
                    .ToList();
            colls = colls.OrderByDescending(e => e.Items.Count).ToList();
            if (colls.Count > 5) colls = colls.GetRange(0, 5);
            ViewBag.Collections = colls;  
            var history = await _context.ItemHistories.FirstOrDefaultAsync(h => h.Id == user.Id);
            history.Items = _context.Items
                .Where(i => i.ItemHistory == history)
                .OrderByDescending(i => i.Id)
                .ToList();
            ViewBag.History = history;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
