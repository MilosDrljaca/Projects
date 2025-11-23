using DataAccesLayer.CustomExceptions;
using DataAccesLayer.Repositories.Interfaces;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Project Create(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
        return project;
    }

    public void Delete(Project project)
    {
        _context.Projects.Remove(project);
        _context.SaveChanges();
    }

    public Project GetProjectById(int id)
    {
        Project project = _context.Projects.Where(p => p.ID_Project == id).FirstOrDefault();
        _context.SaveChanges();
        return project;
    }

    public Project GetProjectByProjectName(string ProjectName)
    {
        Project project = _context.Projects.FirstOrDefault(m => m.ProjectName == ProjectName);

        _context.SaveChanges();
        return project;
    }

    public List<Project> GetAllProjects()
    {
        List<Project> projects = _context.Projects.ToList();
        _context.SaveChanges();
        return projects;
    }
    public Project Edit(Project project)
    {
        _context.Entry(project).State = EntityState.Modified;
        _context.SaveChanges();
        return project;
    }

    public bool DoesProjectExist(string ProjectName)
    {
        try
        {
            bool result = _context.Projects.Any(i => i.ProjectName == ProjectName);
            _context.SaveChanges();
            return result;
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Communication with database failed. Project with this Name = " + ProjectName + ", already exists in database.", ex);
        }
    }
}
