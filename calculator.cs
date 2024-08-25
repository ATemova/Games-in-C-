using System;

class SimpleCalculator
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator");
        Console.WriteLine("Options: Add, Subtract, Multiply, Divide");
        string operation = Console.ReadLine().ToLower();

        Console.Write("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = double.Parse(Console.ReadLine());

        double result = 0;
        bool validOperation = true;

        switch (operation)
        {
            case "add":
                result = num1 + num2;
                break;
            case "subtract":
                result = num1 - num2;
                break;
            case "multiply":
                result = num1 * num2;
                break;
            case "divide":
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    Console.WriteLine("Error! Division by zero.");
                    validOperation = false;
                }
                break;
            default:
                Console.WriteLine("Invalid operation.");
                validOperation = false;
                break;
        }

        if (validOperation)
            Console.WriteLine($"The result is: {result}");
    }
}
