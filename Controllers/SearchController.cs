using CollectionWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionWebApp.Controllers
{
    public class SearchController : Controller
    {
        private UserContext _context;
        public SearchController(UserContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchText)
        {            
            var searchItems = new List<Item>();
            var searchComments = _context.Comments
                .Where(c => c.Content.Contains(searchText))                
                .ToList();
            foreach (var el in searchComments)
                el.Item = await _context.Items.FirstOrDefaultAsync(i => i.Comments.Contains(el));

            var searchCollections = _context.Collections
                .Where(c => c.Description
                .Contains(searchText)).ToList();

            return View(searchComments.Select(c => c.Item).ToList());
        }
    }
}
