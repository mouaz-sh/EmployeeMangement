using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement.Models.accountviewmodel
{
   
        public record loginVm
        {
            [DataType(DataType.Password)]
            public string? Password { get; set; }
            public string? Name { get; set; }

            public bool Rememberme { get; set; }
        }
    
}
