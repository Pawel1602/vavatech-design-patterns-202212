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
        private readonly decimal benefit;

        public SalaryCalculator(decimal amountPerHour, decimal bonusPerProject, decimal benefit)
        {
            this.amountPerHour = amountPerHour;
            this.bonusPerProject = bonusPerProject;
            this.benefit = benefit;
        }

        public decimal CalculateSalary(Employee employee)
        {
            Employee decoratedEmployee =
                new ProjectSalaryDecorator(
                    new OvertimeSalaryDecorator(
                        employee, amountPerHour), bonusPerProject);

            Employee decoratedEmployee2 =
                new OvertimeSalaryDecorator(
                    new ProjectSalaryDecorator(
                        new BenefitSalaryDecorator(
                            employee, benefit),
                         bonusPerProject),
                    amountPerHour);

            decimal salary = decoratedEmployee.GetSalary();
            decimal salary2 = decoratedEmployee2.GetSalary();


            return salary;

        }
    }

}
