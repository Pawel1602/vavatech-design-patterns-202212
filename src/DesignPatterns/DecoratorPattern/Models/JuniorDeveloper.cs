﻿namespace DecoratorPattern
{
    // Concrete component
    public class JuniorDeveloper : Employee
    {
        public override decimal GetSalary()
        {
            return 1000;
        }
    }

}
