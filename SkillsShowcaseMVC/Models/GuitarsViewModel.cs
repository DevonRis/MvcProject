using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcaseMVC.Models
{
    public class GuitarsViewModel
    {
        public int GuitarId { get; set; }
        public GuitarOptions GuitarManufacturer { get; set; }
        public string? GuitarModel { get; set; }
        public double? GuitarPrice { get; set; }
        public DateTime? BuildYear { get; set; }
    }
}
