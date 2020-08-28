using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IManagerService
    {
        public List<Manager> GetAllManagers();
        public Manager CreateManager(Manager manager);
        public Manager GetManagerByManagerName(string managerName);
        public Manager GetManagerById(int id);
        public List<Manager> GetAllActiveManagers();
        public void Edit(Manager manager);
    }

}
