using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static WinFormsApp1.DerjavaTools;
using static WinFormsApp1.KeyGen.StaticData.StaticData;

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
        blockPanel.Height = windowHeight - (windowHeight - pbHeight - 10);
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
        waiterText.Location = new Point(109, 240);

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
        waiterText.Location = new Point(109, 290);

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
        waiterText.Location = new Point(109,340);

        return waiterText;
    }
    
    public static Button openNeedeDataFolder()
    {
        var openButton = new Button()
        {
            Text = "Перейти в папку с инструкцией",
            AutoSize = true
        };
        openButton.Location = new Point(330, 390);
        openButton.Click += OpenButton_Click;
        return openButton;
    }
    private static void OpenButton_Click(object sender, EventArgs e)
    {
        string dir = rootDirectory + neededDataFolder;
        Process.Start("explorer.exe", dir);
    }
}