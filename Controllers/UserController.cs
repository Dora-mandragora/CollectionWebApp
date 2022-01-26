using CollectionWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionWebApp.Controllers
{
    public class UserController : Controller
    {
        private UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Display()
        {
            var users = _context.Users;
            foreach (var user in users)
            {
                user.Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Users.Contains(user));
                user.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Users.Contains(user));
            }

            return View(users);
        }

        [HttpPost]
        public async Task<ActionResult> Define(int[] ids, string button)
        {
            if (button == "block_button") await Block(ids);
            if (button == "unblock_button") await Unblock(ids);
            if (button == "delete_button") await Delete(ids);
            if (button == "change_role_button") await ChangeRole(ids);
            return RedirectToAction("Display");
        }

        async Task<ActionResult> Block(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                el.Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == 2);
            }

            _context.SaveChanges();

            return Content("Ok");
        }
        async Task<ActionResult> Unblock(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                el.Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == 1);
            }

            _context.SaveChanges();

            return Content("Ok");
        }
        async Task<ActionResult> Delete(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                _context.Remove(el);
            }

            _context.SaveChanges();

            return Content("Ok");
        }

        async Task<ActionResult> ChangeRole(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                el.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == 1);
            }

            _context.SaveChanges();

            return Content("Ok");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
