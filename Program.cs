// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using DesktopCalculatorAutomation.Tests;

class Program
{
    static void Main()
    {
        var test = new CalculatorTests();
        test.AddTwoNumbers();
        test.MultiplyTwoNumbers();
        test.SubtractTwoNumbers();
    }
}

