namespace EmployeeMangement.ViewModels.Departments
{
    public record editVm
    {
        public int Id { get; set; }
        public string Designation { get; set; } = null!;
    }
}
