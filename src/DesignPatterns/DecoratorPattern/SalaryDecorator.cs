using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // Abstract decorator
    public abstract class SalaryDecorator : Employee // Abstract component
    {
        // Abstract component
        public Employee employee;

        protected SalaryDecorator(Employee employee) => this.employee = employee;

        public override decimal GetSalary()
        {
            if (employee != null)
            {
                return employee.GetSalary();
            }
            else
                return decimal.Zero;
        }
    }

    // Concrete decorator
    public class OvertimeSalaryDecorator : SalaryDecorator
    {
        private readonly decimal amountPerHour;

        public OvertimeSalaryDecorator(Employee employee, decimal amountPerHour) : base(employee)
        {
            this.amountPerHour = amountPerHour;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + (decimal)employee.OvertimeSalary.TotalHours * amountPerHour;
        }
    }

    // Concrete decorator
    public class ProjectSalaryDecorator : SalaryDecorator
    {
        private readonly decimal bonusPerProject;

        public ProjectSalaryDecorator(Employee employee, decimal bonusPerProject) : base(employee)
        {
            this.bonusPerProject = bonusPerProject;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + employee.NumberOfProjects * bonusPerProject;
        }
    }
}
