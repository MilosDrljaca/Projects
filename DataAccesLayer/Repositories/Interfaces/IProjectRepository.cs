using DomainModel;
using System.Collections.Generic;

namespace DataAccesLayer.Repositories.Interfaces;

public interface IProjectRepository
{
    Project Create(Project project);
    void Delete(Project project);
    Project GetProjectById(int id);
    Project GetProjectByProjectName(string projectName);
    List<Project> GetAllProjects();
    Project Edit(Project project);
    bool DoesProjectExist(string projectName);
}
