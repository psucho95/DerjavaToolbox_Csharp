using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;
using static WinFormsApp1.DerjavaTools;
using WinFormsApp1.KeyGen.Program_logic.Utils;

namespace WinFormsApp1.KeyGen.Program_logic.POM;

public class PersonalCabinet
{
    IWebDriver PersonalCabinetDriver;

    public PersonalCabinet(AuthPage authPage)
    {
        this.PersonalCabinetDriver = authPage.getAuthPageDriver();
    }

    By validCertsPage = By.Id("ctl00_ctl00_ctl00_MainContent_MainContent_Splitter_LoginView1_UserTree_N1_0");
    By createCert = By.Id("ctl00_ctl00_ctl00_MainContent_MainContent_Splitter_MainContentUser_ctl01_DXI1_Img");
    By expectedGOSTdata = By.Id("ctl00_ctl00_MainContent_MainContent_ctl01_ctl03_dxSelectHashAlgorithmList_I");
    By createCertFile = By.Id("ctl00_ctl00_MainContent_MainContent_ctl01_ctl03_CreateRequestButton_CD");
    By reloadButton = By.Id("ctl00_ctl00_ctl00_MainContent_MainContent_Splitter_MainContentUser_ctl01_DXI0_Img");
    By setupCertButton = By.Id("ctl00_ctl00_ctl00_MainContent_MainContent_Splitter_MainContentUser_RequestsGridView_cell0_6_ctl00");
    By setupCertLocal = By.Id("ctl00_ctl00_MainContent_MainContent_ctl01_ctl03_InstallCertificateButton_CD");
    By confirmSettingUp = By.XPath(".//div[@id='ctl00_ctl00_MainContent_MainContent_ctl01_ctl03_ConfirmInstallButton']");
    bool thisSuccess = false;


    public void PersonalCabinetCreateCert()
    {
        try
        {
            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementIsVisible(validCertsPage));
            PersonalCabinetDriver.FindElement(validCertsPage).Click();
            Main_ProgressBar.Value = 35;
            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementIsVisible(createCert));
            PersonalCabinetDriver.FindElement(createCert).Click();
            Main_ProgressBar.Value = 40;
            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(createCertFile));

            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.TextToBePresentInElement(PersonalCabinetDriver.FindElement(expectedGOSTdata), "ГОСТ Р 34.11-2012 256 бит"));
            PersonalCabinetDriver.FindElement(createCertFile).Click();
            Main_ProgressBar.Value = 50;
            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(reloadButton)); // Ожидалка генерации файла от крипты
            PersonalCabinetDriver.FindElement(reloadButton).Click();
            Main_ProgressBar.Value = 60;
            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(setupCertButton));
            PersonalCabinetDriver.FindElement(setupCertButton).Click();
            Main_ProgressBar.Value = 70;
            TabSwitcher.switchTo(PersonalCabinetDriver, 2);
            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(5));

            new WebDriverWait(PersonalCabinetDriver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable(setupCertLocal));
            PersonalCabinetDriver.FindElement(setupCertLocal).Click();
            Main_ProgressBar.Value = 80;
            try
            { // оджидалка окончания последнего взаимодействия с криптой
                Thread.Sleep(8000); // ожидание в миллисекундах
            }
            catch (ThreadInterruptedException e)
            {
                FilesCreator.Log_creator(e);
            }
            PersonalCabinetDriver.FindElement(confirmSettingUp).Click();
            Main_ProgressBar.Value = 90;
            try
            { // ожидалка перед кликом по алерту
                Thread.Sleep(5000);
            }
            catch (ThreadInterruptedException e)
            {
                FilesCreator.Log_creator(e);
            }

            IAlert alert = PersonalCabinetDriver.SwitchTo().Alert();
            String alertText = alert.Text;
            if (alertText.Equals("Сертификат успешно установлен!"))
            {
                alert.Accept();
            }
            PersonalCabinetDriver.Quit();
            thisSuccess = true;
            Main_ProgressBar.Value = 100;

        }
        catch (Exception e)
        {
            FilesCreator.Log_creator(e);
            PersonalCabinetDriver.Quit();
            thisSuccess = false;
        }

    }

    public bool getResult()
    {
        return thisSuccess;
    }
}