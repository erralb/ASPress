using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPress.Models;

namespace ASPress.Controllers
{
    public class TermsController : Controller
    {
        private readonly ASPressContext _context;

        public TermsController(ASPressContext context)
        {
            _context = context;
        }

        // GET: Terms
        public async Task<IActionResult> Index()
        {
            var aSPressContext = _context.Terms.Include(t => t.Parent);
            return View(await aSPressContext.ToListAsync());
        }

        // GET: Terms/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terms = await _context.Terms
                .Include(t => t.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (terms == null)
            {
                return NotFound();
            }

            return View(terms);
        }

        // GET: Terms/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.Terms, "Id", "Name");
            return View();
        }

        // POST: Terms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostType,Name,Url,ParentId,ImageId")] Terms terms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Terms, "Id", "Name", terms.ParentId);
            return View(terms);
        }

        // GET: Terms/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terms = await _context.Terms.SingleOrDefaultAsync(m => m.Id == id);
            if (terms == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.Terms, "Id", "Name", terms.ParentId);
            return View(terms);
        }

        // POST: Terms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PostType,Name,Url,ParentId,ImageId")] Terms terms)
        {
            if (id != terms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermsExists(terms.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.Terms, "Id", "Name", terms.ParentId);
            return View(terms);
        }

        // GET: Terms/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terms = await _context.Terms
                .Include(t => t.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (terms == null)
            {
                return NotFound();
            }

            return View(terms);
        }

        // POST: Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var terms = await _context.Terms.SingleOrDefaultAsync(m => m.Id == id);
            _context.Terms.Remove(terms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermsExists(long id)
        {
            return _context.Terms.Any(e => e.Id == id);
        }
    }
}
