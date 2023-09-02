using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static WinFormsApp1.KeyGen.StaticData.StaticData;
namespace WinFormsApp1.KeyGen.Program_logic.POM;

public class BasePage
{
    protected IWebDriver webDriver;
    static bool setHeadless = true;
    static bool setHTTP = false;
    protected string driverLocation;

    public BasePage()
    {
        try
        {


            ChromeOptions options = new ChromeOptions();
            var service = ChromeDriverService.CreateDefaultService();



            options.AddExtensions(CRX_v1_2_13);
            options.AddArguments("--remote-allow-origins=*");
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddExcludedArguments(new List<string>() { "enable-logging" });
            options.AcceptInsecureCertificates = true;


            if (!setHeadless) options.AddArguments();
            else options.AddArguments("--headless=new");

            if (osVersion == "10.0")
            {
                driverLocation = driver_win8_11;
                options.BinaryLocation = chrome115;
            }
            else if (osVersion == "6.1" || osVersion == "6.2" || osVersion == "6.3")
            {
                driverLocation = driver_winXP_7;
                options.BinaryLocation = chrome109;
            }

            else
            {
                driverLocation = driver_win8_11;
                options.BinaryLocation = chrome115;
            }

            service.DriverServicePath = driverLocation;

            webDriver = new ChromeDriver(service, options);

            if (!setHTTP)
            {
                webDriver.Navigate().GoToUrl(HTTPS_uri);
            }
            else webDriver.Navigate().GoToUrl(HTTP_uri);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IWebDriver getWebDriver()
    {
        return webDriver;
    }

    public static void setSetHeadless(bool setHeadlessOption)
    {
        setHeadless = setHeadlessOption;
    }
    public static void setHTTP_protocol(bool isHTTP)
    {
        setHTTP = isHTTP;
    }
}