using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers;

public class CourseController : Controller
{
    private readonly AppDbContext _context;

    public CourseController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /Course
    public async Task<IActionResult> Index()
    {
        // Include() loads the related Teacher so we can show teacher name
        var courses = await _context.Courses
            .Include(c => c.Teacher)
            .ToListAsync();
        return View(courses);
    }

    // GET: /Course/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();
        return View(course);
    }

    // GET: /Course/Create
    public async Task<IActionResult> Create()
    {
        // Send teachers list to the view for the dropdown
        ViewBag.Teachers = await _context.Teachers.ToListAsync();
        return View();
    }

    // POST: /Course/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseModel course)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Teachers = await _context.Teachers.ToListAsync();
            return View(course);
        }

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: /Course/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();

        ViewBag.Teachers = await _context.Teachers.ToListAsync();
        return View(course);
    }

    // POST: /Course/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CourseModel course)
    {
        if (id != course.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            ViewBag.Teachers = await _context.Teachers.ToListAsync();
            return View(course);
        }

        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: /Course/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();
        return View(course);
    }

    // POST: /Course/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}