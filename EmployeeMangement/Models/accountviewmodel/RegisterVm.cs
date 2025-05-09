using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement.Models.accountviewmodel
{
    public record RegisterVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword))]
        [Required]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? ConfirmPassword { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [RegularExpression("01[0125][0-9]{8}")]
        public string? phone { get; set; }

    }
}
