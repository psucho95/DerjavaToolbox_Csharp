using System.Collections;
using WinFormsApp1.CommonUtils;
using static WinFormsApp1.KeyGen.StaticData.StaticData;
using static WinFormsApp1.DerjavaTools;

namespace WinFormsApp1.KeyGen.Program_logic.FileGenerator;

public class SNILS_generator
{
    protected static Dictionary<string, string> snilsDictionary = new Dictionary<string, string>();
    protected static ArrayList existedFileData = new ArrayList();
    protected static string SNILS = null;
    protected static string INN_IP;
    protected static string INN_UL;
    protected static string commonName;
    protected static string FIO;

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

    public static void checkSNILSwarehouse()
    {
        if (!Directory.Exists(snilsfolderPath))
        {
            Directory.CreateDirectory(snilsfolderPath);
        }

        try
        {

            using (StreamReader streamReader = File.OpenText(snilsFilePath))
            {
                string fileData = streamReader.ReadToEnd();
                string[] lines = fileData.Split("\n");
                int linesCount = lines.Length;
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        string[] blocks = line.Split("~");

                        if (!snilsDictionary.ContainsKey(blocks[3]))
                        {
                            snilsDictionary.Add(blocks[3], blocks[5]); //сохраняем пару ИНН ФЛ + СНИЛС
                        }
                        existedFileData.Add(blocks[1] + "~" + blocks[2] + "~" + blocks[3] + "~" + blocks[4] + "~" + blocks[5]);
                        addRow(line);

                    }

                }
            }
        }

        catch (Exception e)
        {
            FilesCreator.Log_creator(e);
            MessageBoxCreator.craeteMessageBox("Произошла ошибка во время разбора файла со СНИЛС", "Ошибка разбора файла СНИЛС", MessageBoxIcon.Error);
        }
    }

    public static void saveUsedSnils(string[] subjectData)
    {
        DateTime date = DateTime.Now; //ToString("d") для получения только даты

        if (!Directory.Exists(snilsfolderPath))
        {
            Directory.CreateDirectory(snilsfolderPath);
        }

        try
        {

            if (commonName == null && INN_UL == null)
            {
                switch (subjectData[0])
                {
                    case "IP":
                        finalResult = "Индвивидуальный предприниматель" + "~" + "Нет данных" + "~" + INN_IP + "~" + FIO + "~" + SNILS + "\n"; break;
                    case "FL":
                        finalResult = "Физическое лицо" + "~" + "Нет данных" + "~" + INN_IP + "~" + FIO + "~" + SNILS + "\n"; break;
                }
            }
            else
            {
                finalResult = commonName + "~" + INN_UL + "~" + INN_IP + "~" + FIO + "~" + SNILS + "\n";
            }

            if (!existedFileData.Contains(finalResult))
            {
                File.AppendAllText(snilsFilePath, date + "~" + finalResult);
                finalResult = null;
            }
            addRow(finalResult);
        }
        catch (Exception e)
        {
            FilesCreator.Log_creator(e);
            MessageBoxCreator.craeteMessageBox("Произошла ошибка во время занесеиня данных о СНИЛС в файл", "Ошибка сохранения данных СНИЛС", MessageBoxIcon.Error);
        }
    }

    public static string setSNILS(Dictionary<string, string> client)
    {
        INN_IP = client["IP"];
        INN_UL = client["UL"];
        commonName = client["CommonName"];
        FIO = client["FIO"];
        if (snilsDictionary.ContainsKey(INN_IP))
        {
            SNILS = snilsDictionary[INN_IP];
        }
        else
        {
            SNILS = GenerateSnils();
        }

        return SNILS;
    }

    public static void addRow(string Line)
    {
        string[] blocks = Line.Split("~");
        SNILS_Table.Rows.Add();
        for (int i = 0; i < blocks.Length; i++)
        {
            SNILS_Table.Rows[^1].Cells[i].Value = blocks[i];
        }
    }
}