using SalesWebMvc.Entities;

namespace SalesWebMvc.Interfaces;

public interface ISellerRepository
{
    Task<Seller> GetByIdAsync(int id);
    Task<IEnumerable<Seller>> GetAllAsync();
    Task<Seller> CreateAsync(Seller seller);
    Task<Seller> UpdateAsync(Seller seller);
    Task DeleteAsync(Seller seller);
    Task<Seller> GetByEmailAsync(string email);
}