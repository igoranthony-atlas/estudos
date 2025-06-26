using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Entities;  // Supondo que Department está aqui

namespace SalesWebMvc.Controllers;

public class DepartmentsController : Controller
{
    private readonly DepartmentService _departmentService;

    public DepartmentsController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // GET: /Department/
    public async Task<IActionResult> Index()
    {
        var list = await _departmentService.GetAllAsync();
        return View(list); // Passa a lista para a view
    }

    // GET: /Department/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    // GET: /Department/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Department/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department)
    {
        if (ModelState.IsValid)
        {
            await _departmentService.CreateAsync(department);
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: /Department/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    // POST: /Department/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _departmentService.UpdateAsync(department);
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: /Department/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    // POST: /Department/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _departmentService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
