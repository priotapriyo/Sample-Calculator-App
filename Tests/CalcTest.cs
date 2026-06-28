using DesktopCalculatorAutomation.Utils;
using DesktopCalculatorAutomation.Pages;
using System;

namespace DesktopCalculatorAutomation.Tests
{
    public class CalculatorTests : BaseTest
    {
        public void AddTwoNumbers()
        {
            StartCalculator();

            var calc = new CalculatorPage(mainWindow!);

            Console.WriteLine("[DEBUG] Clicking button: 1");
            calc.ClickButton("num1Button");

            Console.WriteLine("[DEBUG] Clicking button: +");
            calc.ClickButton("plusButton");

            Console.WriteLine("[DEBUG] Clicking button: 2");
            calc.ClickButton("num2Button");

            Console.WriteLine("[DEBUG] Clicking button: =");
            calc.ClickButton("equalButton");

            string result = calc.GetResult();
            Console.WriteLine("[DEBUG] Result retrieved: " + result);

            CloseApp();
        }

        public void MultiplyTwoNumbers()
        {
            StartCalculator();

            var calc = new CalculatorPage(mainWindow!);

            Console.WriteLine("[DEBUG] Clicking button: 4");
            calc.ClickButton("num4Button");

            Console.WriteLine("[DEBUG] Clicking button1: *");
            Console.WriteLine("[DEBUG] Clicking : *");
            calc.ClickButton("multiplyButton");

            Console.WriteLine("[DEBUG] Clicking button: 6");
            calc.ClickButton("num6Button");

            Console.WriteLine("[DEBUG] Clicking button: =");
            calc.ClickButton("equalButton");

            string result = calc.GetResult();
            Console.WriteLine("[DEBUG] Result retrieved update: " + result);

            CloseApp();
        }
    }
}
