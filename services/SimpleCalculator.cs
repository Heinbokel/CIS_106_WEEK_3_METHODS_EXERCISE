using System;
using System.Runtime.CompilerServices;
using CIS_106_WEEK_3_METHODS_EXERCISE.enums;

namespace CIS_106_WEEK_3_METHODS_EXERCISE.services
{
    /// <summary>
    /// Utility class providing basic math operations.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class SimpleCalculator
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts one number from another.
        /// </summary>
        /// <param name="a">The minuend.</param>
        /// <param name="b">The subtrahend.</param>
        /// <returns>The difference of the two numbers.</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="a">The first factor.</param>
        /// <param name="b">The second factor.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides one number by another.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor.</param>
        /// <returns>The quotient of the two numbers.</returns>
        public double Divide(double a, double b)
        {
            double quotient;
            if (b == 0)
            {
                Console.WriteLine("CANNOT DIVIDE BY 0, DIVISOR MUST NOT BE 0.");
                quotient = double.NaN;
            }
            else
            {
                quotient = a / b;
            }
            return quotient;
        }

        /// <summary>
        /// Displays the calculator menu and processes user choice.
        /// </summary>
        public void RunCalculator()
        {
            Console.WriteLine("Welcome to the Simple Calculator!");

            while (true)
            {
                DisplayMenu();

                SimpleCalculatorChoices choice = GetUserChoice();

                if (SimpleCalculatorChoices.EXIT == choice)
                {
                    Console.WriteLine("Thank you for using the Simple Calculator!");
                    return;
                }

                PerformCalculation(choice);
            }
        }

        /// <summary>
        /// Displays the calculator menu.
        /// </summary>
        private void DisplayMenu()
        {
            // Display both the name and the value of each of our choices in the SimpleCalculatorChoices enum.
            foreach(SimpleCalculatorChoices choice in Enum.GetValues(typeof(SimpleCalculatorChoices))) {
                Console.WriteLine($"{choice}: {(int)choice}");
            }
        }

        /// <summary>
        /// Gets and validates the user's choice. 
        /// </summary>
        /// <returns>The user's choice.</returns>
        private SimpleCalculatorChoices GetUserChoice()
        {
            
            while (true)
            {
                Console.Write("Enter your choice (1-5): ");
                if (Enum.TryParse(Console.ReadLine(), out SimpleCalculatorChoices choice))
                {
                    // If our choice is valid (it is defined as one of our enum values) return it.
                    if (Enum.IsDefined(typeof(SimpleCalculatorChoices), choice))
                    {
                        return choice;
                    }
                }

                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
        }

        /// <summary>
        /// Performs the selected calculation based on the user's choice.
        /// </summary>
        /// <param name="choice">The user's choice.</param>
        /// <returns> The result of the operation.</returns>
        private double PerformCalculation(SimpleCalculatorChoices choice)
        {
            double result;

            Console.Write("Enter the first number: ");
            double num1 = GetUserNumberInput();

            Console.Write("Enter the second number: ");
            double num2 = GetUserNumberInput();

            switch (choice)
            {
                case SimpleCalculatorChoices.ADD:
                    result = Add(num1, num2);
                    Console.WriteLine($"Result of addition: {result}");
                    break;
                case SimpleCalculatorChoices.SUBTRACT:
                    result = Subtract(num1, num2);
                    Console.WriteLine($"Result of subtraction: {result}");
                    break;
                case SimpleCalculatorChoices.MULTIPLY:
                    result = Multiply(num1, num2);
                    Console.WriteLine($"Result of multiplication: {result}");
                    break;
                case SimpleCalculatorChoices.DIVIDE:
                    result = Divide(num1, num2);
                    Console.WriteLine($"Result of division: {result}");
                    break;
                default:
                    result = double.NaN;
                    Console.WriteLine($"Error: choice {choice} was not valid somehow.");
                    break;
            }
            return result;
        }

        /// <summary>
        /// Retrieves and validates user input for the numbers to be used in an operation.
        /// </summary>
        /// <returns>The number the user has inputted.</returns>
        private double GetUserNumberInput()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double userNumber))
                {
                    return userNumber;
                }
                Console.WriteLine($"Enter a valid number:");
            }
        }
    }
}