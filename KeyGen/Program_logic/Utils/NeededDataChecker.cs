namespace DerjavaToolbox.KeyGen.Program_logic.Utils;

using Microsoft.Win32;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static WinFormsApp1.KeyGen.StaticData.StaticData;


public class NeededDataChecker
{
    private static bool rootKey = false;
    private static bool CSPkey = false;
    private static bool CSPpluginKey = false;
    private static Dictionary<string, bool> neededData = new Dictionary<string, bool>();

    private static bool isROOTcertExist()
    {
        List<string> rootThumbPrints = new List<string>();
        try
        {
            X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            foreach (X509Certificate2 certificate in store.Certificates)
            {
                rootThumbPrints.Add(certificate.Thumbprint);
            }
            store.Close();
            if (rootThumbPrints.Contains(rootKeyThumbPrint))
            {
                rootKey = true;
            }
            else
            {
                rootKey = false;
            }
        }
        catch (Exception e)
        {
            rootKey = false;
        }
        return rootKey;
    }
    private static bool isCSPinstalled()
    {

        if (File.Exists(cspX64) || File.Exists(cspX32))
        {
            CSPkey = true;
        }
        else
        {
            CSPkey = false;
        }
        return CSPkey;
    }
    private static bool isCSPpluginInstalled()
    {
        if (File.Exists(cspPluginX64) || File.Exists(cspPluginX32))
        {
            CSPpluginKey = true;
        }
        else
        {
            CSPpluginKey = false;
        }
        return CSPpluginKey;
    }

    public static Dictionary<string,bool> neededDataChecker()
    {
        neededData.Add("ROOTcerExist", isROOTcertExist());
        neededData.Add("isCSPinstalled", isCSPinstalled());
        neededData.Add("isCSPpluginInstalled", isCSPpluginInstalled());
        return neededData;
    }

    public static Version getCSPversion()
    {
        string registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-18\Products\08F19F05793DC7340B8C2621D83E5BE5\InstallProperties";
        string displayVersion = "";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
            {
                if (key != null)
                {
                    displayVersion = key.GetValue("DisplayVersion") as string;
                }

            }
            Version version = Version.Parse(displayVersion);

            int major = version.Major;       // 5
            int minor = version.Minor;       // 0
            int build = version.Build;       // 12
            int revision = version.Revision;

        return version;
    }
}