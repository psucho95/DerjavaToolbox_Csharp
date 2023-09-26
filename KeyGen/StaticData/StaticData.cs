using Microsoft.Win32;

namespace WinFormsApp1.KeyGen.StaticData;


public static class StaticData
{
   public static string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
   public static string rootDirectory = Environment.CurrentDirectory;

   public static string osVersion = Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString();

   public static string logFolderPath = myDocumentsPath + "\\DerzhavaToolbox\\Logs";
   public static string sysIdInfosFolderPath = myDocumentsPath + "\\DerzhavaToolbox\\SystemIdInfos";
   public static string snilsFilePath = myDocumentsPath + "\\DerzhavaToolbox\\SNILSstorage\\ExistingSNILS.txt";
   public static string snilsfolderPath = myDocumentsPath + "\\DerzhavaToolbox\\SNILSstorage";

   public static string CRX_v1_2_13 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Extensions\\iifchhfnnmpdbibifmljnfjhpififfog\\1.2.13_0.crx";
   public static string driver_winXP_7 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win7andLower";
   public static string driver_win8_11 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win8andHigher";
   public static string chrome117 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win8andHigher\\chromium-gost-117\\chrome.exe";
   public static string chrome109 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win7andLower\\chromium-gost-109\\chrome.exe";

   public static string HTTPS_uri = "https://testca2012.cryptopro.ru/UI/1/RegRequest.aspx";
   public static string HTTP_uri = "http://testca2012.cryptopro.ru/UI/1/RegRequest.aspx";
   public static string csp = getCSPlocation();
   public static string cspPlugin = getCSP_pluin_location();
   public static string rootKeyThumbPrint = "18F7C1FCC3090203FD5BAA2F861A754976C8DD25";
   public static string neededDataFolder = "\\NeededData";
   

    private static string getCSPlocation()
   {
       string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products\08F19F05793DC7340B8C2621D83E5BE5\InstallProperties";
       string location = null;
       using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
       {
           if (key != null)
           {
               location = key.GetValue("InstallLocation") as string;
           }

       }

       return location;
   }
   private static string getCSP_pluin_location()
   {
       string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products\EE7CC21E7B63AAA429E4F2C57DB5ECFC\InstallProperties";
       string location = null;
       using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
       {
           if (key != null)
           {
               location = key.GetValue("InstallLocation") as string;
           }

       }

       return location;
   }
}

