using System;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Configuration;

namespace CustomerInvite.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Sample usage:
            // dotnet CustomerInvite.dll fromUri https://gist.githubusercontent.com/brianw/19896c50afa89ad4dec3/raw/6c11047887a03483c50017c1d451667fd62a53ca/gistfile1.txt
            // dotnet CustomerInvite.dll --help
            // dotnet CustomerInvite.dll fromUri --help

            // Read application settings
            var applicationSettings = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            var officeLatitude = double.Parse(applicationSettings["officeLatitude"]);
            var officeLongitude = double.Parse(applicationSettings["officeLongitude"]);

            // Setup command line format and help
            var app = new Microsoft.Extensions.CommandLineUtils.CommandLineApplication();

            const string helpFlags = "-? | -h | --help";

            var exitCode = 1; // Convention is to return 0 for completed execution, 1 otherwise

            app.Command("fromUri", config => {
                config.Description = "Invite customers from a given uri";
                config.HelpOption(helpFlags);
                var arg = config.Argument("uri", "Uri to obtain customer list from");
                config.OnExecute(async () => exitCode = await ExecuteFromUriCommand(arg.Value, officeLatitude, officeLongitude));
            });

            app.HelpOption(helpFlags);
            app.Execute(args);

            Environment.Exit(exitCode);
        }

        private static async Task<int> ExecuteFromUriCommand(string uri, double officeLatitude, double officeLongitude)
        {
            try
            {
                var multiLineJson = await uri.GetStringAsync();

                var allCustomers = Customer.CreateListFromMultilineJson(multiLineJson);

                var sortedCustomersWithinRange = allCustomers
                    .Where(c => c.DistanceFromPointInKm(officeLatitude, officeLongitude) <= 100.0)
                    .OrderBy(c => c.UserId)
                    .ToList();

                sortedCustomersWithinRange.ForEach(System.Console.WriteLine);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return 1;
            }

            return 0;
        }
    }
}
