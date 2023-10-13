namespace WinFormsApp1.CommonUtils;

public class DataCopyUtil
{
    protected static ToolTip copyToolTip = new ToolTip();
    public static void getInputData(TextBox input)
    {
        if (!string.IsNullOrWhiteSpace(input.Text) || input.Text != "")
        {
            Clipboard.SetText(input.Text);
            copyToolTip.Show("Значение скопировано в буфер обмена", input, 1000);
        }
    }
}