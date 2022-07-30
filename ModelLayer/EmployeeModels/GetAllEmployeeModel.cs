namespace ModelLayer.EmployeeModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GetAllEmployeeModel
    {
        public int Emp_Id { get; set; }

        public string EmployeeName { get; set; }

        public string Department { get; set; }

        public string Gender { get; set; }

        public Decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; }

        public string ProfileImage { get; set; }
    }
}
