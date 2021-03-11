using Business.DTOs;
using System;

namespace Business
{
    public class Factory
    {
        
        public const string HourlySalaryEmployee = "HourlySalaryEmployee";
        public const string MonthlySalaryEmployee = "MonthlySalaryEmployee";
        public static Employee Creator(string typeSalary)
        {
            switch (typeSalary)
            {
                case HourlySalaryEmployee:
                    return new HourlySalaryEmployee();
                case MonthlySalaryEmployee:
                    return new MonthlySalaryEmployee();
                default:
                    return null;
            }
        }
    }
}
