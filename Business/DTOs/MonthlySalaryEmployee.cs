using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class MonthlySalaryEmployee : Employee
    {
        public override float AnnualSalary
        {
            get
            {
                return this.MonthlySalary * 12;
            }
        }
    }
}
