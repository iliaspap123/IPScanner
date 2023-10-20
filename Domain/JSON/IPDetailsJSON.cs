using Domain.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain.JSON
{
    public class IPDetailsJSON : IIPDetails
    {
        public string ip { get; set; }
        public string type { get; set; }
        public string continent_code { get; set; }
        [JsonProperty("continent_name")]
        public string Continent { get; set; }
        public string country_code { get; set; }
        [JsonProperty("country_name")]
        public string Country{ get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }

        public string City { get; set; }
        public string zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Location location { get; set; }
        public bool success { get; set; } = true;
    }

    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
        public string native { get; set; }
    }

    public class Location
    {
        public int geoname_id { get; set; }
        public string capital { get; set; }
        public List<Language> languages { get; set; }
        public string country_flag { get; set; }
        public string country_flag_emoji { get; set; }
        public string country_flag_emoji_unicode { get; set; }
        public string calling_code { get; set; }
        public bool is_eu { get; set; }
    }
}
