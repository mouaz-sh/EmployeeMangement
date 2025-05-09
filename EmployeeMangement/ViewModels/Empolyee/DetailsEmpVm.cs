namespace EmployeeMangement.ViewModels.Empolyee
{
    public record DetailsEmpVm
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

        public string? Designation { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedById { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
