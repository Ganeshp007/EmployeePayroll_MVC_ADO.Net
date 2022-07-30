namespace ModelLayer.EmployeeModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class AddEmployeeModel
    {
        [Required]
        [RegularExpression("(^[A-Z][A-Za-z]{3,20})+( [A-Z]{1}[A-Za-z]{3,20})$", ErrorMessage = "Please Enter For Name At least 3 Characters and First letter Capital")] //Name Validation
        public string EmployeeName { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Gender { get; set; }

        public Decimal Salary { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        public string ProfileImage { get; set; }
    }
}
