using CollectionWebApp.Models;
using CollectionWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionWebApp.Controllers
{
    public class ItemController : Controller
    {
        private UserContext _context;       
        public ItemController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            ViewBag.Collection = _context.Collections.FirstOrDefault(c => c.Id == id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ItemModel model, int id)
        {
            Collection col = _context.Collections.FirstOrDefault(c => c.Id == id);
            if(ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
                user.ItemHistory = await _context.ItemHistories.FirstOrDefaultAsync(h => h.Id == user.Id);
                var item = new Item
                {
                    Name = model.Name,
                    Collection = col,
                    ItemHistory = user.ItemHistory
                };
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Display", "Collection", new { id = col.Id });

        }

        [HttpGet]
        public async Task<IActionResult> Display(int? id)
        {
            Item item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            item.Comments = _context.Comments
                .Where(c => c.Item == item)
                .ToList();
            return View(item);
        }

        [HttpPost]
        public IActionResult Display()
        {
            return View();
        }

        public async Task<IActionResult> AddComment(string text, int? id)
        {
            if(text != null && id != null)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
                if (user == null) return RedirectToAction("Index", "Home");
                Item item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
                var com = new Comment
                {
                    Content = text,
                    FromUser = user.Id,
                    Item = item
                };
                _context.Comments.Add(com);
                await _context.SaveChangesAsync();
            }            
            return RedirectToAction("Display", new { id = id });
        }

        public IActionResult Comments()
        {
            return PartialView("_Comments");
        }

        public async Task<IActionResult> Delete (int[] ids, int bid)
        {
            foreach(var id in ids)
            {
                Item item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
                _context.Items.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Display", "Collection", new { id = bid });
        }
    }
}
