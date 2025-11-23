using DataAccesLayer.Repositories.Interfaces;
using DomainModel;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services;

public class ManagerService(IManagerRepository managerRepository) : IManagerService
{
    private readonly IManagerRepository _repo = managerRepository;

    public Manager CreateManager(Manager manager)
    {
        if (string.IsNullOrWhiteSpace(manager.ManagerName))
            throw new ValidationServiceException("Manager name cannot be empty.");

        if (manager.Active < 0)
            throw new ValidationServiceException("Active flag must be 0 or 1.");

        if (_repo.GetManagerByManagerName(manager.ManagerName) != null)
            throw new ValidationServiceException(
                $"Manager '{manager.ManagerName}' already exists.");

        return _repo.CreateManager(manager);
    }

    public List<Manager> GetAllManagers() =>
        _repo.GetAllManagers();

    public List<Manager> GetAllActiveManagers() =>
        _repo.GetAllActiveManagers();

    public Manager GetManagerByManagerName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationServiceException("Manager name cannot be empty.");

        return _repo.GetManagerByManagerName(name);
    }

    public Manager GetManagerById(int id)
    {
        if (id <= 0)
            throw new ValidationServiceException("Invalid manager ID.");

        return _repo.GetManagerById(id);
    }

    public void Edit(Manager manager)
    {
        if (string.IsNullOrWhiteSpace(manager.ManagerName))
            throw new ValidationServiceException("Manager name cannot be empty.");

        _repo.Edit(manager);
    }
}
