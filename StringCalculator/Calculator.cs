using System;
using System.Linq;

namespace StringCalculator {
    
    public class Calculator {
        readonly string[] delimiters = {",", "\n"};
        
        public int Add(string input) {
            if (input == "")
                return 0;
            var operands = input.Split(delimiters, StringSplitOptions.None);
            return operands.Sum(int.Parse);
        }
    }
}