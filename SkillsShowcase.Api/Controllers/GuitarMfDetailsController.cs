﻿using Microsoft.AspNetCore.Mvc;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;
using SkillsShowcase.Api.Models.Data.Services;

namespace SkillsShowcase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarMfDetailsController : ControllerBase
    {
        private readonly GuitarMfDetailsService _guitarMfDetailsService;
        public GuitarMfDetailsController(GuitarMfDetailsService guitarMfDetailsService)
        {
            _guitarMfDetailsService = guitarMfDetailsService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetGuitarMfDetailsResponse response = await _guitarMfDetailsService.GetGuitarMf();
            return Ok(response.GuitarMfDetails);
        }
    }
}
