using OpenQA.Selenium;
using WinFormsApp1.CommonUtils;
using WinFormsApp1.KeyGen.API_logic;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;
using WinFormsApp1.KeyGen.Program_logic.Utils;

namespace WinFormsApp1.KeyGen.Program_logic.POM;

using System.Collections.Generic;
using System.Windows.Markup;
using static WinFormsApp1.DerjavaTools;

public class KeyCreationTask
{

    private string[] subjectData;
    private ClientObj client;
    private IWebDriver threadDriver;
    private Dictionary<string, string> isCompleteData;
    private RegisterPage registerPage;
    AuthPage authPage;
    PersonalCabinet personalCabinet;


    public KeyCreationTask(ClientObj client, string[] subjectData)
    {

        this.subjectData = subjectData;
        this.client = client;
    }

    public async Task<bool> runKeyTask()
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
        }
        catch (Exception e)
        {
            threadDriver.Quit();
            isCompleteData.Clear();
            throw;
        }
        return personalCabinet.getResult();
    }
}