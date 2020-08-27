using DataAccesLayer.CustomExceptions;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class ProjectRepo
    {
        public Project Create(Project project)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
                return project;
            }
        }

        public void Delete(Project project)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Projects.Remove(project);
                context.SaveChanges();
            }
        }

        public Project GetProjectById(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Project project = context.Projects.Find(id);
                context.SaveChanges();
                return project;
            }
        }

        public Project getProjectByProjectname(string ProjectName)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                Project project = context.Projects.FirstOrDefault(m => m.ProjectName == ProjectName);

                context.SaveChanges();
                return project;
            }
        }

        public List<Project> GetAllProjects()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                List<Project> projects = context.Projects.ToList();
                context.SaveChanges();
                return projects;
            }
        }

        public bool DoesProjectExist(string ProjectName)
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    bool result = context.Projects.Any(i => i.ProjectName == ProjectName);
                    context.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Communication with database failed. Project with this Name = " + ProjectName + ", already exists in database.", ex);
            }
        }
    }
}
