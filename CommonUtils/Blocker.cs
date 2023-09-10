using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFormsApp1.CommonUtils;

public class Blocker
{
    private static Panel blockPanel = new Panel();
    public static void createBlocker(Form form)
    {
        form.Controls.Add(blockPanel);
        blockPanel.BringToFront();
        blockPanel.BackColor = SystemColors.Menu;
        int windowHeight = form.Height;
        blockPanel.Width = 757;
        if (windowHeight <= 610)
        {
            blockPanel.Height = windowHeight - 80;
        }
        else
        {
            blockPanel.Height = windowHeight - 315;
        }

        blockPanel.Controls.Add(waiterLabelCreater());
    }

    public static void deleteBlocker(Form form)
    {
        form.Controls.Remove(blockPanel);
        form.Controls.Remove(waiterLabelCreater());
    }

    private static Label waiterLabelCreater()
    {
        var waiterText = new Label
        {
            Text = "Пожалуйста, подождите, операция выполняется!",
            Font = new Font("Arial", 20, FontStyle.Bold),
            AutoSize = true
        };
        waiterText.Location = new Point(waiterText.Width / 2, blockPanel.Height / 2);
        
        return waiterText;
    }
}