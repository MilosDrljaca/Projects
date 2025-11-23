using DataAccesLayer.Repositories.Interfaces;
using DataAccessLayer;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesLayer.Repositories;

public class ManagerRepository(ApplicationDbContext context) : IManagerRepository
{
    private readonly ApplicationDbContext _context = context;

    public List<Manager> GetAllActiveManagers()
    {
        return _context.Managers
            .AsNoTracking()
            .Where(m => m.Active > 0)
            .ToList();
    }

    public List<Manager> GetAllManagers()
    {
        return _context.Managers
            .AsNoTracking()
            .ToList();
    }

    public Manager CreateManager(Manager manager)
    {
        _context.Managers.Add(manager);
        _context.SaveChanges();
        return manager;
    }

    public Manager GetManagerByManagerName(string managerName)
    {
        return _context.Managers
            .AsNoTracking()
            .FirstOrDefault(m => m.ManagerName == managerName);
    }

    public Manager GetManagerById(int id)
    {
        return _context.Managers
            .AsNoTracking()
            .FirstOrDefault(m => m.ID_Manager == id);
    }

    public Manager Edit(Manager manager)
    {
        var existing = _context.Managers.FirstOrDefault(m => m.ID_Manager == manager.ID_Manager);

        if (existing == null)
            throw new Exception("Manager not found.");

        existing.ManagerName = manager.ManagerName;
        existing.Active = manager.Active;

        _context.SaveChanges();
        return existing;
    }
}
