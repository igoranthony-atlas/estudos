using SalesWebMvc.Entities;

namespace SalesWebMvc.Interfaces;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(int id);
    Task<IEnumerable<Department>> GetAllAsync();
    Task<Department> CreateAsync(Department department);
    Task<Department> UpdateAsync(Department department);
    Task DeleteAsync(Department department);
    Task<Department> GetByNameAsync(string name);
}