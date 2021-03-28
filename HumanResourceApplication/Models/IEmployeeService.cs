using System.Collections.Generic;

namespace HumanResourceApplication.Models
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeModel employee);
        EmployeeModel GetEmployee(int? employeeid);
        IEnumerable<EmployeeModel> GetEmployees();

        void UpdateEmployee(EmployeeModel employee);
        bool DeleteEmployee(int employeeid);
    }
}   