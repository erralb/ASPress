using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPress.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ASPressContext _context;

        public HomeController(ASPressContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var aSPressContext = _context.Posts.Include(p => p.Author);
            return View(await aSPressContext.OrderByDescending(i => i.DatePublish).ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .Include(p => p.Author)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
