# TakeHomeTest

Both exercises are completed using .NET Core and developed with Visual Studio 2017. With .NET core being cross platform it should be possible to build and run this code on any supported .NET Core platform, without the necessity to install VS2017. C# is my primary language, but this is the first .NET Core project I've implemented.

## Array Flattening exercise

The implementation of this is in **Flattener.Core\SimpleFlattener.cs** and the tests are in **Flattener.Tests\SimpleFlattenerTests.cs**
The implementation is kept as simple as possible. It might not be the most performant of implementations but I chose a simple easy to read implementation. The suite of unit tests trys to cover the main edge cases.


## Customer Invite exercise

This is implemented as a command line tool, I felt this was the simplest and most useful way to implement this functionality.

The entry point for the application is in **CustomerInvite.Console\Program.cs**

Sample usage of the application is from the command line, for example:
    dotnet CustomerInvite.dll fromUri https://gist.githubusercontent.com/brianw/19896c50afa89ad4dec3/raw/6c11047887a03483c50017c1d451667fd62a53ca/gistfile1.txt

I decided to pass the url of the customer list to the application from the command line so that the latest version is always used.

With any command line tool having help is crucial for the user so I've added some basic explanation of the commands using some simple extensions from the **Microsoft.Extensions.CommandLineUtils** package. This can be seen by running the following command:
    dotnet CustomerInvite.dll --help

Rather than hardcoding the location of the office this is configurable within the appSettings.json configuration file.

The calculation of distance between two points is encapsulated in the class **CustomerInvite.Console\GeographicPoint.cs** and this is unit tested in **CustomerInvite.Tests\GeographicPointTests.cs**

The goal again is to keep this project as simple and readable as possible. I made the decision not to duplicate error handling that is performed by the libraries being utilised. For example if an invalid uri is passed in as a command line parameter this will be caught by the Flurl library used for the HTTP request and a relevant error will be written to the output. The same is true for the parsing of the JSON customer list.
