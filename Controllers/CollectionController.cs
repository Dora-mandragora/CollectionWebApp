using CollectionWebApp.Models;
using CollectionWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionWebApp.Controllers
{
    public class CollectionController : Controller
    {
        private UserContext _context;
        private IWebHostEnvironment _hostingEnv;
        
        public CollectionController(UserContext context, IWebHostEnvironment env)
        {
            _context = context;
            _hostingEnv = env;             
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Topics = _context.Topics.ToList();            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CollectionModel model)
        {
            //ViewBag.Topics = _context.Topics.ToList();
            var user = _context.Users.FirstOrDefault(u => u.Login == User.Identity.Name);
            ViewBag.User = user;
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if (model.Image != null)
                    using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Image.Length);
                    }
                var collection = new Collection
                {
                    Name = model.Name,
                    Description = model.Description,
                    Topic = await _context.Topics.FirstOrDefaultAsync(t => t.Name == model.Topic),
                    Image = imageData,
                    User = ViewBag.User
                };
                _context.Collections.Add(collection);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var col = _context.Collections.FirstOrDefault(c => c.Id == id);
            _context.Collections.Remove(col);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UploadImage(IFormFile file)
        {            
            var FileDic = "Files";
            string filePath = Path.Combine(_hostingEnv.WebRootPath, FileDic);
            if(!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            var fileName = file.FileName;
            var FilePath = Path.Combine(filePath, fileName);
            using (FileStream fs = System.IO.File.Create(FilePath))
            {
                file.CopyTo(fs);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Display(int? id)
        {
            var collection = await _context.Collections.FirstOrDefaultAsync(c => c.Id == id);
            collection.Items =  _context.Items
                .Where(i => i.Collection == collection).ToList();
            collection.Topic = await _context.Topics.FirstOrDefaultAsync(t => t.Collections.Contains(collection));

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Collections.Contains(collection));
            collection.User = user;
            return View(collection);
        }
        [HttpPost]
        public IActionResult Display()
        {            
            return View();
        }

        public ActionResult GetImage(int id)
        {
            var collection = _context.Collections.FirstOrDefault(c => c.Id == id);
            byte[] bytes = collection.Image; //Get the image from your database
            if (bytes == null) return null; //поставить картинку по умолчанию
            else return File(bytes, "image/png"); //or "image/jpeg", depending on the format
        }
    }
}
