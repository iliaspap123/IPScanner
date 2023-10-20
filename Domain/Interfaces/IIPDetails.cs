namespace Domain.Interfaces
{
    public interface IIPDetails
    {
        string City { get; }
        string Continent { get; }
        string Country { get; }
        double Latitude { get; }
        double Longitude { get; }

    }
}