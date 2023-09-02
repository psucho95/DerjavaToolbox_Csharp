namespace WinFormsApp1.KeyGen.StaticData;

public static class StaticData
{
   public static string rootDirectory = Environment.CurrentDirectory;
   public static string osVersion = Environment.OSVersion.Version.Major.ToString() + "." + Environment.OSVersion.Version.Minor.ToString();
   public static string logFolderPath = "\\Logs";
   public static string sysIdInfosFolderPath = "\\SystemIdInfos";
   public static string snilsFilePath = Environment.CurrentDirectory + "\\SNILSstorage\\ExistingSNILS.txt";
   public static string snilsfolderPath = Environment.CurrentDirectory + "\\SNILSstorage";
   public static string CRX_v1_2_13 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Extensions\\iifchhfnnmpdbibifmljnfjhpififfog\\1.2.13_0.crx";
   public static string driver_winXP_7 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win7andLower";
   public static string driver_win8_11 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win8andHigher";
   public static string chrome115 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win8andHigher\\chromium-gost-115\\chrome.exe";
   public static string chrome109 = rootDirectory + "\\ProgramData\\WebDriver\\Chromium\\Win7andLower\\chromium-gost-109\\chrome.exe";
   public static string HTTPS_uri = "https://testca2012.cryptopro.ru/UI/1/RegRequest.aspx";
   public static string HTTP_uri = "http://testca2012.cryptopro.ru/UI/1/RegRequest.aspx";
   public static string cspX64 = rootDirectory + "C:\\Program Files\\Crypto Pro\\CSP\\cpanel.cpl";
   public static string cspX32 = rootDirectory + "C:\\Program Files (x86)\\Crypto Pro\\CSP\\cpanel.cpl";
   public static string cspPluginX64 = rootDirectory + "C:\\Program Files\\Crypto Pro\\CAdES Browser Plug-in\\config.html";
   public static string cspPluginX32 = rootDirectory + "C:\\Program Files (x86)\\Crypto Pro\\CAdES Browser Plug-in\\config.html";
   public static string SysIdPath = rootDirectory + "SystemIdInfos/";
}