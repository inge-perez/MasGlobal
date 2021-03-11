using Business.DTOs;
using Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees(string query);
    }
}
