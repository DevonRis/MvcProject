using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcaseMVC.Models
{
    public class ContinentalRegistrationModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ContinentalAgeRange Age { get; set; }
        public string? Height { get; set; }
        public DateTime? RegisterDate { get; set; }
        public AllFiftyStates State { get; set; }
        public MartialArts PerferedMartialArt { get; set; }
        public Weapons PerferedWeapon { get; set; }
    }
}
