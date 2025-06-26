using SalesWebMvc.Entities;
using SalesWebMvc.Exceptions;
using SalesWebMvc.Interfaces;

namespace SalesWebMvc.Services;
public class SellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<Seller> GetByIdAsync(int id)
    {
        var seller = await _sellerRepository.GetByIdAsync(id);
        return  seller ?? throw new NotFoundException("Seller");
    }

    public async Task<IEnumerable<Seller>> GetAllAsync()
    {
        return await _sellerRepository.GetAllAsync();
    }

    public async Task<Seller> CreateAsync(Seller seller)
    {
        if (await _sellerRepository.GetByEmailAsync(seller.Email) != null)
        {
            throw new AlreadyRegisteredException("Seller");
        }
        return await _sellerRepository.CreateAsync(seller);
    }

    public async Task<Seller> UpdateAsync(Seller seller)
    {
        var existingSeller = await _sellerRepository.GetByIdAsync(seller.Id);
        if (existingSeller == null)
        {
            throw new NotFoundException("Seller");
        }
        existingSeller.Name = seller.Name;
        existingSeller.Email = seller.Email;
        existingSeller.BirthDate = seller.BirthDate;
        existingSeller.BaseSalary = seller.BaseSalary;
        existingSeller.DepartmentId = seller.DepartmentId;
        return await _sellerRepository.UpdateAsync(existingSeller);
    }

    public async Task DeleteAsync(Seller seller)
    {
        var existingSeller = await _sellerRepository.GetByIdAsync(seller.Id);
        if (existingSeller == null)
        {
            throw new NotFoundException("Seller");
        }
        await _sellerRepository.DeleteAsync(existingSeller);
    }
}