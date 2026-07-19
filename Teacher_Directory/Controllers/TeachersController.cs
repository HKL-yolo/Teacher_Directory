using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Teacher_Directory.Areas.Identity.Data;
using Teacher_Directory.Models;
using Teacher_Directory.ViewModels;

namespace Teacher_Directory.Controllers
{
    public class TeachersController : Controller
    {
        private readonly DBContext _context;

        public TeachersController(DBContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var teachers = await _context.Teacher
        .Include(t => t.Department)
        .Include(t => t.Course)
            .ThenInclude(c => c.Subject)
        .ToListAsync();

            return View(teachers);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .Include(t => t.Department)
                .Include(t => t.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department.OrderBy(d => d.DepartmentName), "Id", "DepartmentName");

            ViewBag.PositionList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Assistant Head", Text = "Assistant Head" },
                new SelectListItem { Value = "Dean", Text = "Dean" },
                new SelectListItem { Value = "Head of Department", Text = "Head of Department" },
                new SelectListItem { Value = "Senior Teacher", Text = "Senior Teacher" },
                new SelectListItem { Value = "Teacher", Text = "Teacher" }
            };
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Id,Email,Firstname,Lastname,OfficeLocation,Gender,DepartmentId,Position")]
        Teacher teacher,
        IFormFile PhotoFile)
        {
            ModelState.Remove(nameof(Teacher.Teachercode));

            if (ModelState.IsValid)
            {
                string teacherCode = (teacher.Firstname.Substring(0, 1) + teacher.Lastname.Substring(0, 2)).ToUpper();
                teacher.Teachercode = teacherCode;

                if (PhotoFile != null)
                {
                    string fileName = Guid.NewGuid().ToString()
                                      + Path.GetExtension(PhotoFile.FileName);

                    string path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images",
                        fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await PhotoFile.CopyToAsync(stream);
                    }

                    teacher.PhotoURL = "/images/" + fileName;
                }

                _context.Add(teacher);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] =
                new SelectList(_context.Department,
                "Id",
                "DepartmentName",
                teacher.DepartmentId);

            ViewBag.PositionList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Head of Department", Text = "Head of Department" },
                new SelectListItem { Value = "Senior Teacher", Text = "Senior Teacher" },
                new SelectListItem { Value = "Teacher", Text = "Teacher" },
                new SelectListItem { Value = "Assistant Head", Text = "Assistant Head" },
                new SelectListItem { Value = "Dean", Text = "Dean" }
            };

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", teacher.DepartmentId);

            ViewBag.PositionList = new List<SelectListItem>
            {
                new SelectListItem { Value = "Senior Teacher", Text = "Senior Teacher" },
                new SelectListItem { Value = "Teacher", Text = "Teacher" },
                new SelectListItem { Value = "Head of Department", Text = "Head of Department" },
                new SelectListItem { Value = "Assistant Head", Text = "Assistant Head" },
                new SelectListItem { Value = "Dean", Text = "Dean" }
            };
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Teachercode,Email,Firstname,Lastname,OfficeLocation,Gender,DepartmentId,Position")] Teacher teacher, IFormFile? PhotoFile)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingTeacher = await _context.Teacher.FindAsync(id);
                    if (existingTeacher == null)
                    {
                        return NotFound();
                    }

                    // Make sure that only modify part are updated
                    existingTeacher.Teachercode = teacher.Teachercode;
                    existingTeacher.Email = teacher.Email;
                    existingTeacher.Firstname = teacher.Firstname;
                    existingTeacher.Lastname = teacher.Lastname;
                    existingTeacher.Gender = teacher.Gender;
                    existingTeacher.DepartmentId = teacher.DepartmentId;
                    existingTeacher.Position = teacher.Position;

                    if (PhotoFile != null)
                    {
                        string fileName = Guid.NewGuid().ToString()
                                          + Path.GetExtension(PhotoFile.FileName);

                        string path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images",
                            fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await PhotoFile.CopyToAsync(stream);
                        }

                        existingTeacher.PhotoURL = "/images/" + fileName;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", teacher.DepartmentId);
            return View(teacher);
        }
        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .Include(t => t.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher != null)
            {
                _context.Teacher.Remove(teacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
