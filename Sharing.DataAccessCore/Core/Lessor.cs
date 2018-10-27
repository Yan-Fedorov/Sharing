using System.Collections.Generic;

namespace Sharing.DataAccessCore.Core
{
    public class Lessor: Entity
    {
        public Lessor()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public virtual List<Machine> Machines { get; set; }
    }
}
