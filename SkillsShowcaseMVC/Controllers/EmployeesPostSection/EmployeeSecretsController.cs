using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcaseMVC.Models;

namespace SkillsShowcaseMVC.Controllers.EmployeesPostSection
{
    public class EmployeeSecretsController : Controller
    {
        private readonly GetApiClient? _getEmployeesAPI;
        public EmployeeSecretsController(GetApiClient getApiClient)
        {
            _getEmployeesAPI = getApiClient;
        }
        [HttpGet]
        public IActionResult GetEmployeeSecrets(int employeeID)
        {
            EmployeeSecretKeyViewModel? employeeSecret = new EmployeeSecretKeyViewModel() { };
            List<EmployeeSecretKeyForApiCall>? secretsFromAPI = _getEmployeesAPI?.GetApiEmployeeSecretKeys().Result;
            if (secretsFromAPI != null)
            {
                var secret = secretsFromAPI.FirstOrDefault(s => s.Id == employeeID);
                if (secret != null)
                {
                    employeeSecret = new EmployeeSecretKeyViewModel
                    {
                        Id = secret.Id,
                        EmployeeName = secret.EmployeeName,
                        SecretKey = secret.SecretKey
                    };
                }
            }
            return PartialView("_EmployeeSecrets", employeeSecret);
        }
    }
}
