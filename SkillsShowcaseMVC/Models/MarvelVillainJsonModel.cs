using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcaseMVC.Models
{
    public class MarvelVillainJsonModel
    {
        public MarvelVillainsOptions VillainName { get; set; }
        public int? VillainConfirmedKills { get; set; }
    }
}
