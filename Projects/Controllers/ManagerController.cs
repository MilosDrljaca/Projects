using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Projects.Models;
using Services;
using Services.Interfaces;
using Services.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projects.Controllers;

[Route("managers")]
public class ManagerController : Controller
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
    {
        ViewData["CurrentSort"] = sortOrder;
        ViewData["IdSortParm"] = sortOrder == "Id" ? "id_desc" : "Id";
        ViewData["Active"] = sortOrder == "Active" ? "active_desc" : "Active";
        ViewData["ManagerNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "manager_name" : "";

        if (searchString != null)
            pageNumber = 1;
        else
            searchString = currentFilter;

        ViewData["CurrentFilter"] = searchString;

        var managers = _managerService.GetAllManagers().AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            managers = managers.Where(s => s.ManagerName.Contains(searchString));
        }

        managers = sortOrder switch
        {
            "id_desc" => managers.OrderByDescending(s => s.ID_Manager),
            "active_desc" => managers.OrderByDescending(s => s.Active),
            "manager_name" => managers.OrderBy(s => s.ManagerName),
            _ => managers.OrderBy(s => s.ID_Manager)
        };

        int pageSize = 10;

        var paged = PaginatedList<Manager>.Create(managers, pageNumber ?? 1, pageSize);
        return View(paged);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(CreateManagerRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var manager = new Manager
            {
                ManagerName = request.ManagerName,
                Active = 1
            };

            _managerService.CreateManager(manager);

            return RedirectToAction("Index");
        }
        catch (ValidationServiceException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(request);
        }
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit(int id)
    {
        var manager = _managerService.GetManagerById(id);
        return View(manager);
    }

    [HttpPost("edit/{id}")]
    public IActionResult Edit(int id, Manager manager)
    {
        try
        {
            _managerService.Edit(manager);
            return RedirectToAction("Index");
        }
        catch (ValidationServiceException ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(manager);
        }
    }

    [HttpGet("details/{id}")]
    public IActionResult Details(int id)
    {
        return View(_managerService.GetManagerById(id));
    }
}
