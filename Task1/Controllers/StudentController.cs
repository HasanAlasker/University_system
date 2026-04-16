using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers;

public class StudentController : Controller
{
    private readonly AppDbContext _context;

    public StudentController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /Student
    public async Task<IActionResult> Index()
    {
        var students = await _context.Students.ToListAsync();
        return View(students);
    }

    // GET: /Student/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        if (student == null) return NotFound();
        return View(student);
    }

    // GET: /Student/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Student/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentModel student)
    {
        if (!ModelState.IsValid) return View(student);

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: /Student/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // POST: /Student/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, StudentModel student)
    {
        if (id != student.Id) return BadRequest();
        if (!ModelState.IsValid) return View(student);

        _context.Students.Update(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: /Student/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // POST: /Student/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}