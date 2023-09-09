namespace WinFormsApp1.KeyGen.Program_logic.Utils;

public class MassPropertyChanger
{

    public static void setCustomDisable(Control anchorPane)
    {
        foreach (Control node in anchorPane.Controls)
        {
            if (node is TextBox)
            {
                TextBox textField = (TextBox)node;
                if (textField.Text.Equals(""))
                {
                    textField.PlaceholderText = "Поле не используется в текущем контексте";
                    textField.Enabled = false;
                }
                else
                    textField.Enabled = true;

                textField.ReadOnly = true;
            }
        }
    }

    public static void setDefaultData(Control control)
    {
        foreach (Control node in control.Controls)
        {
            if (node is TextBox)
            {
                ((TextBox)node).Text = "";
                ((TextBox)node).Enabled = false;
                switch (node.Name)
                {
                    case "commonName_Input":
                        ((TextBox)node).PlaceholderText = "Сокращенное наименование предприятия, ИП или ФЛ";
                        break;
                    case "surname_Input":
                        ((TextBox)node).PlaceholderText = "Фамилия ИП, ФЛ или ЕИО предприятия";
                        break;
                    case "nameAndLastName_Input":
                        ((TextBox)node).PlaceholderText = "Имя и Отчество ИП, ФЛ или ЕИО предприятия";
                        break;
                    case "adressFull_Input":
                        ((TextBox)node).PlaceholderText = "Полный адрес регистрации предприятия, ИП или ФЛ";
                        break;
                    case "adressCity_Input":
                        ((TextBox)node).PlaceholderText = "Город регистрации предприятия, ИП или ФЛ";
                        break;
                    case "adressDistrict_Input":
                        ((TextBox)node).PlaceholderText = "Область регистрации предприятия, ИП или ФЛ";
                        break;
                    case "orgName_Input":
                        ((TextBox)node).PlaceholderText = "Полное наименование предприятия, ИП или ФЛ";
                        break;
                    case "subdivision_Input":
                        ((TextBox)node).PlaceholderText = "Статический параметр. Принимает значение \"Онлайн\"";
                        break;
                    case "jobTitle_Input":
                        ((TextBox)node).PlaceholderText = "Должность ИП, ФЛ или владельца ключа в предприятии";
                        break;
                    case "OGRN_Input":
                        ((TextBox)node).PlaceholderText = "Номер ОГРН предприятия";
                        break;
                    case "INN_IP_Input":
                        ((TextBox)node).PlaceholderText = "ИНН ИП, ФЛ или ЕИО предприятия";
                        break;
                    case "INN_UL_Input":
                        ((TextBox)node).PlaceholderText = "ИНН предприятия";
                        break;
                    case "OGRNIP_Input":
                        ((TextBox)node).PlaceholderText = "ОГРНИП ФЛ";
                        break;
                    case "snils_Input":
                        ((TextBox)node).PlaceholderText = "Номер СНИЛС. Генерируется автоматически";
                        break;
                }
            }
            else if (node is Panel)
            {
                setDefaultData(node);
            }
        }
    }

    public static void disableAllSubjectControl(Control control)
    {
        foreach (Control elem in control.Controls)
        {
            if (elem is RadioButton)
            {
                elem.Enabled = false;
            }
        }
    }
}