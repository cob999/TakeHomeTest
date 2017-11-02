using System;

namespace CustomerInvite.Console
{
    public class GeographicPoint
    {
        public GeographicPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double DistanceBetweenPointsInKm(GeographicPoint otherPoint)
        {
            const double meanEarthRadiusInKm = 6371;
            const double toRadians = Math.PI / 180;

            var latitude1InRadians = Latitude * toRadians;
            var longitude1InRadians = Longitude * toRadians;

            var latitude2InRadians = otherPoint.Latitude * toRadians;
            var longitude2InRadians = otherPoint.Longitude * toRadians;

            var deltaLongitude = longitude1InRadians - longitude2InRadians;

            var cosOfCentralAngle = Math.Sin(latitude1InRadians) * Math.Sin(latitude2InRadians) +
                                    Math.Cos(latitude1InRadians) * Math.Cos(latitude2InRadians) * Math.Cos(deltaLongitude);

            var centralAngleInRadians = Math.Acos(cosOfCentralAngle);

            var distance = meanEarthRadiusInKm * centralAngleInRadians;

            return Math.Abs(distance);
        }
    }
}