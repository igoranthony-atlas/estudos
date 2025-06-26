using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Entities;
using SalesWebMvc.Interfaces;

namespace SalesWebMvc.Repositories;

public class SalesRecordRepository : ISalesRecordRepository
{
    private readonly SalesWebMvcContext _context;

    public SalesRecordRepository(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task<SalesRecord> GetByIdAsync(int id)
    {
        return await _context.SalesRecords
            .Include(sr => sr.Seller)  // Include related Seller entity
            .ThenInclude(sr => sr.Department)  // Include related Department entity
            .FirstOrDefaultAsync(sr => sr.Id == id)
        ;
    }

    public async Task<IEnumerable<SalesRecord>> GetAllAsync()
    {
        return await _context.SalesRecords
.Include(sr => sr.Seller)  // Include related Seller entity
            .ThenInclude(sr => sr.Department)
        .ToListAsync();
    }

    public async Task<IEnumerable<SalesRecord>> GetByDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        var query = _context.SalesRecords.AsQueryable();

        if (minDate.HasValue)
        {
            query = query.Where(sr => sr.Date >= minDate.Value);
        }
        if (maxDate.HasValue)
        {
            query = query.Where(sr => sr.Date <= maxDate.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<SalesRecord> CreateAsync(SalesRecord salesRecord)
    {
        _context.SalesRecords.Add(salesRecord);
        await _context.SaveChangesAsync();
        return salesRecord;
    }

    public async Task<SalesRecord> UpdateAsync(SalesRecord salesRecord)
    {
        _context.SalesRecords.Update(salesRecord);
        await _context.SaveChangesAsync();
        return salesRecord;
    }

    public async Task DeleteAsync(SalesRecord salesRecord)
    {
        _context.SalesRecords.Remove(salesRecord);
        await _context.SaveChangesAsync();
    }
}