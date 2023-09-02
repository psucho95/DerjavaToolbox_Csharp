using OpenQA.Selenium;
using System.Security.AccessControl;
using WinFormsApp1.KeyGen.API_logic;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;

namespace WinFormsApp1.KeyGen.Program_logic.POM;

public class RegisterPage : BasePage
{
    private IWebDriver mainPageDriver;
    private ProgressBar progressBar;
    By commonName = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl18_I");
    By surname = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl24_I");
    By nameAndLastName = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl30_I");
    By adressFull = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl54_I");
    By adressDistrict = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl42_I");
    By adressCity = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl48_I");
    By orgName = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl60_I");
    By subdivision = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl66_I");
    By jobTitle = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl72_I");
    By OGRN = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl78_I");
    By snils = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl84_I");
    By innUL = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl96_I");
    By innIP = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl90_I");
    By OGRNIP = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl126_I");
    By login = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_LoginTextBox_I");
    By loginSelector = By.Id("dxeHyperlink_Aqua link-modified");
    By password = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_NewPasswordTextBox_I");
    By registrBTN = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_FinishButton_CD");
    private string loginString;
    private string passwordString;

    public string savedLogin
    {
        get => loginString;
    }
    public string savedPassword
    {
        get => passwordString;
    }
    By ErrorMessageEl = By.Id("ctl00_MainContent_ctl01_RegistrationPanel_ctl05");
    private bool isErrorMessage = false;

    public RegisterPage(ProgressBar progressBar)
    {
        mainPageDriver = getWebDriver();
        this.progressBar = progressBar;
    }
    public IWebDriver getMainPageDriver()
    {
        return mainPageDriver;
    }
    private String getLogin()
    {
        Random random = new Random();
        char[] charArrsLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        char[] charArrsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] loginArr = new char[20];
        for (int i = 0; i < loginArr.Length; i++)
        {
            if (i % 2 == 0)
            {
                loginArr[i] = charArrsLower[random.Next(charArrsLower.Length)];
            }
            else
            {
                loginArr[i] = charArrsUpper[random.Next(charArrsUpper.Length)];
            }
        }
        return new string(loginArr);
    }

    public void FillForm(ClientObj Client, String[] subjectState, String INN_from_input)
    {
        if (INN_from_input.Length == 10 && subjectState[0].Equals("UL"))
        {
            try
            {
                mainPageDriver.FindElement(commonName).SendKeys(Client.CommonName);
                progressBar.Value = 1;
                mainPageDriver.FindElement(surname).SendKeys(Client.Surname);
                progressBar.Value = 2;
                mainPageDriver.FindElement(nameAndLastName).SendKeys(Client.NameLastName);
                progressBar.Value = 3;
                mainPageDriver.FindElement(adressFull).SendKeys(Client.FullAdress);
                progressBar.Value = 4;
                mainPageDriver.FindElement(adressDistrict).SendKeys(Client.Region);
                progressBar.Value = 5;
                mainPageDriver.FindElement(adressCity).SendKeys(Client.City);
                progressBar.Value = 6;
                mainPageDriver.FindElement(orgName).SendKeys(Client.OrgName);
                progressBar.Value = 7;
                mainPageDriver.FindElement(subdivision).SendKeys(Client.Subdivision);
                progressBar.Value = 8;
                mainPageDriver.FindElement(jobTitle).SendKeys(Client.JobTitle);
                progressBar.Value = 9;
                mainPageDriver.FindElement(snils).SendKeys(Client.SNILS);
                progressBar.Value = 10;
                mainPageDriver.FindElement(OGRN).SendKeys(Client.OGRN);
                progressBar.Value = 11;
                mainPageDriver.FindElement(innIP).SendKeys(Client.INN_IP);
                progressBar.Value = 12;
                mainPageDriver.FindElement(innUL).SendKeys(Client.INN_UL);
                progressBar.Value = 15;
            }
            catch (Exception e)
            {
                FilesCreator.Log_creator(e);
            }
        }

        else if (INN_from_input.Length == 12 && subjectState[0].Equals("IP"))
        {
            try
            {

                mainPageDriver.FindElement(commonName).SendKeys(subjectState[1] + " " + Client.Surname + Client.NameLastName);
                progressBar.Value = 1;
                mainPageDriver.FindElement(surname).SendKeys(Client.Surname);
                progressBar.Value = 3;
                mainPageDriver.FindElement(nameAndLastName).SendKeys(Client.NameLastName);
                progressBar.Value = 6;
                mainPageDriver.FindElement(jobTitle).SendKeys("Индивидуальный предприниматель");
                progressBar.Value = 9;
                mainPageDriver.FindElement(snils).SendKeys(Client.SNILS);
                progressBar.Value = 10;
                mainPageDriver.FindElement(OGRNIP).SendKeys(Client.OGRNIP);
                progressBar.Value = 13;
                mainPageDriver.FindElement(innIP).SendKeys(Client.INN_IP);
                progressBar.Value = 15;

            }
            catch (Exception e)
            {
                FilesCreator.Log_creator(e);
            }
        }
        else if (INN_from_input.Length == 12 && subjectState[0].Equals("FL"))
        {
            try
            {

                mainPageDriver.FindElement(commonName).SendKeys(subjectState[1] + " " + Client.Surname + Client.NameLastName);
                progressBar.Value = 1;
                mainPageDriver.FindElement(surname).SendKeys(Client.Surname);
                progressBar.Value = 3;
                mainPageDriver.FindElement(nameAndLastName).SendKeys(Client.NameLastName);
                progressBar.Value = 6;
                mainPageDriver.FindElement(jobTitle).SendKeys("Физическое лицо");
                progressBar.Value = 9;
                mainPageDriver.FindElement(snils).SendKeys(Client.SNILS);
                progressBar.Value = 10;
                mainPageDriver.FindElement(innIP).SendKeys(Client.INN_IP);
                progressBar.Value = 13;
            }
            catch (Exception e)
            {
                FilesCreator.Log_creator(e);
            }
        }

    }
    public void GetRegister()
    {
        try
        {

            IWebElement loginField = mainPageDriver.FindElement(login);
            ((IJavaScriptExecutor)mainPageDriver).ExecuteScript("arguments[0].scrollIntoView();", mainPageDriver.FindElement(By.Id("credentials")));
            loginString = getLogin();
            loginField.Click();
            loginField.SendKeys(loginString);
            IWebElement pwdForm = mainPageDriver.FindElement(password);
            pwdForm.Click();
            passwordString = pwdForm.GetAttribute("value");
            ((IJavaScriptExecutor)mainPageDriver).ExecuteScript("arguments[0].scrollIntoView();", mainPageDriver.FindElement(registrBTN));
            mainPageDriver.FindElement(registrBTN).Click();
        }
        catch (Exception e)
        {
            FilesCreator.Log_creator(e);
        }
    }



}
