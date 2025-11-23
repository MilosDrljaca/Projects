using DataAccesLayer.Repositories.Interfaces;
using DomainModel;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services;

public class ManagerService : IManagerService
{
    private readonly IManagerRepository _managerRepository;

    public ManagerService(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }
    public List<Manager> GetAllManagers()
    {
        return _managerRepository.GetAllManagers();
    }

    public List<Manager> GetAllActiveManagers()
    {
        return _managerRepository.GetAllActiveManagers();
    }

    public Manager CreateManager(Manager manager)
    {
        _managerRepository.CreateManager(manager);
        return manager;
    }

    public Manager GetManagerByManagerName(string managerName)
    {
        return _managerRepository.GetManagerByManagerName(managerName);
    }

    public Manager GetManagerById(int id)
    {
        return _managerRepository.GetManagerById(id);
    }

    public void Edit(Manager manager)
    {
        _managerRepository.Edit(manager);
    }
}
