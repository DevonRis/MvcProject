using SkillsShowcase.Shared.Domain.Models.Enums;

namespace SkillsShowcaseMVC.Models
{
    public class EmployeesViewModel
    {
        public int? EmployeeId { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
    }
}
