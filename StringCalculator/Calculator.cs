using System.Linq;

namespace StringCalculator {
    public class Calculator {
        public int Add(string input) {
            if (input == "")
                return 0;
            var operands = input.Split(',');
            return operands.Sum(int.Parse);
        }
    }
}