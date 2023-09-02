using OpenQA.Selenium;
using WinFormsApp1.CommonUtils;
using WinFormsApp1.KeyGen.API_logic;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;
using WinFormsApp1.KeyGen.Program_logic.Utils;

namespace WinFormsApp1.KeyGen.Program_logic.POM;
using System.Windows.Markup;
using static WinFormsApp1.DerjavaTools;

public class KeyCreationTask
{

    private string[] subjectData;
    private ClientObj client;
    private IWebDriver threadDriver;
    private bool isSuccess;

    public KeyCreationTask(ClientObj client, string[] subjectData)
    {

        this.subjectData = subjectData;
        this.client = client;
    }

    public void runKeyTask()
    {
        try
        {
            Main_BlockerPanel.Enabled = true;
            Main_BlockerPanel.Visible = true;
            Main_BlockerLabel.Enabled = true;
            Main_BlockerLabel.Visible = true;

            RegisterPage registerPage = new RegisterPage(Main_ProgressBar);
            threadDriver = registerPage.getWebDriver();
            registerPage.FillForm(client, subjectData, Main_INN_input.Text);
            registerPage.GetRegister();

            AuthPage authPage = new AuthPage(registerPage);
            authPage.FillAuthData(registerPage);

            PersonalCabinet personalCabinet = new PersonalCabinet(authPage);
            personalCabinet.PersonalCabinetCreateCert();
            isSuccess = personalCabinet.getResult();
            threadDriver.Quit();

        }
        catch (Exception e)
        {
            keyIsNotBeenCreated(e);
        }
        keyHasBeenCreated();

    }

    private async void keyHasBeenCreated()
    {
        SNILS_generator.saveUsedSnils(subjectData);
        client = null;
        if (isSuccess)
        {
            MessageBoxCreator.craeteMessageBox("Ключ " + subjectData[1] + " успешно создан в системе",
                "Успешного создание ключа", MessageBoxIcon.Exclamation);
            Main_ProgressBar.Value = 1;
            Main_ProgressBar.BackColor = Color.ForestGreen;
        }
        else
        {
            MessageBoxCreator.craeteMessageBox("Создание ключа не было завершено", "Внимание", MessageBoxIcon.Hand);
            Main_ProgressBar.BackColor = Color.Red;
        }
        Main_BlockerPanel.Enabled = false;
        Main_BlockerPanel.Visible = false;
        Main_BlockerLabel.Enabled = false;
        Main_BlockerLabel.Visible = false;
        Main_showBrowser_chb.Enabled = false;
        Main_registerINN_btn.Enabled = false;
        Main_downloadEGR_btn.Enabled = false;

        await Task.Delay(5000);
        Main_INN_input.Clear();
        Main_ProgressBar.Value = 0;
        MassPropertyChanger.setDefaultData(Main_InputsPannel);
    }

    private async void keyIsNotBeenCreated(Exception e)
    {
        FilesCreator.Log_creator(e);
        if (e.Message.Contains("ctl00_MainContent_ctl00_ctl03"))
        {
            MessageBoxCreator.craeteMessageBox("Пользователь или запрос уже существует","Внимание", MessageBoxIcon.Hand);
        }
        else
        {
            MessageBoxCreator.craeteMessageBox("Создание ключа не было завершено", "Внимание", MessageBoxIcon.Hand);
        }

        Main_ProgressBar.BackColor = Color.Red;
        threadDriver.Quit();
        Main_BlockerPanel.Enabled = false;
        Main_BlockerPanel.Visible = false;
        Main_BlockerLabel.Enabled = false;
        Main_BlockerLabel.Visible = false;
        Main_showBrowser_chb.Enabled = false;
        Main_registerINN_btn.Enabled = false;
        Main_downloadEGR_btn.Enabled = false;

        await Task.Delay(5000);
        Main_INN_input.Clear();
        Main_ProgressBar.Value = 0;
        MassPropertyChanger.setDefaultData(Main_InputsPannel);
        
    }

}