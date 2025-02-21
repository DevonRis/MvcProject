using SkillsShowcase.Api.Models.Data.Repositories;
using SkillsShowcase.Api.Models.Data.RequestsAndResponses;

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
    }
}
