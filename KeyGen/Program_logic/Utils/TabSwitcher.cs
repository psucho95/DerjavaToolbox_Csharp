using System.Collections;
using OpenQA.Selenium;

namespace WinFormsApp1.KeyGen.Program_logic.Utils;

public class TabSwitcher
{
    public static void switchTo(IWebDriver driver, int tabNum)
    {
        driver.SwitchTo().Window(driver.WindowHandles.Last());
    }
}