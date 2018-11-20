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
    }
}