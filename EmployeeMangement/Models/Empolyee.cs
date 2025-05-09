namespace EmployeeMangement.Models
{
    public class Empolyee:UserActivity
    {
        public int Id { get; set; }
        public string EmpNo { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public int? PhoneNumber { get; set; }
        public string EmailAddress { get; set; } = null!;

        public string Country { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; } = null!;

        public int departmentId { get; set; }

        public Department? department { get; set; }

        

    }
}
