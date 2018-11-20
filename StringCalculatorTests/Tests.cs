using System;
using StringCalculator;
using Xunit;

namespace StringCalculatorTests {
    public class CalculatorAdd {
        [Fact]
        public void TakesStringAndReturnsNumber() {
            var input = "";
            var calculator = new Calculator();
            var expected = 0;
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }
    }
}