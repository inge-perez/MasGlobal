using Business;
using Business.Contracts;
using Business.DTOs;
using Employees;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees(string query)
        {
            var employeeList = new List<Employee>();

            var result = (await httpClient.GetJsonAsync<EmployeeEntity[]>("http://masglobaltestapi.azurewebsites.net/api/Employees")).ToList();
            if (query == "")
            {
                foreach (var e in result)
                {
                    var employee = Factory.Creator(e.ContractTypeName);
                    employee.Id = e.Id;
                    employee.HourlySalary = e.HourlySalary;
                    employee.MonthlySalary = e.MonthlySalary;
                    employee.Name = e.Name;
                    employee.ContractTypeName = e.ContractTypeName == "HourlySalaryEmployee" ? "Hourly Salary" : "Monthly Salary";
                    employee.RoleDescription = e.RoleDescription ?? string.Empty;
                    employee.RoleName = e.RoleName;

                    employeeList.Add(employee);
                }
            }
            else
            {
                var resultQuery = result.FirstOrDefault(x => x.Id == Convert.ToInt32(query));

                if (resultQuery == null)
                {
                    return employeeList;
                }

                var employee = Factory.Creator(resultQuery.ContractTypeName);
                employee.Id = resultQuery.Id;
                employee.HourlySalary = resultQuery.HourlySalary;
                employee.MonthlySalary = resultQuery.MonthlySalary;
                employee.Name = resultQuery.Name;
                employee.ContractTypeName = resultQuery.ContractTypeName == "HourlySalaryEmployee" ? "Hourly Salary" : "Monthly Salary";
                employee.RoleDescription = resultQuery.RoleDescription ?? string.Empty;
                employee.RoleName = resultQuery.RoleName;
                employeeList.Add(employee);
            }
            return employeeList;
        }
    }
}
