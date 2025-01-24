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
            GuitarManufacturerDetailsViewModel? guitarManufacturerDetails = new();
            List<GuitarsForApiCall>? guitarsForApiCalls = _getGuitarMFDetailsAPI?
                .GetApiGuitars()
                .Result;
            List<GuitarManufactureDetailsForApiCall>? guitarManufacturerDetailsFromAPI = _getGuitarMFDetailsAPI?
                .GetManufactureDetails()
                .Result;
            var forcedPairNumbers = new Dictionary<int, int> //forcing a number Pair because numbers(GuitarBrandName) didnt match : Continue to study this
            {
                { 1, 1 }, // GuitarId 1: Fender
                { 2, 1 }, // GuitarId 2: Fender
                { 3, 1 }, // GuitarId 3: Fender
                { 4, 1 }, // GuitarId 4: Fender
                { 5, 2 }, // GuitarId 5: Gibson
                { 6, 2 }, // GuitarId 6: Gibson
                { 7, 3 }, // GuitarId 7: PaulReedSmith
                { 8, 4 }  // GuitarId 8: Ibanez
            };
            if (guitarManufacturerDetailsFromAPI != null && forcedPairNumbers.ContainsKey(guitarId))
            {
                int manufacturerId = forcedPairNumbers[guitarId];
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
