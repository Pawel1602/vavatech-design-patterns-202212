using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class VisitFactory
    {
        private readonly TimeSpan duration;
        private readonly decimal pricePerHour;

        public VisitFactory(TimeSpan duration, decimal pricePerHour)
        {
            this.duration = duration;
            this.pricePerHour = pricePerHour;
        }

        // Match Patterns
        public Visit Create(string kind) => kind switch
        {
            "N" => new NfzVisit(duration, pricePerHour),
            "P" => new PrivateVisit(duration, pricePerHour),
            "F" => new CompanyVisit(duration, pricePerHour),
            "C" => new PackageVisit(duration, pricePerHour),
            _ => throw new NotSupportedException()
        };
    }
}
