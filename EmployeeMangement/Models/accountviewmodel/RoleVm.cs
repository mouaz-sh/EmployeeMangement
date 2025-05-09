using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement.Models.accountviewmodel
{
    public record RoleVm
    {
        [Required]
        public string? RoleName { get; set; }

    }
}
