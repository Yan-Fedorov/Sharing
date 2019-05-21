using System.Collections.Generic;

namespace Sharing.DataAccessCore.Core
{
    public class Lessor: User
    {
        public Lessor()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public virtual List<CloudResource> Machines { get; set; }
    }
}
