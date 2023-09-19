using System.Runtime.InteropServices;
using System.Windows.Forms;
using static WinFormsApp1.DerjavaTools;

namespace WinFormsApp1.CommonUtils;

public class Blocker
{
    public static Panel blockPanel = new Panel();
    public static void createBlocker(Form form)
    {
        form.Controls.Add(blockPanel);
        blockPanel.BringToFront();
        blockPanel.BackColor = SystemColors.Menu;
        int windowHeight = form.Height;
        int pbHeight = Main_ProgressBar.Location.Y;
        blockPanel.Width = 776;
        if (windowHeight <= 610)
        {
            blockPanel.Height = windowHeight - 80;
        }
        else
        {
            blockPanel.Height = windowHeight - (windowHeight - pbHeight - 20);
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



    public static void needDataCheck(Form form)
    {
        form.Controls.Add(blockPanel);
        blockPanel.BringToFront();
        blockPanel.BackColor = SystemColors.Menu;
        blockPanel.Width = form.Width;
        blockPanel.Height = form.Height;
    }


    public static void deleteDataCHecker(Form form)
    {
        form.Controls.Remove(blockPanel);
        form.Controls.Remove(RootKeyLabelCreater());
        form.Controls.Remove(CSPLabelCreater());
        form.Controls.Remove(CSPpluginLabelCreater());

    }

    public static Label RootKeyLabelCreater()
    {
        var waiterText = new Label
        {
            Text = "Внимание! Корнейвой сертификат не найден!",
            Font = new Font("Arial", 20, FontStyle.Bold),
            AutoSize = true
        };
        waiterText.Location = new Point(70, 240);

        return waiterText;
    }

    public static Label CSPLabelCreater()
    {
        var waiterText = new Label
        {
            Text = "Внимание! CSP Crypto Pro не найден!",
            Font = new Font("Arial", 20, FontStyle.Bold),
            AutoSize = true
        };
        waiterText.Location = new Point(70, 290);

        return waiterText;
    }

    public static Label CSPpluginLabelCreater()
    {
        var waiterText = new Label
        {
            Text = "Внимание! CSP Plugin Browser не найден!",
            Font = new Font("Arial", 20, FontStyle.Bold),
            AutoSize = true
        };
        waiterText.Location = new Point(70,340);

        return waiterText;
    }
}