namespace StrategyPattern
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(string firstName, string lastName, Gender gender)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }


    }

    public enum Gender
    {
        Male,
        Female
    }


}
