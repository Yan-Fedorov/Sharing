using System.Collections.Generic;

namespace Sharing.DataAccessCore.Core
{
    public class Renter: Entity
    {
        public Renter()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public virtual List<RenteredMachine> RenteredMachine { get; set; }

    }
}
