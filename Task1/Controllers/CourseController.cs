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

    // get Course page and list them
    public async Task<IActionResult> Index()
    {
        // Include() loads the related Teacher so we can show teacher name
        var courses = await _context.Courses
            .Include(c => c.Teacher)
            .ToListAsync();
        return View(courses);
    }

    public async Task<IActionResult> Details(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();
        return View(course);
    }

    // get create course page
    public async Task<IActionResult> Create()
    {
        // Send teachers to the view for the dropdown list
        ViewBag.Teachers = await _context.Teachers.ToListAsync();
        return View();
    }

    // POST: create the course
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

    // GEt tthe edit page (send initail values)
    public async Task<IActionResult> Edit(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();

        // to display other teachers in the ddl
        ViewBag.Teachers = await _context.Teachers.ToListAsync();
        return View(course);
    }

    // POST: confirm edit
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

    // show delete screen 
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (course == null) return NotFound();
        return View(course);
    }

    // POST: delete
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