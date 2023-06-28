using System.Xml;
using RestSharp;

namespace WinFormsApp1;

public static class RegNumInfosGetter
{
    static List<string>? TagInfo = new List<string>();

    static XmlNodeList regNumCollection;
    
    

    public static List<string> getTagInfo(string tenderId) // 5555
    {
            var client = new RestClient("https://dp-zakupki-adapters-svc.internal.dp-team.online/v1.0/fz44/notifications/");
            var request = new RestRequest($"{tenderId}", Method.Get);
            var response = client.Execute(request);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content.ToString());
            regNumCollection = doc.GetElementsByTagName("regNum");

            foreach (XmlNode regNum in regNumCollection)
            {
                if (!TagInfo.Contains(regNum.InnerText))
                {
                    TagInfo.Add(regNum.InnerText);
                }
            }

            return TagInfo;
    }

}

