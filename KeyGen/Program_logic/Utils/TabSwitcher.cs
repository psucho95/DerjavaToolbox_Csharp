using System.Collections;
using OpenQA.Selenium;

namespace WinFormsApp1.KeyGen.Program_logic.Utils;

public class TabSwitcher
{
    public static void switchTo(IWebDriver driver, int tabNum)
    {
        List<string> Tabs = new List<string>(driver.WindowHandles);
        Console.WriteLine();
        //driver.SwitchTo(Tabs.Find(tabNum - 1));
    }
}