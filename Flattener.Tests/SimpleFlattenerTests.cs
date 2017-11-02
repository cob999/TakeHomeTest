using System;
using Flattener.Core;
using NUnit.Framework;
using Shouldly;

namespace Flattener.Tests
{
    [TestFixture]
    public class SimpleFlattenerTests
    {
        private ICanFlattenArrays _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SimpleFlattener();
        }

        [Test]
        public void Flatten_GivenSingleInteger_ReturnsSingleInteger()
        {
            // Arrange
            var input = new[] {0};

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] {0});
        }

        [Test]
        public void Flatten_GivenTwoIntegers_ReturnsTwoIntegers()
        {
            // Arrange
            var input = new[] {0, 1};

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] {0, 1});
        }

        [Test]
        public void Flatten_GivenOnlyAnArray_ReturnsFlattenedArray()
        {
            // Arrange
            var input = new[] {new[] {0, 1, 2}};

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] {0, 1, 2});
        }

        [Test]
        public void Flatten_GivenTwoArrays_ReturnsFlattenedArray()
        {
            // Arrange
            var input = new[] {new[] {0, 1, 2}, new[] {0, 1, 2}};

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] {0, 1, 2, 0, 1, 2});
        }

        [Test]
        public void Flatten_GivenIntegerAtHead_ReturnsFlattenedArray()
        {
            // Arrange
            var input = new object[] { 0, new[] { 0, 1 }, new[] { 0, 1 } };

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] { 0, 0, 1, 0, 1 });
        }

        [Test]
        public void Flatten_GivenIntegerInMiddle_ReturnsFlattenedArray()
        {
            // Arrange
            var input = new object[] { new[] { 0, 1 }, 1, new[] { 0, 1 } };

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] { 0, 1, 1, 0, 1 });
        }

        [Test]
        public void Flatten_GivenIntegerAtTail_ReturnsFlattenedArray()
        {
            // Arrange
            var input = new object[] { new[] { 0, 1 }, new[] { 0, 1 }, 2 };

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] { 0, 1, 0, 1, 2 });
        }

        [Test]
        public void Flatten_GivenArrayInMiddle_ReturnsFlattenedArray()
        {
            // Arrange
            var input = new object[] {0, new[] {0, 1}, 2};

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] {0, 0, 1, 2});
        }

        [Test]
        public void Flatten_GivenArbitrarilyNestedArray_ReturnsFlattenedArray()
        {
            // Arrange
            var input = new object[]
            {
                0,
                new[] {0, 1, 2},
                new[] {new object[] {0, new[] { 0, 1, 2 }, 2}},
                new[] {0, 1, 2},
                4
            };

            // Act
            var result = _sut.Flatten(input);

            // Assert
            result.ShouldBe(new[] {0, 0, 1, 2, 0, 0, 1, 2, 2, 0, 1, 2, 4});
        }

        [Test]
        public void Flatten_GivenDoubleAsInput_Throws()
        {
            // Arrange
            var input = new[] {1.0};

            // Act/assert
            Should.Throw<InvalidOperationException>(() => { _sut.Flatten(input); }).Message
                .ShouldBe("Input must be an integer or an array of integers.");
        }

        [Test]
        public void Flatten_GivenNullAsInput_Throws()
        {
            // Arrange/act/assert
            Should.Throw<InvalidOperationException>(() => { _sut.Flatten(null); }).Message
                .ShouldBe("Input must be an integer or an array of integers.");
        }

        [Test]
        public void Flatten_GivenArrayOfNullsAsInput_Throws()
        {
            // Arrange
            var input = new object[] {null, null};

            // Act/assert
            Should.Throw<InvalidOperationException>(() => { _sut.Flatten(input); }).Message
                .ShouldBe("Input must be an integer or an array of integers.");
        }
    }
}