using Flattener.Core;
using NUnit.Framework;
using Shouldly;

namespace Flattener.Tests
{
    [TestFixture]
    public class SetTests
    {
        [Test]
        public void CanWeResize()
        {
            var sut = new Set<int>();

            for (int i = 0; i < 10; i++)
            {
                sut.Add(i);
            }
        }

        [Test]
        public void Contains_WithEmptySet_ReturnsFalse()
        {
            var sut = new Set<int>();

            sut.Contains(1).ShouldBeFalse();
        }

        [TestCase(1, true)]
        [TestCase(2, false)]
        public void Contains_WithOneValueSet_ReturnsExpected(int matchValue, bool expected)
        {
            var sut = new Set<int>();

            sut.Add(1);

            sut.Contains(matchValue).ShouldBe(expected);
        }

        [Test]
        public void Count_WithEmptySet_ReturnsZero()
        {
            var sut = new Set<int>();

            sut.Count.ShouldBe(0);
        }

        [Test]
        public void Count_AfterAdd_ReturnsExpected()
        {
            var sut = new Set<int>();

            sut.Add(1);

            sut.Count.ShouldBe(1);
        }

    }
}