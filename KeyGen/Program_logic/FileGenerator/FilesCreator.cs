using WinFormsApp1.KeyGen.API_logic;
using static WinFormsApp1.KeyGen.StaticData.StaticData;

namespace WinFormsApp1.KeyGen.Program_logic.FileGenerator;

public static class FilesCreator
{
    static DateTime date = DateTime.Now; //ToString("d") для получения только даты

    public static void Log_creator(Exception exception)
    {
        string dir =  rootDirectory + logFolderPath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        File.AppendAllText(dir + "\\" + date.ToString("d") + ".txt", date + " : " + exception.Message + ":\n" + exception.StackTrace + "\n" + "\n");
    }

    public static async Task saveSysIdAsync(string INN)
    {

        string dir = rootDirectory + sysIdInfosFolderPath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        File.AppendAllText(dir + "\\" + INN + ".xml", await ResponseObj.getSysIdAsync(INN));
    }



}