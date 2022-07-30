namespace BusinessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BusinessLayer.Interfaces;
    using ModelLayer.EmployeeModels;
    using RepositoryLayer.Interfaces;

    public class EmpBL: IEmpBL
    {
        IEmpRL empRL;

        public EmpBL(IEmpRL empRL)
        {
            this.empRL = empRL;
        }

        public void AddEmployee(AddEmployeeModel addEmployeeModel)
        {
            try
            {
                this.empRL.AddEmployee(addEmployeeModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GetAllEmployeeModel> GetAllEmployee()
        {
            try
            {
                return this.empRL.GetAllEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetAllEmployeeModel GetEmployeeById(int? Id)
        {
            try
            {
                return this.empRL.GetEmployeeById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(GetAllEmployeeModel updateEmpModel)
        {
            try
            {
                this.empRL.UpdateEmployee(updateEmpModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                this.empRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
