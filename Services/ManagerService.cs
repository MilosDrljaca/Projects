using DataAccesLayer.CustomExceptions;
using DataAccesLayer.Repositories;
using DomainModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ManagerService : IManagerService

    {
        public List<Manager> GetAllManagers()
        {
            ManagerRepo managerRepository = new ManagerRepo();
            List<Manager> managers = managerRepository.GetAllManagers();
            return managers;
        }

        public List<Manager> GetAllActiveManagers()
        {
            ManagerRepo managerRepository = new ManagerRepo();
            List<Manager> managers = managerRepository.GetAllActiveManagers();
            return managers;
        }

        public Manager CreateManager(Manager manager)
        {
                ManagerRepo managerRepository = new ManagerRepo();
                managerRepository.CreateManager(manager);
                return manager;
        }

        public Manager GetManagerByManagerName(string managerName)
        {
            ManagerRepo ManagerRepository = new ManagerRepo();
            Manager manager = ManagerRepository.GetManagerByManagerName(managerName);
            return manager;
        }

        public Manager GetManagerById(int id)
        {
            ManagerRepo ManagerRepository = new ManagerRepo();
            Manager manager = ManagerRepository.GetManagerById(id);
            return manager;
        }

    }
}
