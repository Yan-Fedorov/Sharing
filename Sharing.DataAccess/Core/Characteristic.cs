using System;

namespace Sharing.DataAccess.Core
{
    public class Characteristic
    {
        public int Id { get; set; }
        public DateTime WorkTime { get; set; }
        public double Speed { get; set; }
        public double Accelaration { get; set; }
        public double ActionRadius { get; set; }
        public double Weight { get; set; }
        public virtual Size Size { get; set; }
    }
}
