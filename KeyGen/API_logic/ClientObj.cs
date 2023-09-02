using Dadata;
using Dadata.Model;
using System.Xml;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;

namespace WinFormsApp1.KeyGen.API_logic;

public class ClientObj
{
    string commonName;
    public string CommonName
    {
        get => commonName;
        set => commonName = value;
    }

    private string surname;
    public string Surname
    {
        get => surname;
        set => surname = value;
    }
     
    string nameLastName;
    public string NameLastName
    {
        get => nameLastName;
        set => nameLastName = value;
    }
    
    string name;
    public string Name
    {
        get => name;
        set => name = value;
    }
    
    string lastName;
    public string LastName
    {
        get => lastName;
        set => lastName = value;
    }

    string fullAdress;
    public string FullAdress
    {
        get => fullAdress;
        set => fullAdress = value;
    }
    
    string city;
    public string City
    {
        get => city;
        set => city = value;
    }
    
    string region;
    public string Region
    {
        get => region;
        set => region = value;
    }
    
    string orgName;
    public string OrgName
    {
        get => orgName;
        set => orgName = value;
    }
    
    string jobTitle;
    public string JobTitle
    {
        get => jobTitle;
        set => jobTitle = value;
    }
    
    string ogrn;
    public string OGRN
    {
        get => ogrn;
        set => ogrn = value;
    }
    
    string inn_ip;

    public string INN_IP
    {
        get => inn_ip;
        set => inn_ip = value;
    }
    
    string inn_ul;
    public string INN_UL
    {
        get => inn_ul;
        set => inn_ul = value;
    }
    
    string ogrnip;
    public string OGRNIP
    {
        get => ogrnip;
        set => ogrnip = value;
    }
    
    string snils;
    public string SNILS
    {
        get => snils;
        set => snils = value;
    }

    private string subdivision;

    public string Subdivision
    {
        get => subdivision;
        set => subdivision = value;
    }

    
    string subjectINN;
    public string SubjectINN
    {
        get => subjectINN;
    }
    XmlDocument response;
    XmlDocument? clientData;
    Suggestion<Party> daData;
    Dictionary<string, string> clienDictionary = new Dictionary<string, string>();



    public ClientObj(String subjectINN)
    {
        this.subjectINN = subjectINN;
    }

    public async Task setClientInfo(Button button)
    {
        try
        {
            clientData = await ResponseObj.getClientResponseAsync(subjectINN, button);
            daData = await ResponseObj.getDaDataAdressAsyncAsync(subjectINN);

            switch (subjectINN.Length)
            {
                case 10:
                    FullAdress = daData.data.address.unrestricted_value;
                    Region = daData.data.address.data.region_with_type;
                    if (daData.data.address.data.city_with_type == null)
                    {
                        City = daData.data.address.data.area_with_type;
                    }
                    else
                    {
                        City = daData.data.address.data.city_with_type;
                    }

                    if (getNodeValue("EGRUL/СвЮЛ/СвНаимЮЛСокр/@НаимСокр") != "")
                    {
                        CommonName = getNodeValue("EGRUL/СвЮЛ/СвНаимЮЛСокр/@НаимСокр");
                    }
                    else if (getNodeValue("EGRUL/СвЮЛ/СвНаимЮЛ/@НаимЮЛСокр") !="")
                    {
                        CommonName = getNodeValue("EGRUL/СвЮЛ/СвНаимЮЛ/@НаимЮЛСокр");
                    }
                    else if (getNodeValue("EGRUL/СвЮЛ/СвНаимЮЛ/СвНаимЮЛСокр/@НаимСокр") != "")
                    {
                        CommonName = getNodeValue("EGRUL/СвЮЛ/СвНаимЮЛ/СвНаимЮЛСокр/@НаимСокр");
                    }
                    Surname = getNodeValue("EGRUL/СвЮЛ/СведДолжнФЛ/СвФЛ/@Фамилия");
                    name = getNodeValue("EGRUL/СвЮЛ/СведДолжнФЛ/СвФЛ/@Имя");
                    LastName = getNodeValue("EGRUL/СвЮЛ/СведДолжнФЛ/СвФЛ/@Отчество");
                    NameLastName = string.Format("{0} {1}", name, LastName);
                    OrgName = getNodeValue("EGRUL/СвЮЛ/СвНаимЮЛ/@НаимЮЛПолн");
                    JobTitle = getNodeValue("EGRUL/СвЮЛ/СведДолжнФЛ/СвДолжн/@НаимДолжн");
                    OGRN = getNodeValue("EGRUL/СвЮЛ/@ОГРН");
                    INN_IP = getNodeValue("EGRUL/СвЮЛ/СведДолжнФЛ/СвФЛ/@ИННФЛ");
                    INN_UL = getNodeValue("EGRUL/СвЮЛ/@ИНН");
                    Subdivision = "Онлайн";
                    break;

                case 12:
                    INN_IP = getNodeValue("EGRIP/СвИП/@ИННФЛ");
                    Surname = getNodeValue("EGRIP/СвИП/СвФЛ/ФИОРус/@Фамилия");
                    name = getNodeValue("EGRIP/СвИП/СвФЛ/ФИОРус/@Имя");
                    LastName = getNodeValue("EGRIP/СвИП/СвФЛ/ФИОРус/@Отчество");
                    NameLastName = string.Format("{0} {1}", name, LastName);
                    OGRNIP = getNodeValue("EGRIP/СвИП/@ОГРНИП");
                    break;

            }

            if (INN_IP == null || INN_IP.Equals(""))
            {
               Exception noINN_IP_ex = new Exception();
                throw noINN_IP_ex;
            }
            else
            {
                SNILS = SNILS_generator.setSNILS(INN_IP);
            }
            
        }
       
        catch (Exception exception)
        {
            throw;
        }
    }

    public string getNodeValue(string pathToNode)
    {
        try
        {
        XmlNode node = clientData.SelectSingleNode(pathToNode);
        if (node != null) return node.InnerText;
        else return "";
        }
        catch (Exception exception)
        {
            throw;
        }
    }

}