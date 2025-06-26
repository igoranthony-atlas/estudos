using SalesWebMvc.Entities;
using SalesWebMvc.Exceptions;
using SalesWebMvc.Interfaces;

namespace SalesWebMvc.Services;

public class DepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        return department ?? throw new NotFoundException("Departamento");
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    public async Task<Department> CreateAsync(Department department)
    {
        var existingDepartment = await _departmentRepository.GetByNameAsync(department.Name);
        if (existingDepartment != null)
        {
            throw new AlreadyRegisteredException("Departamento");
        }
        return await _departmentRepository.CreateAsync(department);
    }

    public async Task<Department> UpdateAsync(Department department)
    {
        var existingDepartment = await _departmentRepository.GetByIdAsync(department.Id);
        if (existingDepartment == null)
        {
            throw new NotFoundException("Departamento");
        }
        existingDepartment.Name = department.Name;
        return await _departmentRepository.UpdateAsync(existingDepartment);
    }

    public async Task DeleteAsync(int id)
    {
        var existingDepartment = await _departmentRepository.GetByIdAsync(id);
        if (existingDepartment == null)
        {
            throw new NotFoundException("Departamento");
        }
        await _departmentRepository.DeleteAsync(existingDepartment);
    }
    public async Task<Department> GetByNameAsync(string name)
    {
        var department =  await _departmentRepository.GetByNameAsync(name);
        return department ?? throw new NotFoundException("Departamento");
    }
}