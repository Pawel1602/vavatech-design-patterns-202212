using System;

namespace DecoratorPattern
{
    public abstract class Employee
    {
        public TimeSpan OvertimeSalary { get; set; }
        public int NumberOfProjects { get; set; }
        public abstract decimal GetSalary();
    }

}
