using DataAccesLayer.CustomExceptions;
using DataAccessLayer;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccesLayer.Repositories
{
    public class ManagerRepo
    {
        public List<Manager> GetAllActiveManagers()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                List<Manager> managers = context.Managers.ToList();

                List<Manager> activeManagers = managers.Where(a => a.Active > 0).ToList();
                context.SaveChanges();
                return activeManagers;
            }
        }

        public List<Manager> GetAllManagers()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                List<Manager> managers = context.Managers.ToList();
                context.SaveChanges();
                return managers;
            }
        }
        public Manager CreateManager(Manager manager)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Managers.Add(manager);
                context.SaveChanges();
                return manager;
            }
        }

        public Manager GetManagerByManagerName(string managerName)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Manager manager = context.Managers.Find(managerName);
                context.SaveChanges();
                return manager;
            }
        }

        public Manager GetManagerById(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Manager manager = context.Managers.Find(id);
                context.SaveChanges();
                return manager;
            }
        }
    }
}
