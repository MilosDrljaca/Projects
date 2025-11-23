using DataAccesLayer.CustomExceptions;
using DataAccesLayer.Repositories.Interfaces;
using DataAccessLayer.Repositories;
using DomainModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Project Create(Project project)
        {
            try
            {
                if (_projectRepository.DoesProjectExist(project.ProjectName))
                {
                    throw new ValidationServiceException("Project with this name = " + project.ProjectName + ", already exist in database.");
                }
                _projectRepository.Create(project);
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
            return _projectRepository.GetProjectById(Id);
        }

        public Project GetProjectByProjectname(string ProjectName)
        {
            return _projectRepository.GetProjectByProjectName(ProjectName);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }

        public void Delete(Project project)
        {
            _projectRepository.Delete(project);
        }

        public void Edit(Project project)
        {
            _projectRepository.Edit(project);
        }
    }
}