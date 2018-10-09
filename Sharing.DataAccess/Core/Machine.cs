namespace Sharing.DataAccess.Core
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public virtual Сharacteristic Сharacteristic { get; set; }
        public virtual MachineType MachineType { get; set; }

    }
}
