namespace RepositoryLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ModelLayer.EmployeeModels;

    public interface IEmpRL
    {
        public void AddEmployee(AddEmployeeModel addEmployeeModel);

        public List<GetAllEmployeeModel> GetAllEmployee();

        public void UpdateEmployee(GetAllEmployeeModel updateEmpModel);

        public GetAllEmployeeModel GetEmployeeById(int? Id);

        public void DeleteEmployee(int id);
    }
}
