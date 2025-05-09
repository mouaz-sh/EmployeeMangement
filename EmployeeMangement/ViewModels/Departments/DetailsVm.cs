namespace EmployeeMangement.ViewModels.Departments
{
    public record DetailsVm
    {
        public int Id { get; set; }
        public string Designation { get; set; } = null!;
    }
}
