using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcaseMVC.Models;

namespace SkillsShowcaseMVC.Controllers.GuitarPosts
{
    public class GuitarManufacturerDetailsController : Controller
    {
        private readonly GetApiClient? _getGuitarMFDetailsAPI;
        public GuitarManufacturerDetailsController(GetApiClient getApiClient)
        {
            _getGuitarMFDetailsAPI = getApiClient;
        }
        public IActionResult GetGuitarManufacturerDetails(int guitarId)
        {
            GuitarManufacturerDetailsViewModel? guitarManufacturerDetails = new GuitarManufacturerDetailsViewModel() { };
            List<GuitarManufactureDetailsForApiCall>? guitarManufacturerDetailsFromAPI = _getGuitarMFDetailsAPI?.GetManufactureDetails().Result;
            if (guitarManufacturerDetailsFromAPI != null)
            {
                var guitarManufacturerDetail = guitarManufacturerDetailsFromAPI.FirstOrDefault(g => g.GuitarManufacturerId == guitarId);
                if (guitarManufacturerDetail != null)
                {
                    guitarManufacturerDetails = new GuitarManufacturerDetailsViewModel
                    {
                        GuitarManufacturerId = guitarManufacturerDetail.GuitarManufacturerId,
                        ManufacturerName = guitarManufacturerDetail.ManufacturerName,
                        Location = guitarManufacturerDetail.Location,
                        ContactNumber = guitarManufacturerDetail.ContactNumber,
                        Email = guitarManufacturerDetail.Email,
                        Website = guitarManufacturerDetail.Website,
                        DateEstablished = guitarManufacturerDetail.DateEstablished
                    };
                }
            }
            return View("~/Views/GuitarManufacturerDetails/_GuitarMFDetails.cshtml", guitarManufacturerDetails);
        }
    }
}
