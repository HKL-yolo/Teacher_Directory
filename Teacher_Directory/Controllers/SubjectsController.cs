using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teacher_Directory.Areas.Identity.Data;
using Teacher_Directory.Models;
using Teacher_Directory.ViewModels;

namespace Teacher_Directory.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly DBContext _context;

        public SubjectsController(DBContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var subjects = await _context.Subject
            .Select(s => new SubjectIndexViewModels
            {
                Id = s.Id,
                SubjectName = s.SubjectName,
                DepartmentName = s.Department!.DepartmentName,
                CourseCount = s.Course.Count()
            })
            .ToListAsync();

            return View(subjects);
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department.OrderBy(d => d.DepartmentName),
            "Id", "DepartmentName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectName,DepartmentId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = new SelectList(_context.Department.OrderBy(d => d.DepartmentName),
            "Id", "DepartmentName");
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department.OrderBy(d => d.DepartmentName),
            "Id", "DepartmentName");
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectName,DepartmentId")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subject.FindAsync(id);

            if (subject != null)
            {
                // Find courses using this subject
                var courses = await _context.Course
                    .Where(c => c.SubjectId == id)
                    .ToListAsync();

                // Keep the courses, only remove their subject
                foreach (var course in courses)
                {
                    course.SubjectId = null;
                }

                // Save first so no Course references this Subject
                await _context.SaveChangesAsync();

                // Delete only the subject
                _context.Subject.Remove(subject);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.Id == id);
        }
    }
}
