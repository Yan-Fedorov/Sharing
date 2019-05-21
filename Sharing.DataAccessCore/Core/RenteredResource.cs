using System;

namespace Sharing.DataAccessCore.Core
{
    public class RenteredResource: Entity
    {
        public RenteredResource(Customer customer,CloudResource machine, DateTime startDate, DateTime finishDate, decimal price, string activationCode)
        {
            Customer = customer;
            CloudResource = machine;
            StartDate = startDate;
            FinishDate = finishDate;
            Price = price;
            ActivationCode = activationCode;
        }

        public RenteredResource()
        {
            
        }
        public virtual Customer Customer { get; set; }
        public virtual CloudResource CloudResource { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Price { get; set; }
        public string ActivationCode { get; set; }
        public bool isActive { get; set; }
    }
}
