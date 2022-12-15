using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashedPassword { get; set; }
        public Address HomeAddress { get; set; }
        public Address ShipAddress { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class CustomerDTO
    {
        public string FullName { get; set; }
        public string Country { get; set; }
    }
}
