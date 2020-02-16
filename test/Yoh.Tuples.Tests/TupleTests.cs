using System;
using Xunit;

namespace Yoh.Tuples.Tests
{
    public static class TupleTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(16)]
        [InlineData(32)]
        public static void AddValue_succeeds(int length)
        {
            var tuple = new Tuple();
            for (var index = 0; index < length; index++)
                tuple.AddValue(index, $"My string {index}");

            Assert.Equal(length, tuple.Length);

            for (var index = 0; index < length; index++)
                Assert.Equal($"My string {index}", tuple.GetValue<string>(index));
        }

        [Fact]
        public static void AddValue_at_the_start_succeeds()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");
            tuple.AddValue(0, 'Q');

            Assert.Equal(2, tuple.Length);
            Assert.Equal('Q', tuple.GetValue<char>(0));
            Assert.Equal("My string", tuple.GetValue<string>(1));
        }

        [Fact]
        public static void AddValue_at_the_end_succeeds()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");
            tuple.AddValue(1, 'Q');

            Assert.Equal(2, tuple.Length);
            Assert.Equal("My string", tuple.GetValue<string>(0));
            Assert.Equal('Q', tuple.GetValue<char>(1));
        }

        [Fact]
        public static void AddValue_in_the_middle_succeeds()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");
            tuple.AddValue(1, 'Q');
            tuple.AddValue(1, 42);

            Assert.Equal(3, tuple.Length);
            Assert.Equal("My string", tuple.GetValue<string>(0));
            Assert.Equal('Q', tuple.GetValue<char>(2));
            Assert.Equal(42, tuple.GetValue<int>(1));
        }

        [Fact]
        public static void AddValue_before_the_start_throws()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                tuple.AddValue(-1, 'Q'));
        }

        [Fact]
        public static void AddValue_after_the_end_throws()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                tuple.AddValue(2, 'Q'));
        }

        [Fact]
        public static void RemoveValue_at_the_start_succeeds()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");
            tuple.AddValue(1, 'Q');
            tuple.RemoveValue(0);

            Assert.Equal(1, tuple.Length);
            Assert.Equal('Q', tuple.GetValue<char>(0));
        }

        [Fact]
        public static void RemoveValue_at_the_end_succeeds()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");
            tuple.AddValue(1, 'Q');
            tuple.RemoveValue(1);

            Assert.Equal(1, tuple.Length);
            Assert.Equal("My string", tuple.GetValue<string>(0));
        }

        [Fact]
        public static void RemoveValue_in_the_middle_succeeds()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");
            tuple.AddValue(1, 'Q');
            tuple.AddValue(2, 42);
            tuple.RemoveValue(1);

            Assert.Equal(2, tuple.Length);
            Assert.Equal("My string", tuple.GetValue<string>(0));
            Assert.Equal(42, tuple.GetValue<int>(1));
        }

        [Fact]
        public static void RemoveValue_before_the_start_throws()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                tuple.RemoveValue(-1));
        }

        [Fact]
        public static void RemoveValue_after_the_end_throws()
        {
            var tuple = new Tuple();
            tuple.AddValue(0, "My string");

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                tuple.RemoveValue(1));
        }
    }
}
