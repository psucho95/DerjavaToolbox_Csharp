using OpenQA.Selenium;
using WinFormsApp1.CommonUtils;
using WinFormsApp1.KeyGen.API_logic;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;
using WinFormsApp1.KeyGen.Program_logic.Utils;

namespace WinFormsApp1.KeyGen.Program_logic.POM;

using System.Collections.Generic;
using System.Threading;
using System.Windows.Markup;
using static WinFormsApp1.DerjavaTools;

public class KeyCreationTask
{

    private string[] subjectData;
    private ClientObj client;
    private IWebDriver threadDriver;
    private bool isCompleteData = false;
    private RegisterPage registerPage;
    AuthPage authPage;
    PersonalCabinet personalCabinet;


    public KeyCreationTask(ClientObj client, string[] subjectData)
    {

        this.subjectData = subjectData;
        this.client = client;
    }

    public async Task runKeyTask()
    {
        try
        {

            registerPage = new RegisterPage(Main_ProgressBar);
            threadDriver = registerPage.getWebDriver();
            registerPage.FillForm(client, subjectData, client.SubjectINN);
            registerPage.GetRegister();

            authPage = new AuthPage(registerPage);
            authPage.FillAuthData(registerPage);

            personalCabinet = new PersonalCabinet(authPage);
            personalCabinet.PersonalCabinetCreateCert();
            threadDriver.Quit();

            isCompleteData = true;

        }

        catch (Exception exception)
        {
            threadDriver.Quit();
            isCompleteData = false;
            throw;
        }
    }

    public bool isCompleteWork()
    {
        return isCompleteData;
    }
}