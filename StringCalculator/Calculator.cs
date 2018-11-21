using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32.SafeHandles;

namespace StringCalculator {
    
    public class Calculator {
        readonly string[] delimiters = {",", "\n"};
        
        public int Add(string input) {
            if (input == "")
                return 0;
            var operands = GetOperands(input);
            if (HasNegativeOperands(operands)) {
                var negatives = GetNegativeOperands(operands);
                throw new Exception("Negatives not allowed: " + negatives);
            }
            return operands.Sum(int.Parse);
        }

        private static string GetNegativeOperands(IEnumerable<string> operands) {
            var negatives = operands.Where(operand => int.Parse(operand) < 0)
                .Aggregate((current, operand) => current + ", " + operand);
            return negatives;
        }

        private IEnumerable<string> GetOperands(string input) {
            IEnumerable<string> operands;
            if (HasCustomDelimiter(input)) {
                var delimiterEndIndex = GetCustomDelimitersEndIndex(input);
                var delimiter = GetCustomDelimiter(input, delimiterEndIndex);
                operands = input.Substring(delimiterEndIndex + 1).Split(delimiter, StringSplitOptions.None);
            }
            else {
                operands = input.Split(delimiters, StringSplitOptions.None);
            }
            operands = operands.Where(operand => int.Parse(operand) < 1000);
            return operands;
        }

        private static bool HasNegativeOperands(IEnumerable<string> operands) {
            return operands.Any(operand => int.Parse(operand) < 0);
        }

        private static int GetCustomDelimitersEndIndex(string input) {
            return input.IndexOf("\n");
        }

        private static string[] GetCustomDelimiter(string input, int delimiterEndIndex) {
            return new[] {input.Substring(2, delimiterEndIndex - 2)};
        }

        private static bool HasCustomDelimiter(string input) {
            return input.StartsWith("//");
        }
    }
}