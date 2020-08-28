using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projects.Models;
using Services.Interfaces;
using Services.Models;

namespace Projects.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly ApplicationDbContext _context;

        public ManagerController(IManagerService managerService, ApplicationDbContext context)
        {
            _managerService = managerService;
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["IdSortParm"] = sortOrder == "Id" ? "id_desc" : "Id";
            ViewData["Active"] = sortOrder == "Active" ? "active_desc" : "Active";
            ViewData["ManagerNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "manager_name" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var managers = from s in _context.Managers
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                managers = managers.Where(s => s.ManagerName.Contains(searchString)
                                      );
            }

            switch (sortOrder)
            {
                case "id_desc":
                    managers = managers.OrderByDescending(s => s.ID_Manager);
                    break;
                case "active_desc":
                    managers = managers.OrderByDescending(s => s.Active);
                    break;

                case "manager_name":
                    managers = managers.OrderBy(s => s.ManagerName);
                    break;

                default:
                    managers = managers.OrderBy(s => s.ID_Manager);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Manager>.CreateAsync(managers.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([FromForm] CreateManagerRequest createManagerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Manager manager = new Manager
            {

                ManagerName = createManagerRequest.ManagerName,
                Active = 1,

            };

            _managerService.CreateManager(manager);

            return RedirectToAction("Index", "Manager");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_managerService.GetManagerById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Manager manager)
        {
            _managerService.Edit(manager);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_managerService.GetManagerById(id));
        }
    }
}