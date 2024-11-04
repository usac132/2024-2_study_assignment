using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        // ---------- TODO ----------
        public double Calculate(double num1, string op, double num2)
        {
            switch (op)
            {
                case "+":
                    this.res = num1 + num2;
                    break;
                case "-": 
                    this.res = num1 - num2;
                    break ; 
                case "*": 
                    this.res = num1 * num2;
                    break ; 
                case "/": 
                    this.res = num1 / num2;
                    break ;
                case "%":
                    this.res = num1 % num2;
                    break;
                case "**": 
                    this.res = Math.Pow(num1, num2);
                    break ; 
                case "G": 
                    this.res = GCD_calculator.GCD(num1, num2);
                    break ;
                case "L":
                    this.res = LCM_calculator.LCM(num1, num2);
                    break ;
                default: throw new FormatException("Operator is not valid");
            }

            return res;
        }

        double res;
        // --------------------
    }

    public class GCD_calculator
    {
        public static double GCD(double num1, double num2)
        {
            if (!(int_verify.is_int(num1) && int_verify.is_int(num2)))
                throw new FormatException("Input must be in the format: integer G integer");
            if (num2 == 0) return num1;
            else return GCD_calculator.GCD(num2, num1%num2);
        }
    }
    public class LCM_calculator
    {
        public static double LCM(double num1, double num2)
        {
            if (!(int_verify.is_int(num1) && int_verify.is_int(num2)))
                throw new FormatException("Input must be in the format: integer L integer");
            return (num1 * num2) / GCD_calculator.GCD(num1, num2);
        }
    }

    public class int_verify
    {
        public static bool is_int(double num)
        {
            if (num % 1 == 0) return true;
            else return false;
        }
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/