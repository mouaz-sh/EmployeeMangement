using System.ComponentModel.DataAnnotations;
using EmployeeMangement.Models;

namespace EmployeeMangement.ViewModels.Empolyee
{
    public record CreateEmpVm
    {
        public int Id { get; set; }
        public string EmpNo { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
       
        public int? PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        public string Country { get; set; } = null!;
        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; } = null!;

        public int departmentId { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? CreeatedOn { get; set; }
     
    }
}
