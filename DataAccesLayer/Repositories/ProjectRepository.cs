using DataAccesLayer.CustomExceptions;
using DataAccesLayer.Repositories.Interfaces;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories;

public class ProjectRepository(ApplicationDbContext context) : IProjectRepository
{
    private readonly ApplicationDbContext _context = context;

    public Project Create(Project project)
    {
        try
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Failed to create project.", ex);
        }
    }

    public void Delete(Project project)
    {
        try
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Failed to delete project.", ex);
        }
    }

    public Project GetProjectById(int id)
    {
        return _context.Projects
            .AsNoTracking()
            .FirstOrDefault(p => p.ID_Project == id);
    }

    public Project GetProjectByProjectName(string projectName)
    {
        return _context.Projects
            .AsNoTracking()
            .FirstOrDefault(p => p.ProjectName == projectName);
    }

    public List<Project> GetAllProjects()
    {
        return _context.Projects
            .AsNoTracking()
            .ToList();
    }

    public Project Edit(Project project)
    {
        try
        {
            var existing = _context.Projects
                .FirstOrDefault(p => p.ID_Project == project.ID_Project);

            if (existing == null)
                throw new RepositoryException("Project not found.");

            existing.ProjectName = project.ProjectName;
            existing.ID_Manager = project.ID_Manager;
            existing.StartDate = project.StartDate;
            existing.EndDate = project.EndDate;

            _context.SaveChanges();
            return existing;
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Failed to update project.", ex);
        }
    }

    public bool DoesProjectExist(string projectName)
    {
        try
        {
            return _context.Projects.Any(i => i.ProjectName == projectName);
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Failed to check existing project.", ex);
        }
    }
}
