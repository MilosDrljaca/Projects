using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using Services;
using Services.Interfaces;
using Services.Models;
using System.Linq;

namespace Projects.Controllers;

[Route("projects")]
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;
    private readonly IManagerService _managerService;

    public ProjectController(IProjectService projectService, IManagerService managerService)
    {
        _projectService = projectService;
        _managerService = managerService;
    }

    [HttpGet("/")]
    public IActionResult Landing()
    {
        return RedirectToAction("Index");
    }

    [HttpGet("")]
    public IActionResult Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
    {
        ViewData["CurrentSort"] = sortOrder;
        ViewData["IdSortParm"] = sortOrder == "Id" ? "id_desc" : "Id";
        ViewData["ProjectNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "project_name" : "";
        ViewData["ManagerIdSortParm"] = sortOrder == "manager" ? "manager_desc" : "manager";
        ViewData["StartDateSortParm"] = sortOrder == "StartDate" ? "start_desc" : "StartDate";
        ViewData["EndDateSortParm"] = sortOrder == "EndDate" ? "end_desc" : "EndDate";

        if (searchString != null)
            pageNumber = 1;
        else
            searchString = currentFilter;

        ViewData["CurrentFilter"] = searchString;

        var projects = _projectService.GetAllProjects().AsQueryable();

        // filter
        if (!string.IsNullOrEmpty(searchString))
        {
            projects = projects.Where(p => p.ProjectName.Contains(searchString));
        }

        // sort
        projects = sortOrder switch
        {
            "id_desc" => projects.OrderByDescending(p => p.ID_Project),
            "project_name" => projects.OrderBy(p => p.ProjectName),
            "manager" => projects.OrderBy(p => p.ID_Manager),
            "manager_desc" => projects.OrderByDescending(p => p.ID_Manager),
            "StartDate" => projects.OrderBy(p => p.StartDate),
            "start_desc" => projects.OrderByDescending(p => p.StartDate),
            "EndDate" => projects.OrderBy(p => p.EndDate),
            "end_desc" => projects.OrderByDescending(p => p.EndDate),
            _ => projects.OrderBy(p => p.ID_Project)
        };

        int pageSize = 10;
        var paginated = PaginatedList<Project>.Create(projects, pageNumber ?? 1, pageSize);

        ViewBag.Managers = _managerService.GetAllManagers();

        return View(paginated);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        ViewBag.Managers = _managerService.GetAllActiveManagers();
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(CreateProjectRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            if (request.StartDate > request.EndDate)
                throw new ValidationServiceException("End date must be after start date.");

            var project = new Project
            {
                ProjectName = request.ProjectName,
                ID_Manager = request.ID_Manager,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            _projectService.Create(project);
            return RedirectToAction("Index");
        }
        catch (ValidationServiceException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(request);
        }
    }

    [HttpGet("{id}/edit")]
    public IActionResult Edit(int id)
    {
        ViewBag.Managers = _managerService.GetAllActiveManagers();
        return View(_projectService.GetProjectByID(id));
    }

    [HttpPost("{id}/edit")]
    public IActionResult Edit(Project project)
    {
        try
        {
            if (project.StartDate > project.EndDate)
                throw new ValidationServiceException("End date must be after start date.");

            var all = _projectService.GetAllProjects();

            if (all.Any(p => p.ProjectName == project.ProjectName && p.ID_Project != project.ID_Project))
                throw new ValidationServiceException("Project name already exists.");

            _projectService.Edit(project);
            return RedirectToAction("Index");
        }
        catch (ValidationServiceException ex)
        {
            ModelState.AddModelError("", ex.Message);
            ViewBag.Managers = _managerService.GetAllActiveManagers();
            return View(project);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        ViewBag.Managers = _managerService.GetAllManagers();
        return View(_projectService.GetProjectByID(id));
    }

    [HttpGet("{id}/delete")]
    public IActionResult Delete(int id)
    {
        ViewBag.Managers = _managerService.GetAllManagers();
        return View(_projectService.GetProjectByID(id));
    }

    [HttpPost("{id}/delete")]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var project = _projectService.GetProjectByID(id);
        _projectService.Delete(project);

        return RedirectToAction("Index");
    }
}
