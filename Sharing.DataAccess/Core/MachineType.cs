namespace Sharing.DataAccess.Core
{
    public class MachineType
    {
        public int Id { get; set; }
        public virtual MediumAction MediumAction { get; set; }
        public virtual ApplicationMode ApplicationMode { get; set; }
    }
}
