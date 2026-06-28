using FlaUI.Core.AutomationElements;
using System.Threading;

namespace DesktopCalculatorAutomation.Pages
{
    public class CalculatorPage
    {
        private Window window;

        public CalculatorPage(Window mainWindow)
        {
            window = mainWindow;
        }

        public void ClickButton(string automationId)
        {
            var button = window.FindFirstDescendant(cf =>
                cf.ByAutomationId(automationId))?.AsButton();

            if (button == null)
                throw new InvalidOperationException($"Button with AutomationId '{automationId}' was not found.");

            button.Click();
            Thread.Sleep(500);
        }

        public string GetResult()
        {
            var resultText = window.FindFirstDescendant(cf =>
                cf.ByAutomationId("CalculatorResults"))?.AsLabel();

            return resultText?.Text;
        }
    }
}
