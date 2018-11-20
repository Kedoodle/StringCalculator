using System;
using System.Reflection;
using StringCalculator;
using Xunit;

namespace StringCalculatorTests {
    public class CalculatorAdd {
        [Fact]
        public void TakesStringAndReturnsInteger() {
            var input = "";
            var calculator = new Calculator();
            var expected = 0;
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("3", 3)]
        public void TakesStringNumberAndReturnsEquivalentInteger(string input, int expected) {
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,5", 8)]
        public void TakesTwoStringNumbersAndReturnsIntegerSum(string input, int expected) {
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("3,5,3,9", 20)]
        public void TakesManyStringNumbersAndReturnsIntegerSum(string input, int expected) {
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("3\n5\n3,9", 20)]
        public void TakesManyStringNumbersWithCommasAndNewlinesAndReturnsIntegerSum(string input, int expected) {
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }
    }
}