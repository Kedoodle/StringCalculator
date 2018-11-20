namespace StringCalculator {
    public class Calculator {
        public int Add(string input) {
            return int.TryParse(input, out var output) ? output : 0;
        }
    }
}