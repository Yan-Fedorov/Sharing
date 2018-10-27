using System;

namespace Sharing.DataAccessCore.Core
{
    public class RenteredMachine: Entity
    {
        public RenteredMachine(Renter renter,Machine machine, DateTime startDate, DateTime finishDate, decimal price, string activationCode)
        {
            Renter = renter;
            Machine = machine;
            StartDate = startDate;
            FinishDate = finishDate;
            Price = price;
            ActivationCode = activationCode;
        }

        public RenteredMachine()
        {
            
        }
        public virtual Renter Renter { get; set; }
        public virtual Machine Machine { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Price { get; set; }
        public string ActivationCode { get; set; }
    }
}
