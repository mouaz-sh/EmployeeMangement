namespace EmployeeMangement.ViewModels.Departments
{
    public record CreateVm
    {
        public int Id { get; set; }

        public string ? Designation { get; set; }
    }
}
