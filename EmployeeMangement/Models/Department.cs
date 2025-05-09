namespace EmployeeMangement.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Designation { get; set; } = null!;

        public List<Empolyee> empolyees { get; set; } = new List<Empolyee>();
    }
}
