using Dadata;
using Dadata.Model;
using System.Xml;
using System.Xml.Linq;

namespace WinFormsApp1.KeyGen.API_logic;

public class ResponseObj
{
    protected static String SysId = null;
    protected static XmlDocument? xmlResponse;

    public static async Task<XmlDocument?> getClientResponseAsync(string INN, Button button)
    {
        try
        {
            var SysIdURL = string.Format("https://egrul.itsoft.ru/{0}.xml", INN);
            xmlResponse = new XmlDocument();
            xmlResponse.Load(SysIdURL);
        }
        catch (Exception exception)
        {
            //OutputFilesCreator.Log_creator(exception);
            throw;
        }
        return xmlResponse;
    }

    public static async Task<Suggestion<Party>> getDaDataAdressAsyncAsync(string INN)
    {
        Suggestion<Party> daDataResponse = null;
        try
        {
            var token = "c36bade7305d2496a6959e4fda047369d033e5cb";
            var url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/party";

            var api = new SuggestClientAsync(token);
            SuggestResponse<Party> result = await api.SuggestParty(INN);
            daDataResponse = result.suggestions[0];
        }
        catch (Exception exception)
        {
            //OutputFilesCreator.Log_creator(exception);
            throw; 
        }

        return daDataResponse;

    }

    public static async Task<String> getSysIdAsync(string INN)
    {
        try
        {
            var SysIdURL = string.Format("https://egrul.itsoft.ru/{0}.xml", INN);
            xmlResponse = new XmlDocument();
            xmlResponse.Load(SysIdURL);

            string startTag = "<fin>";
            string endTag = "</fin>";
            int startIndex = xmlResponse.InnerXml.IndexOf(startTag);
            int endIndex = xmlResponse.InnerXml.IndexOf(endTag);
            XDocument sysIdAsPretty = XDocument.Parse(xmlResponse.InnerXml.Remove(startIndex, endIndex - startIndex + endTag.Length));
            SysId = sysIdAsPretty.ToString();
            
        }
        catch (Exception exception)
        {
            //OutputFilesCreator.Log_creator(exception);
            throw;
        }
        return SysId;
    }
}