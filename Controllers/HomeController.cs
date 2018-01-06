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
            var aSPressContext = _context.Posts
                                .Where(p => p.Status == "published")
                                .Include(p => p.Author);
            return View(await aSPressContext.OrderByDescending(i => i.DatePublish).ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                // // .Select(p => new 
                // // { 
                // //     p,
                // //     Comments = p.Comments
                // //     .Where(c => c.Status == "approved")
                // // })
                // .Select(p => new 
                // { 
                //     Posts=p,
                //     Comments = p.Comments.Where(c=>c.Status == "approved")                   
                // })
                // .SingleOrDefaultAsync(m => m.Posts.Id == id);
                
                .Include(p => p.Author)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }
        
        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateAsync([Bind("Email,Name,Comment,PostId,Date,Status")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return Json(comments);
            }
            return Json(comments);
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
