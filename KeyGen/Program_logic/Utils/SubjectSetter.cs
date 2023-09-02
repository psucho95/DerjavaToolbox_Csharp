namespace WinFormsApp1.KeyGen.Program_logic.Utils;

public class SubjectSetter
{
    string subjectState;
    public string SubjectState
    {
        get => subjectState;
        set => subjectState = value;
    }

    string subjectStateLocale;
    public string SubjectStateLocale
    {
        get => SubjectStateLocale;
        set => SubjectStateLocale = value;
    }

    //static string[] subjectInfo = new string[2];

    public static void getSubjectState(Panel radioButtonsControl, ref string[] subjectInfo)
    {
        foreach (RadioButton item in radioButtonsControl.Controls)
        {
            if (item.Checked)
            {
                switch (item.Name)
                {
                    case "UL_rb":
                        subjectInfo[0] = "UL";
                        subjectInfo[1] = "ЮЛ";
                        break;
                    case "IP_rb":
                        subjectInfo[0] = "IP";
                        subjectInfo[1] = "ИП";
                        break;
                    case "FL_rb":
                        subjectInfo[0] = "FL";
                        subjectInfo[1] = "ФЛ";
                        break;
                }
            }
        }
    }
}