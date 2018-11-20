using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator {
    
    public class Calculator {
        readonly string[] delimiters = {",", "\n"};
        
        public int Add(string input) {
            if (input == "")
                return 0;
            var operands = GetOperands(input);

            return operands.Sum(int.Parse);
        }

        private IEnumerable<string> GetOperands(string input) {
            string[] operands;
            if (HasCustomDelimiter(input)) {
                var delimiterEndIndex = GetCustomDelimitersEndIndex(input);
                var delimiter = GetCustomDelimiter(input, delimiterEndIndex);
                operands = input.Substring(delimiterEndIndex + 1).Split(delimiter, StringSplitOptions.None);
            }
            else {
                operands = input.Split(delimiters, StringSplitOptions.None);
            }
            return operands;
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