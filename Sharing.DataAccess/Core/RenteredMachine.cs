using System;

namespace Sharing.DataAccess.Core
{
    public class RenteredMachine
    {
        public int Int { get; set; }
        public virtual Renter Renter { get; set; }
        public virtual Machine Machine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Price { get; set; }
        public string ActivationCode { get; set; }
    }
}
