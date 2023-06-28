namespace WinFormsApp1;

public class ToolTipCreator
{
    public static void creteToolTip(IWin32Window elem, int x, int y, int duration, string text)
    {
        ToolTip toolTip = new ToolTip();
        toolTip.Show(text, elem, x, y, duration);
    }
}