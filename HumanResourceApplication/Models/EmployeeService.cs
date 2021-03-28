using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace HumanResourceApplication.Models
{
    public class EmployeeService: IEmployeeService
    {
        public EmployeeService( IOptions<AppSettings> appSettings)
        {
           
            _appSettings = appSettings.Value;
        }

       
        private readonly AppSettings _appSettings;
        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                using IDbConnection con = new SqlConnection(_appSettings.Myconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FirstName", employee.FirstName);
                parameters.Add("@LastName", employee.LastName);
                parameters.Add("@MiddleName", employee.MiddleName);
                parameters.Add("@Jobtitle", employee.Jobtitle);
                parameters.Add("@EmployeeLevel", employee.EmployeeLevel);
                parameters.Add("@Age",employee.Age);
            

                con.Execute("AddNewEmpDetails",parameters, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception e)
            {
               // Console.WriteLine(e);
                throw e;
            };
        }

        public EmployeeModel GetEmployee(int? employeeid)
        {

            try
            {
                using IDbConnection con = new SqlConnection(_appSettings.Myconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Employeeid", employeeid);
              

                var employee = con.Query<EmployeeModel>("GetEmployee", parameter,
                    commandType: CommandType.StoredProcedure);
                con.Close();
                return employee.FirstOrDefault();
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                throw e;
            };
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            try
            {
                using IDbConnection con = new SqlConnection(_appSettings.Myconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var employees = con.Query<EmployeeModel>("GetEmployees",
                    commandType: CommandType.StoredProcedure);
                con.Close();
                return employees;
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                throw e;
            };
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                using IDbConnection con = new SqlConnection(_appSettings.Myconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Employeeid", employee.EmployeeId);
                parameters.Add("@FirstName", employee.FirstName);
                parameters.Add("@LastName", employee.LastName);
                parameters.Add("@MiddleName", employee.MiddleName);
                parameters.Add("@Jobtitle", employee.Jobtitle);
                parameters.Add("@EmployeeLevel", employee.EmployeeLevel);
                parameters.Add("@Age", employee.Age);

                con.Execute("UpdateEmpDetails",
                    parameters, commandType: CommandType.StoredProcedure);
                con.Close();

            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                throw e;
            };
        }

        public bool DeleteEmployee(int employeeid)
        {
            try
            {
                using IDbConnection con = new SqlConnection(_appSettings.Myconnection);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Employeeid", employeeid);
                con.Execute("DeleteEmpById", parameter, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                // Console.WriteLine(e);
                throw e;
            };
        }
    }
}
