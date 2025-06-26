using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Entities;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;
    private readonly DepartmentService _departmentService;
    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
        _sellerService = sellerService;
        _departmentService = departmentService;
    }
    public async Task<IActionResult> Index()
    {
        var sellers = await _sellerService.GetAllAsync();
        return View(sellers);
    }
    public async Task<IActionResult> Create()
    {
        var departments = await _departmentService.GetAllAsync();
        ViewBag.Departments = departments;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Seller seller)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _sellerService.CreateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        var departments = await _departmentService.GetAllAsync();
        ViewBag.Departments = departments;
        return View(seller);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var seller = await _sellerService.GetByIdAsync(id);
        if (seller == null)
        {
            return NotFound();
        }
        var departments = await _departmentService.GetAllAsync();
        ViewBag.Departments = departments;
        return View(seller);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Seller seller)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        var departments = await _departmentService.GetAllAsync();
        ViewBag.Departments = departments;
        return View(seller);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var seller = await _sellerService.GetByIdAsync(id);
        if (seller == null)
        {
            return NotFound();
        }
        return View(seller);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var seller = await _sellerService.GetByIdAsync(id);
        if (seller == null)
        {
            return NotFound();
        }
        try
        {
            await _sellerService.DeleteAsync(seller);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(seller);
        }
    }
    [HttpGet, ActionName("Details")]
    public async Task<IActionResult> Details(int id)
    {
        var seller = await _sellerService.GetByIdAsync(id);
        if (seller == null)
        {
            return NotFound();
        }
        return View(seller);
    }
}