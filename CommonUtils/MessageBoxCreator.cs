namespace WinFormsApp1.CommonUtils;
using System.Windows.Forms;

public class MessageBoxCreator
{
    public static void craeteMessageBox(string Message, string Header, MessageBoxIcon ico)
    {

        MessageBox.Show(
            Message,
            Header,
            MessageBoxButtons.OK,
            ico,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
    }
}