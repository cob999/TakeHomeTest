using CustomerInvite.Console;
using NUnit.Framework;
using Shouldly;

namespace CustomerInvite.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void CreateFromJson_GivenSingleJsonLine_ReturnsMatchingCustomer()
        {
            // Arrange
            const string json = "{\"latitude\": \"51.999\", \"user_id\": 99, \"name\": \"John Smith\", \"longitude\": \"-10.888\"}";

            // Act
            var result = Customer.CreateFromJson(json);

            // Assert
            result.UserId.ShouldBe(99);
            result.Name.ShouldBe("John Smith");
            result.Latitude.ShouldBe(51.999);
            result.Longitude.ShouldBe(-10.888);
        }

        [Test]
        public void CreateListFromMultilineJson_GivenTwoJsonLines_ReturnsTwoRecords()
        {
            // Arrange
            const string json = "{\"latitude\": \"51.999\", \"user_id\": 1, \"name\": \"John Smith1\", \"longitude\": \"-10.888\"}\r\n{\"latitude\": \"51.999\", \"user_id\": 2, \"name\": \"John Smith2\", \"longitude\": \"-10.888\"}";

            // Act
            var result = Customer.CreateListFromMultilineJson(json);

            // Assert
            result.Count.ShouldBe(2);
        }
    }
}
