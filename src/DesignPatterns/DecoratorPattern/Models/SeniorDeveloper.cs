namespace DecoratorPattern
{
    // Concrete component
    public class SeniorDeveloper : Employee
    {
        
        public override decimal GetSalary()
        {
            return 2000;
        }
    }

}
