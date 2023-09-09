using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using static WinFormsApp1.DerjavaTools;


namespace WinFormsApp1.KeyGen.Program_logic.POM;

public class AuthPage
{
    IWebDriver AuthPageDriver;

    public AuthPage(RegisterPage registerPage)
    {
        this.AuthPageDriver = registerPage.getMainPageDriver();
    }
    By hereRedirect = By.Id("ctl00_MainContent_ctl00_ctl03");
    By loginInput = By.Id("ctl00_MainContent_MasterPageBodyASPxRoundPanel_ASPxRoundPanel1_LoginUser_UserName_I");
    By passwordInput = By.Id("ctl00_MainContent_MasterPageBodyASPxRoundPanel_ASPxRoundPanel1_LoginUser_Password_I");
    By authButton = By.Id("ctl00_MainContent_MasterPageBodyASPxRoundPanel_ASPxRoundPanel1_LoginUser_LoginButton_CD");
   
    public async Task FillAuthData(RegisterPage registerPage)
    {
        try
        {
            new WebDriverWait(AuthPageDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(hereRedirect));
        AuthPageDriver.FindElement(hereRedirect).Click();
        Main_ProgressBar.Value = 16;
        AuthPageDriver.FindElement(loginInput).SendKeys(registerPage.savedLogin);
        Main_ProgressBar.Value = 20;
        AuthPageDriver.FindElement(passwordInput).SendKeys(registerPage.savedPassword);
        Main_ProgressBar.Value = 25;
        AuthPageDriver.FindElement(authButton).Click();
        Main_ProgressBar.Value = 30;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public IWebDriver getAuthPageDriver()
    {
        return AuthPageDriver;
    }
}