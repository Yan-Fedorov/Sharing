using System.Collections.Generic;

namespace Sharing.DataAccess.Core
{
    public class Lessor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Money { get; set; }
        public virtual List<Machine> Machines { get; set; }
    }
}
