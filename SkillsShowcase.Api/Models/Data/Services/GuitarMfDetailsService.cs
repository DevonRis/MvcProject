﻿using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class GuitarMfDetailsService(GuitarMfRepository guitarMfRepository)
    {
        public async Task<GetGuitarMfDetailsResponse> GetGuitarMf()
        {
            var guitarMfData = await guitarMfRepository.GetGuitarMfDetailsForRepository();
            return new GetGuitarMfDetailsResponse
            {
                GuitarMfDetails = guitarMfData
            };
        }
    }
}
