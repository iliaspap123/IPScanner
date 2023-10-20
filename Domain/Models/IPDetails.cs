using Domain.Interfaces;

namespace Domain.Models
{
    public class IPDetails : IIPDetails
    {
        public string IP { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Continent { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public static IPDetails Create(string ip,string city, string country, string continent, double latitude, double longitude)
        {
            return new IPDetails {IP = ip, City = city, Country = country, Continent = continent, Latitude = latitude, Longitude = longitude };
        }

    }
}
