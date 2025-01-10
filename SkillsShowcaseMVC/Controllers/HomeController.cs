using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcaseMVC.Models;

namespace SkillsShowcaseMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GetApiClient? _getEmployeesAPI;
        public HomeController(ILogger<HomeController> logger, GetApiClient getApiClient)
        {
            _logger = logger;
            _getEmployeesAPI = getApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Employees()
        {
            List<EmployeesViewModel> employeesViewModel = new();
            List<EmployeeForApiCall>? employeesFromApi = _getEmployeesAPI?.GetApiEmployeesTable().Result;
            if (employeesFromApi != null)
            {
                employeesViewModel = employeesFromApi.Select(employee => new EmployeesViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    MaritalStatus = employee.MaritalStatus,
                    Gender = employee.Gender
                }).ToList();
            }
            return View(employeesViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
