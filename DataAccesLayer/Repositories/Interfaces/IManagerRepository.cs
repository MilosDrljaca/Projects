using DomainModel;
using System.Collections.Generic;

namespace DataAccesLayer.Repositories.Interfaces;

public interface IManagerRepository
{
    List<Manager> GetAllActiveManagers();
    List<Manager> GetAllManagers();
    Manager CreateManager(Manager manager);
    Manager GetManagerByManagerName(string managerName);
    Manager GetManagerById(int id);
    Manager Edit(Manager manager);
}
