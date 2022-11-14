namespace Locaserv.Bdv.Api.Models
{
    public struct Position
    {
        public Position(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public static explicit operator Position((decimal latitude, decimal longitude) position)
        => new(position.latitude,position.longitude);

        public decimal Latitude { get; }
        public decimal Longitude { get;  }
    }
}