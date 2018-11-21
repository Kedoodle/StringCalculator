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

        [Theory]
        [InlineData("//;\n1;2", 3)]
        public void TakesManyStringNumbersWithCustomDelimiterAndReturnsIntegerSum(string input, int expected) {
            var calculator = new Calculator();
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakesNegativeStringNumbersAndThrowsException() {
            var input = "-1,2,-3";
            var calculator = new Calculator();
            var ex = Assert.Throws<Exception>(() => calculator.Add(input));
            Assert.Equal("Negatives not allowed: -1, -3", ex.Message);
        }

        [Fact]
        public void IgnoresNumbersGreaterThanOrEqualTo1000() {
            var input = "1000,1001,2";
            var calculator = new Calculator();
            var expected = 2;
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakesCustomDelimiterWithNewFormat() {
            var input = "//[***]\n1***2***3";
            var calculator = new Calculator();
            var expected = 6;
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakesManyCustomDelimitersWithNewFormat() {
            var input = "//[*][%]\n1*2%3";
            var calculator = new Calculator();
            var expected = 6;
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakesManyCustomMultiCharacterDelimitersWithNewFormat() {
            var input = "//[***][#][%]\n1***2#3%4";
            var calculator = new Calculator();
            var expected = 10;
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TakesManyCustomMultiCharacterDelimitersWithNumbersInMiddleWithNewFormat() {
            var input = "//[*1*][%]\n1*1*2%3";
            var calculator = new Calculator();
            var expected = 6;
            var actual = calculator.Add(input);
            Assert.Equal(expected, actual);
        }
        
        
    }
}