namespace Sharing.DataAccessCore.Core
{
    public class MachineType: Entity
    {
        public MachineType()
        {
            
        }
        public virtual MediumAction MediumAction { get; set; }
        public virtual ApplicationMode ApplicationMode { get; set; }
    }
}
