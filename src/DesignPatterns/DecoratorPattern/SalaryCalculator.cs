using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // Kalkulator płacowy 
    // Premia za nadgodziny
    // Premia za oddanie każdego projektu
    // Premia za udział w szkoleniu ;-)

    public class SalaryCalculator
    {
        private readonly decimal amountPerHour;
        private readonly decimal bonusPerProject;

        public SalaryCalculator(decimal amountPerHour, decimal bonusPerProject)
        {
            this.amountPerHour = amountPerHour;
            this.bonusPerProject = bonusPerProject;
        }

        public decimal CalculateSalary(Employee employee)
        {
            Employee decoratedEmployee = 
                new ProjectSalaryDecorator(                
                    new OvertimeSalaryDecorator(
                        employee, amountPerHour), bonusPerProject);

            decimal salary = decoratedEmployee.GetSalary();

         
            return salary;           
           
        }
    }

}
