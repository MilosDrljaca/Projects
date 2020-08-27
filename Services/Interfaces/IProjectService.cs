using System.Collections.Generic;
using DomainModel;

namespace Services.Interfaces
{
    public interface IProjectService
    {
        public Project Create(Project project);
        public Project GetProjectByProjectname(string ProjectName);
        public Project GetProjectByID(int Id);
        public List<Project> GetAllProjects();
        public void Delete(Project project);

    }
}