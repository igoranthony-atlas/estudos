using SalesWebMvc.Entities;
using SalesWebMvc.Interfaces;

namespace SalesWebMvc.Services;

public class SalesRecordService
{
    private readonly ISalesRecordRepository _salesRecordRepository;

    public SalesRecordService(ISalesRecordRepository salesRecordRepository)
    {
        _salesRecordRepository = salesRecordRepository;
    }

    public async Task<SalesRecord> GetByIdAsync(int id)
    {
        return await _salesRecordRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<SalesRecord>> GetAllAsync()
    {
        return await _salesRecordRepository.GetAllAsync();
    }

    public async Task<IEnumerable<SalesRecord>> GetByDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        return await _salesRecordRepository.GetByDateAsync(minDate, maxDate);
    }

    public async Task<SalesRecord> CreateAsync(SalesRecord salesRecord)
    {
        return await _salesRecordRepository.CreateAsync(salesRecord);
    }

    public async Task<SalesRecord> UpdateAsync(SalesRecord salesRecord)
    {
        return await _salesRecordRepository.UpdateAsync(salesRecord);
    }

    public async Task DeleteAsync(SalesRecord salesRecord)
    {
        await _salesRecordRepository.DeleteAsync(salesRecord);
    }
}