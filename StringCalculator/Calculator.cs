using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                var customDelimitersEndIndex = GetCustomDelimitersEndIndex(input);
                var customDelimiters = GetCustomDelimiters(input, customDelimitersEndIndex);
                operands = input.Substring(customDelimitersEndIndex + 1).Split(customDelimiters.ToArray(), StringSplitOptions.None);
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

        private static IEnumerable<String> GetCustomDelimiters(string input, int customDelimiterEndIndex) {
            return Regex.Matches(input.Substring(2, customDelimiterEndIndex - 2), @"\[[^\]]+\]")
                .Cast<Match>()
                .Select(m => m.Value.Substring(1, m.Length-2));
        }

        private static bool HasCustomDelimiter(string input) {
            return input.StartsWith("//");
        }
    }
}