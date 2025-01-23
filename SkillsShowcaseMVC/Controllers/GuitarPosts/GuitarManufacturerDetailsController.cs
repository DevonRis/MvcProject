using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Shared.Domain.Clients;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;
using SkillsShowcase.Shared.Domain.Models.Enums;
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
            GuitarManufacturerDetailsViewModel? guitarManufacturerDetails = new();
            List<GuitarsForApiCall>? guitarsForApiCalls = _getGuitarMFDetailsAPI?
                .GetApiGuitars()
                .Result;
            List<GuitarManufactureDetailsForApiCall>? guitarManufacturerDetailsFromAPI = _getGuitarMFDetailsAPI?
                .GetManufactureDetails()
                .Result;
            var manufacturerMapping = new Dictionary<int, int> //forcing a number Pair : Continue to study this
            {
                { 1, 1 }, // Fender
                { 2, 1 }, // Fender
                { 3, 1 }, // Fender
                { 4, 1 }, // Fender
                { 5, 2 }, // Gibson
                { 6, 2 }, // Gibson
                { 7, 3 }, // PaulReedSmith
                { 8, 4 }  // Ibanez
            };
            if (guitarManufacturerDetailsFromAPI != null && manufacturerMapping.ContainsKey(guitarId))
            {
                int manufacturerId = manufacturerMapping[guitarId];
                var guitarManufacturerDetail = guitarManufacturerDetailsFromAPI.FirstOrDefault(g => g.GuitarManufacturerId == manufacturerId);
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
