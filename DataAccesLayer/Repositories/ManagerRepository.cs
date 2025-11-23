using DataAccesLayer.Repositories.Interfaces;
using DataAccessLayer;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.Repositories;

public class ManagerRepository : IManagerRepository
{
    private readonly ApplicationDbContext _context;

    public ManagerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Manager> GetAllActiveManagers()
    {
        List<Manager> managers = _context.Managers.ToList();

        List<Manager> activeManagers = managers.Where(a => a.Active > 0).ToList();
        _context.SaveChanges();
        return activeManagers;
    }

    public List<Manager> GetAllManagers()
    {
        List<Manager> managers = _context.Managers.ToList();
        _context.SaveChanges();
        return managers;
    }

    public Manager CreateManager(Manager manager)
    {
        _context.Managers.Add(manager);
        _context.SaveChanges();
        return manager;
    }

    public Manager GetManagerByManagerName(string managerName)
    {
        Manager manager = _context.Managers.Find(managerName);
        _context.SaveChanges();
        return manager;
    }

    public Manager GetManagerById(int id)
    {
        Manager manager = _context.Managers.Where(p => p.ID_Manager == id).FirstOrDefault();
        _context.SaveChanges();
        return manager;
    }

    public Manager Edit(Manager manager)
    {
        _context.Entry(manager).State = EntityState.Modified;
        _context.SaveChanges();
        return manager;
    }
}
