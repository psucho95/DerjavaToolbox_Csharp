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
    private static Dictionary<string, string> IPsDict = new Dictionary<string, string>();
    private static bool isValid = false;
    private static List<string> SNILSwithSameINN = new List<string>();


    public static string GenerateSnils()
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

        if (File.Exists(snilsFilePath))
        {
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
                            string[] arrBlock = singleLine.Split("~");
                            if (!IPsDict.ContainsKey(arrBlock[5]))
                            {
                                IPsDict.Add(arrBlock[5], arrBlock[4]);
                            }
                        }

                    }
                }
            }

            catch (Exception e)
            {
                FilesCreator.Log_creator(e);
                throw;
            }
        }
        else
        {
            using (StreamWriter sw = File.CreateText(snilsFilePath))
            {

            }
        }
        return lines;
    }

    public static List<string> saveUsedSnils(ClientObj client, string[] subjectInfo)
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
            else if (client.INN_IP.Length == 12 && subjectInfo[0] == "FL")
            {
                finalResult = "Физическое лицо" + "~" + "Нет данных" + "~" + FIO + "~" + client.INN_IP + "~" + client.SNILS + "\n";
            }
            else if (client.INN_IP.Length == 12 && client.OGRNIP.Length > 0 && subjectInfo[0] == "IP")
            {
                finalResult = "Инд. предприниматель" + "~" + "Нет данных" + "~" + FIO + "~" + client.INN_IP + "~" + client.SNILS + "\n";
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
        SNILSwithSameINN.Clear();
        foreach (var pair in IPsDict)
        {
            if (checkSNILSvalid(pair.Key) && pair.Value == INN_IP)
            {
                SNILS = pair.Key;
                SNILSwithSameINN.Add(pair.Key);
            }
        }

        if (SNILS == null || SNILS == "" || string.IsNullOrEmpty(SNILS))
        {
            SNILS = GenerateSnils();
        }

        return SNILS;
    }

    protected static bool checkSNILSvalid(string SNILS)
    {
        if (!String.IsNullOrEmpty(SNILS))
        {

            List<string> error = new List<string>();

            string number = SNILS.Replace(" ", "").Replace("-", "");


            string control = number.Substring(number.Length - 2);

            number = number.Substring(0, 9);

            if (error.Count == 0)
            {

                int result = 0;
                int total = number.Length;
                for (int i = 0; i < total; i++)
                {
                    result += (total - i) * int.Parse(number[i].ToString());
                }
 
                if (result == 100 || result == 101) result = 0;
                if (result > 101) result %= 101;
                if (result.ToString() == control) isValid = true;
                else isValid = false;
            }
        }

        return isValid;
    }

    public static List<string> getSameSNILS()
    {
        return SNILSwithSameINN;
    }
}