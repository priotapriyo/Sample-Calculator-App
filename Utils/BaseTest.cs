using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FlaUI.Core.Tools;

namespace DesktopCalculatorAutomation.Utils
{
    public class BaseTest
    {
        protected Application? app;
        protected UIA3Automation? automation;
        protected Window? mainWindow;

        public void StartCalculator()
        {
            automation = new UIA3Automation();

            Console.WriteLine("[DEBUG] Launching Calculator app...");
            app = Application.Launch("calc.exe");

            // calc.exe on Windows 10/11 is a UWP launcher that exits immediately,
            // so GetMainWindow(app) always returns null. Instead, find the window
            // by name from the desktop, which works for both Win32 and UWP Calculator.
            mainWindow = Retry.WhileNull(
                () => automation.GetDesktop()
                                .FindFirstChild(cf => cf.ByName("Calculator"))
                                ?.AsWindow(),
                TimeSpan.FromSeconds(10)
            ).Result;

            if (mainWindow == null)
                throw new InvalidOperationException("Calculator main window was not found within the timeout period.");

            Console.WriteLine("[DEBUG] Calculator main window found.");

            // Wait for the Calculator UI content to fully render inside the window
            Retry.WhileNull(
                () => mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("num1Button")),
                TimeSpan.FromSeconds(10)
            );

            Console.WriteLine("[DEBUG] Calculator UI fully loaded and ready.");
        }

        public void CloseApp()
        {
            automation?.Dispose();
            app?.Close();
            Console.WriteLine("[DEBUG] Calculator app closed.");
        }
    }
}
