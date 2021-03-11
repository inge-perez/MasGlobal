using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class HourlySalaryEmployee : Employee
    {
        public override float AnnualSalary
        {
            get
            {
                return 120 * this.HourlySalary * 12;
            }
            
        }
    }
}
