using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses.Save;
using SkillsShowcase.Shared.Domain.Models.ApiModelsForApiCall;

namespace SkillsShowcase.Api.Models.Data.Services
{
    public class AssassinsService(AssassinsRepository assassinsRepository)
    {
        public async Task<AssassinsResponse> GetAssassinsFromRepo()
        {
            var assassinsData = await assassinsRepository.GetAssassinsFromContext();
            return new AssassinsResponse
            {
                Assassins = assassinsData
            };
        }
        public async Task CreateAssassin(AssassinsPostRequest assassinsPostRequest)
        {
            if (assassinsPostRequest.CreateAssassins != null)
            {
                await assassinsRepository.CreateNewAssassin(assassinsPostRequest.CreateAssassins);
            }
        }
    }
}
