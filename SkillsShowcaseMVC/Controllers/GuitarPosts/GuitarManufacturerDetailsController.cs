using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Shared.Domain.Clients;

namespace SkillsShowcaseMVC.Controllers.GuitarPosts
{
    public class GuitarManufacturerDetailsController : Controller
    {
        private readonly GetApiClient? _getGuitarMFDetailsAPI;
        public GuitarManufacturerDetailsController(GetApiClient getApiClient) 
        {
            _getGuitarMFDetailsAPI = getApiClient;
        }
        public IActionResult GetGuitarManufacturerDetails(int guitarID)
        {
            return View();
        }
    }
}
