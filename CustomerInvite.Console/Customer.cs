using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CustomerInvite.Console
{
    public class Customer
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        public double DistanceFromPointInKm(double latitudeToMeasureFrom, double longitudeToMeasureFrom)
        {
            var thisLocation = new GeographicPoint(Latitude, Longitude);
            var locationToMeasureFrom = new GeographicPoint(latitudeToMeasureFrom, longitudeToMeasureFrom);

            return thisLocation.DistanceBetweenPointsInKm(locationToMeasureFrom);
        }

        public static Customer CreateFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public static List<Customer> CreateListFromMultilineJson(string json)
        {
            var customers = new List<Customer>();

            var reader = new StringReader(json);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var customer = CreateFromJson(line);
                customers.Add(customer);
            }

            return customers;
        }

        public override string ToString()
        {
            return $"{UserId} - {Name}";
        }
    }
}