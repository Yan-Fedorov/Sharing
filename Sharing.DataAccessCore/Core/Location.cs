namespace Sharing.DataAccessCore.Core
{
    public class Location: Entity
    {
        public Location()
        {
            
        }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
    }
}
