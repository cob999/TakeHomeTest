using System;
using CustomerInvite.Console;
using NUnit.Framework;
using Shouldly;

namespace CustomerInvite.Tests
{
    [TestFixture]
    public class GeographicPointTests
    {
        // For test cases we take the equator and 8 points 100km away in each cardinal direction and intercardinal direction
        // We repeat the same for the points that are 50km from Intercom office and also points that should be zero distance
        // Used the following tool to generate a quick dataset https://www.movable-type.co.uk/scripts/latlong.html a more accurate dataset may be required.
        [TestCase(0.0, 0.0, 0.8994444444444444, 0.0, 100.0)]
        [TestCase(0.0, 0.0, 0.6358333333333332, 0.6358333333333332, 100.0)]
        [TestCase(0.0, 0.0, 0.0, 0.8994444444444444, 100.0)]
        [TestCase(0.0, 0.0, -0.6358333333333332, 0.6358333333333332, 100.0)]
        [TestCase(0.0, 0.0, -0.8994444444444444, 0.0, 100.0)]
        [TestCase(0.0, 0.0, -0.6358333333333332, -0.6358333333333332, 100.0)]
        [TestCase(0.0, 0.0, 0.0, -0.8994444444444444, 100.0)]
        [TestCase(0.0, 0.0, 0.6358333333333332, -0.6358333333333332, 100.0)]
        [TestCase(0.0, 0.0, 0.0, 0.0, 0.0)]
        [TestCase(53.3393, -6.2576841, 53.788888888888884, -6.257777777777778, 50.0)]
        [TestCase(53.3393, -6.2576841, 53.65611111111111, -5.721111111111111, 50.0)]
        [TestCase(53.3393, -6.2576841, 53.33694444444445, -5.504722222222222, 50.0)]
        [TestCase(53.3393, -6.2576841, 53.02027777777778, -5.729166666666667, 50.0)]
        [TestCase(53.3393, -6.2576841, 52.88972222222222, -6.257777777777778, 50.0)]
        [TestCase(53.3393, -6.2576841, 53.02027777777778, -6.786388888888888, 50.0)]
        [TestCase(53.3393, -6.2576841, 53.33694444444445, -7.010833333333333, 50.0)]
        [TestCase(53.3393, -6.2576841, 53.65611111111111, -6.7941666666666665, 50.0)]
        [TestCase(53.3393, -6.2576841, 53.3393, -6.2576841, 0.0)]
        public void DistanceBetweenPointsInKm_GivenKnownPoints_ReturnsExpectedValue(double lat1, double long1, double lat2, double long2, double knownDistanceInKm)
        {
            var point1 = new GeographicPoint(lat1, long1);
            var point2 = new GeographicPoint(lat2, long2);

            var tolerance = knownDistanceInKm * 0.02;

            var distanceBetweenPoints = point1.DistanceBetweenPointsInKm(point2);

            var difference = Math.Abs(distanceBetweenPoints - knownDistanceInKm);

            difference.ShouldBeLessThanOrEqualTo(tolerance);    
        }
    }
}