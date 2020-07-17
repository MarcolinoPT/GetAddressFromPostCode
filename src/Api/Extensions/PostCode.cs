using WebService.Responses;

namespace Api.Extensions
{
    public static class PostCodeExtensions
    {
        public static double DistanceToHeathrowAirportInKm(this PostCode postCode)
        {
            return GetDistanceInKm(latFrom: postCode.Latitude, longFrom: postCode.Longitude);
        }

        public static double DistanceToHeathrowAirportInMiles(this PostCode postCode)
        {
            const double oneKmInMiles = 0.62137119223733;
            return GetDistanceInKm(latFrom: postCode.Latitude, longFrom: postCode.Longitude) * oneKmInMiles;
        }

        private static double GetDistanceInKm(
            double latFrom,
            double longFrom)
        {
            // Airport coordinates
            const double latitude = 51.4700223;
            const double longitude = -0.4542955;
            // See https://www.movable-type.co.uk/scripts/latlong.html
            // In meters
            const double R = 6371e3;
            // φ, λ in radians
            const double φ1 = latitude * System.Math.PI / 180;
            double φ2 = latFrom * System.Math.PI / 180;
            double Δφ = (latFrom - latitude) * System.Math.PI / 180;
            double Δλ = (longFrom - longitude) * System.Math.PI / 180;

            double a = System.Math.Sin(Δφ / 2) * System.Math.Sin(Δφ / 2) +
                      System.Math.Cos(φ1) * System.Math.Cos(φ2) *
                      System.Math.Sin(Δλ / 2) * System.Math.Sin(Δλ / 2);
            double c = 2 * System.Math.Atan2(System.Math.Sqrt(a), System.Math.Sqrt(1 - a));
            // In kilometres
            return R * c / 1000;
        }
    }
}
