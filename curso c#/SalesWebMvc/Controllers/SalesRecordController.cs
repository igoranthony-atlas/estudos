using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Entities;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SalesRecordController : Controller
{
    private readonly SalesRecordService _salesRecordService;
    private readonly SellerService _sellerService;
    public SalesRecordController(SalesRecordService salesRecordService, SellerService sellerService)
    {
        _salesRecordService = salesRecordService;
        _sellerService = sellerService;
    }
    public async Task<IActionResult> Index()
    {
        var salesRecords = await _salesRecordService.GetAllAsync();
        return View(salesRecords);
    }
    public async Task<IActionResult> Create()
    {
        var sellers = await _sellerService.GetAllAsync();
        ViewBag.Sellers = sellers;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SalesRecord salesRecord)
    {
        if (ModelState.IsValid)
        {
            await _salesRecordService.CreateAsync(salesRecord);
            return RedirectToAction(nameof(Index));
        }
        var sellers = await _sellerService.GetAllAsync();
        ViewBag.Sellers = sellers;
        return View(salesRecord);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var salesRecord = await _salesRecordService.GetByIdAsync(id);
        if (salesRecord == null)
        {
            return NotFound();
        }
        var sellers = await _sellerService.GetAllAsync();
        ViewBag.Sellers = sellers;
        return View(salesRecord);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SalesRecord salesRecord)
    {
        if (ModelState.IsValid)
        {
            await _salesRecordService.UpdateAsync(salesRecord);
            return RedirectToAction(nameof(Index));
        }
        var sellers = await _sellerService.GetAllAsync();
        ViewBag.Sellers = sellers;
        return View(salesRecord);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var salesRecord = await _salesRecordService.GetByIdAsync(id);
        if (salesRecord == null)
        {
            return NotFound();
        }
        return View(salesRecord);
    }
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var salesRecord = await _salesRecordService.GetByIdAsync(id);
        if (salesRecord == null)
        {
            return NotFound();
        }
        await _salesRecordService.DeleteAsync(salesRecord);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet, ActionName("Details")]
    public async Task<IActionResult> Details(int id)
    {
        var salesRecord = await _salesRecordService.GetByIdAsync(id);
        if (salesRecord == null)
        {
            return NotFound();
        }
        return View(salesRecord);
    }
    
}