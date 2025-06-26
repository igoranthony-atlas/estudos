using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Entities;
using SalesWebMvc.Interfaces;

namespace SalesWebMvc.Repositories;

public class SellerRepository : ISellerRepository
{
    private readonly SalesWebMvcContext _context;

    public SellerRepository(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task<Seller> GetByIdAsync(int id)
    {
        return await _context.Sellers
            .Include(s => s.Department) 
        .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Seller>> GetAllAsync()
    {
        return await _context.Sellers
            .Include(s => s.Department)
        .ToListAsync();
    }

    public async Task<Seller> CreateAsync(Seller seller)
    {
        _context.Sellers.Add(seller);
        await _context.SaveChangesAsync();
        return seller;
    }

    public async Task<Seller> UpdateAsync(Seller seller)
    {
        _context.Sellers.Update(seller);
        await _context.SaveChangesAsync();
        return seller;
    }

    public async Task DeleteAsync(Seller seller)
    {
        _context.Sellers.Remove(seller);
        await _context.SaveChangesAsync();
    }
    public async Task<Seller> GetByEmailAsync(string email)
    {
        return await _context.Sellers.FirstOrDefaultAsync(s => s.Email == email);
    }
}