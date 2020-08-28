using DataAccesLayer.CustomExceptions;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using DomainModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ProjectService : IProjectService
    {
        public Project Create(Project project)
        {
            try
            {
                ProjectRepo projectRepository = new ProjectRepo();
                if (projectRepository.DoesProjectExist(project.ProjectName))
                {
                    throw new ValidationServiceException("Project with this name = " + project.ProjectName + ", already exist in database.");
                }
                projectRepository.Create(project);
                return project;
            }
            catch (ValidationServiceException)
            {
                throw;
            }
            catch (RepositoryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("User with this Username = " + project.ProjectName + ", already exists in database.", ex);
            }
        }

        public Project GetProjectByID(int Id)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            Project project = projectRepository.GetProjectById(Id);
            return project;
        }

        public Project GetProjectByProjectname(string ProjectName)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            Project project = projectRepository.getProjectByProjectname(ProjectName);
            return project;
        }

        public List<Project> GetAllProjects()
        {
            ProjectRepo projectRepository = new ProjectRepo();
            List<Project> projects = projectRepository.GetAllProjects();
            return projects;
        }

        public void Delete(Project project)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            projectRepository.Delete(project);
        }

        public void Edit(Project project)
        {
            ProjectRepo projectRepository = new ProjectRepo();
            projectRepository.Edit(project);
        }
    }
}