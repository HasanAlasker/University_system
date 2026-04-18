using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers;

public class EnrollmentController : Controller
{
    private readonly AppDbContext _context;

    public EnrollmentController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var enrollments = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();
        return View(enrollments);
    }

    public async Task<IActionResult> Details(int id)
    {
        var enrollment = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (enrollment == null) return NotFound();
        return View(enrollment);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Students = await _context.Students.ToListAsync();
        ViewBag.Courses = await _context.Courses.ToListAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EnrollmentModel enrollment)
    {
        // check for duplicate enrollment
        bool alreadyEnrolled = await _context.Enrollments
            .AnyAsync(e => e.StudentId == enrollment.StudentId
                        && e.CourseId == enrollment.CourseId);

        if (alreadyEnrolled)
        {
            ModelState.AddModelError("", "This student is already enrolled in this course.");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Students = await _context.Students.ToListAsync();
            ViewBag.Courses = await _context.Courses.ToListAsync();
            return View(enrollment);
        }

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
        if (enrollment == null) return NotFound();

        ViewBag.Students = await _context.Students.ToListAsync();
        ViewBag.Courses = await _context.Courses.ToListAsync();
        return View(enrollment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EnrollmentModel enrollment)
    {
        if (id != enrollment.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            ViewBag.Students = await _context.Students.ToListAsync();
            ViewBag.Courses = await _context.Courses.ToListAsync();
            return View(enrollment);
        }

        _context.Enrollments.Update(enrollment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var enrollment = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (enrollment == null) return NotFound();
        return View(enrollment);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
        if (enrollment == null) return NotFound();

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}