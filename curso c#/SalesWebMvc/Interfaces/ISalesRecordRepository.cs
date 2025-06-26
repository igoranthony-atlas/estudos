using SalesWebMvc.Entities;

namespace SalesWebMvc.Interfaces;
public interface ISalesRecordRepository
{
    Task<SalesRecord> GetByIdAsync(int id);
    Task<IEnumerable<SalesRecord>> GetAllAsync();
    Task<IEnumerable<SalesRecord>> GetByDateAsync(DateTime? minDate, DateTime? maxDate);
    Task<SalesRecord> CreateAsync(SalesRecord salesRecord);
    Task<SalesRecord> UpdateAsync(SalesRecord salesRecord);
    Task DeleteAsync(SalesRecord salesRecord);
}