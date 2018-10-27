namespace Sharing.DataAccessCore.Core
{
    public class Machine: Entity
    {
        public Machine()
        {
            
        }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public virtual Characteristic Characteristic { get; set; }
        public virtual MachineType MachineType { get; set; }
        public virtual Lessor Lessor { get; set; }

    }
}
