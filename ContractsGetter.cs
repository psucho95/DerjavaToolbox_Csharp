using RestSharp;
using System.Xml;

namespace WinFormsApp1;

public class ContractsGetter

{

    ProgressBar progressBar;
    static List<string>? gettedRegnums = new List<string>();

    public static void getContractsInfo(List<string> regNums, ProgressBar bar, MaskedTextBox tenderId_input, Button getData_btn)
    {

        var client = new RestClient("http://dp-zakupki-adapters-svc.internal.dp-team.online/v1.0/organizations/regNumber/");
        bar.Value = 20;
        int barVal = 80 / regNums.Count;
        Thread.Sleep(100);
        foreach (var regNum in regNums)
        {
            var request = new RestRequest($"{regNum}", Method.Get);

            var response = client.Execute(request);

            bar.Value = bar.Value + barVal;
            Thread.Sleep(100);
            OutputFilesCreator.fileCreator(response, regNum, tenderId_input.Text);

        }
        bar.Value = 100;
        Thread.Sleep(100);
        tenderId_input.Text = "";
        getData_btn.Enabled = false;
        ToolTipCreator.creteToolTip(bar, 7, -30, 3000, "Ответ сохранен в папке RegNum");
        Thread.Sleep(100);
        bar.Value = 0;

    }
}