using System.Collections.Generic;

namespace Sharing.DataAccessCore.Core
{
    public class Customer: User
    {
        public Customer()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public virtual List<RenteredResource> RenteredMachine { get; set; }

    }
}
