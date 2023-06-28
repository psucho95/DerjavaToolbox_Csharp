using System.Runtime.InteropServices.JavaScript;
using RestSharp;

namespace WinFormsApp1;

public class OutputFilesCreator
{
    public static void fileCreator(RestResponse response, string regNum, string tenderId)
    {
        DateTime date = DateTime.Today; //ToString("d") для получения только даты
        string currentDirectory = Environment.CurrentDirectory;

        string fullResponseText = response.Content.ToString();

        string dir = currentDirectory + "\\RegNums";



        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        System.IO.File.AppendAllText(dir + "\\" + date.ToString("d") + ".txt", "\n" + "Информация по regNum " + regNum +" из тендера " + tenderId + " : \n\n" + fullResponseText + "\n");
    }

}