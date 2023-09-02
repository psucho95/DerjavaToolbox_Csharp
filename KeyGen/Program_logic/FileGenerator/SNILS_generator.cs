using System.Collections;
using WinFormsApp1.CommonUtils;
using WinFormsApp1.KeyGen.API_logic;
using static WinFormsApp1.KeyGen.StaticData.StaticData;
using static WinFormsApp1.DerjavaTools;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp1.KeyGen.Program_logic.FileGenerator;

public class SNILS_generator
{
    protected static Dictionary<string, string> snilsDictionary = new Dictionary<string, string>();
    protected static ArrayList existedFileData = new ArrayList();
    protected static string SNILS = null;
    private static List<string> lines = new List<string>();
    protected static string finalResult;


    private static string GenerateSnils()
    {
        Random rnd = new Random();
        int number = rnd.Next(999999999);
        string numberStr = number.ToString().PadLeft(9, '0');

        int sum = numberStr.Select((val, i) => int.Parse(val.ToString()) * (9 - i)).Sum();

        if (sum > 101)
        {
            sum %= 101;
        }

        string checkSum = sum == 100 || sum == 101 ? "00" : sum.ToString().PadLeft(2, '0');
        return numberStr + checkSum;
    }

    public static List<string> checkSNILSwarehouse()
    {
        lines.Clear();
        if (!Directory.Exists(snilsfolderPath))
        {
            Directory.CreateDirectory(snilsfolderPath);
        }

        try
        {

            using (StreamReader streamReader = File.OpenText(snilsFilePath))
            {
                string fileData = streamReader.ReadToEnd();
                foreach (string singleLine in fileData.Split("\n"))
                {

                    if (!string.IsNullOrEmpty(singleLine))
                    {
                        lines.Add(singleLine);
                    }

                }
            }

            return lines;
        }

        catch (Exception e)
        {
            FilesCreator.Log_creator(e);
            throw;

        }
    }

    public static List<string> saveUsedSnils(ClientObj client)
    {
        DateTime date = DateTime.Now; //ToString("d") для получения только даты

        if (!Directory.Exists(snilsfolderPath))
        {
            Directory.CreateDirectory(snilsfolderPath);
        }

        try
        {
            string FIO = client.Surname + " " + client.Name.Substring(0, 1) + ". " + client.LastName.Substring(0, 1) + ".";
            if (client.SubjectINN.Length == 10 && !string.IsNullOrEmpty(client.CommonName))
            {
                finalResult = client.CommonName + "~" + client.INN_UL + "~" + FIO + "~" + client.INN_IP + "~" + client.SNILS + "\n";
            }
            else if (client.INN_IP.Length == 12 && string.IsNullOrEmpty(client.OGRNIP))
            {
                finalResult = "Индвивидуальный предприниматель" + "~" + "Нет данных" + "~" + FIO + "~" + client.INN_IP + "~" + client.SNILS + "\n";
            }
            else if (client.INN_IP.Length == 12 && client.OGRNIP.Length > 0)
            {
                finalResult = "Физическое лицо" + "~" + "Нет данных" + "~" +  FIO + "~" + client.INN_IP + "~" + client.SNILS + "\n";
            }

            if (!lines.Contains(finalResult))
            {
                lines.Add(finalResult);
                File.AppendAllText(snilsFilePath, date + "~" + finalResult);
            }
            return lines;

        }
        catch (Exception e)
        {
            FilesCreator.Log_creator(e);
            lines.Clear();
            throw;
        }
    }

    public static string setSNILS(string INN_IP)
    {

        foreach (var singleClient in lines)
        {
            string[] blocks = singleClient.Split("~");
            if (blocks[3].Equals(INN_IP))
            {
                SNILS = blocks[5];
            }
            else
            {
                SNILS = GenerateSnils();
            }
        }

        return SNILS;
    }

}