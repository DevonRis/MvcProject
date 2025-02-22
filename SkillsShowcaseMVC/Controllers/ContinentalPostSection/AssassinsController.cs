using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcaseMVC.Models;

namespace SkillsShowcaseMVC.Controllers.ContinentalPostSection
{
    public class AssassinsController : Controller
    {
        private readonly GetApiClient? ApiClient;
        public AssassinsController(GetApiClient getApiClient)
        {
            ApiClient = getApiClient;
        }
        [HttpPost]
        public ActionResult CreateAssassinSubmission(ContinentalRegistrationModel model)
        {
            return RedirectToAction("ContinentalIndex");
        }
    }
}
