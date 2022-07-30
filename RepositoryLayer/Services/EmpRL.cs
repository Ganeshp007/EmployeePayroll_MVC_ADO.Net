namespace RepositoryLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using ModelLayer.EmployeeModels;
    using RepositoryLayer.Interfaces;

    public class EmpRL : IEmpRL
    {
        private readonly string connectionString;

        public EmpRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("EmployeePayrollDB");
        }

        public void AddEmployee(AddEmployeeModel addEmployeeModel)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("spAddEmployee", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", addEmployeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@Department", addEmployeeModel.Department);
                    cmd.Parameters.AddWithValue("@Gender", addEmployeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Salary", addEmployeeModel.Salary);
                    cmd.Parameters.AddWithValue("@JoiningDate", addEmployeeModel.JoiningDate);
                    cmd.Parameters.AddWithValue("@ProfileImage", addEmployeeModel.ProfileImage);
                    var result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public List<GetAllEmployeeModel> GetAllEmployee()
        {
            List<GetAllEmployeeModel> listOfEmployee = new List<GetAllEmployeeModel>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllEmployee", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetAllEmployeeModel getAllEmployee = new GetAllEmployeeModel();
                        getAllEmployee.Emp_Id = reader["Emp_Id"] == DBNull.Value ? default : reader.GetInt32("Emp_Id");
                        getAllEmployee.EmployeeName = reader["EmployeeName"] == DBNull.Value ? default : reader.GetString("EmployeeName");
                        getAllEmployee.Department = reader["Department"] == DBNull.Value ? default : reader.GetString("Department");
                        getAllEmployee.Gender = reader["Gender"] == DBNull.Value ? default : reader.GetString("Gender");
                        getAllEmployee.Salary = reader["Salary"] == DBNull.Value ? default : reader.GetDecimal("Salary");
                        getAllEmployee.JoiningDate = reader["JoiningDate"] == DBNull.Value ? default : reader.GetDateTime("JoiningDate");
                        getAllEmployee.ProfileImage = reader["ProfileImage"] == DBNull.Value ? default : reader.GetString("ProfileImage");

                        listOfEmployee.Add(getAllEmployee);
                    }
                    return listOfEmployee;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public GetAllEmployeeModel GetEmployeeById(int? Id)
        {
            GetAllEmployeeModel getAllEmployee = new GetAllEmployeeModel();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string sqlQuery = "Select * from Employee where Emp_Id=" + Id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        getAllEmployee.Emp_Id = reader["Emp_Id"] == DBNull.Value ? default : reader.GetInt32("Emp_Id");
                        getAllEmployee.EmployeeName = reader["EmployeeName"] == DBNull.Value ? default : reader.GetString("EmployeeName");
                        getAllEmployee.Department = reader["Department"] == DBNull.Value ? default : reader.GetString("Department");
                        getAllEmployee.Gender = reader["Gender"] == DBNull.Value ? default : reader.GetString("Gender");
                        getAllEmployee.Salary = reader["Salary"] == DBNull.Value ? default : reader.GetDecimal("Salary");
                        getAllEmployee.JoiningDate = reader["JoiningDate"] == DBNull.Value ? default : reader.GetDateTime("JoiningDate");
                        getAllEmployee.ProfileImage = reader["ProfileImage"] == DBNull.Value ? default : reader.GetString("ProfileImage");
                    }

                    return getAllEmployee;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateEmployee(GetAllEmployeeModel updateEmpModel)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emp_Id", updateEmpModel.Emp_Id);
                    cmd.Parameters.AddWithValue("@EmployeeName", updateEmpModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@Department", updateEmpModel.Department);
                    cmd.Parameters.AddWithValue("@Gender", updateEmpModel.Gender);
                    cmd.Parameters.AddWithValue("@Salary", updateEmpModel.Salary);
                    cmd.Parameters.AddWithValue("@JoiningDate", updateEmpModel.JoiningDate);
                    cmd.Parameters.AddWithValue("@ProfileImage", updateEmpModel.ProfileImage);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            var result = 0;
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    //Creating a stored Procedure for adding Users into database
                    SqlCommand com = new SqlCommand("spDeleteEmployee", sqlconnection); ;
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Emp_Id",id);
                    result = com.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconnection.Close();
            }
        }

    }
}
