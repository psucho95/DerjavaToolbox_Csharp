using WinFormsApp1.CommonUtils;
using WinFormsApp1.KeyGen.API_logic;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;
using WinFormsApp1.KeyGen.Program_logic.POM;
using WinFormsApp1.KeyGen.Program_logic.Utils;

namespace WinFormsApp1
{

    public partial class DerjavaTools : Form
    {
        private string[] subjectInfo = new string[2];
        public static DataGridView SNILS_Table = null;
        public static ProgressBar Main_ProgressBar = null;
        public static MaskedTextBox Main_INN_input = null;
        public static Panel Main_BlockerPanel = null;
        public static Label Main_BlockerLabel = null;
        public static Button Main_getINNdata_btn, Main_downloadEGR_btn, Main_registerINN_btn = null;
        public static CheckBox Main_httpFix_chb, Main_showBrowser_chb = null;
        public static Panel Main_InputsPannel = null;
        protected ClientObj client;

        public DerjavaTools()
        {
            InitializeComponent();
            SNILS_Table = SNILS_DataGridView;
            Main_ProgressBar = formProgressBar;
            Main_INN_input = INN_input;
            Main_BlockerPanel = BlockerPanel;
            Main_BlockerLabel = BlockerLabel;
            Main_getINNdata_btn = getINNdata_btn;
            Main_downloadEGR_btn = downloadEGR_btn;
            Main_registerINN_btn = registerINN_btn;
            Main_httpFix_chb = httpFix_chb;
            Main_showBrowser_chb = showBrowser_chb;
            Main_InputsPannel = InputsPannel;
            SNILS_generator.checkSNILSwarehouse();
        }
        private void downloadEGR_btn_Click(object sender, EventArgs e)
        {

            FilesCreator.saveSysIdAsync(INN_input.Text);
            switch (INN_UL_input.Text.Length)
            {
                case <= 0: MessageBoxCreator.craeteMessageBox("Выписка по инн " + INN_IP_Input.Text + " была сохранена в папке SystemIdInfos", "Сохранение выписки", MessageBoxIcon.Information); break;
                case 10: MessageBoxCreator.craeteMessageBox("Выписка по инн " + INN_UL_input.Text + " была сохранена в папке SystemIdInfos", "Сохранение выписки", MessageBoxIcon.Information); break;
            }

        }
        private void INN_input_TextChanged(object sender, EventArgs e)
        {
            switch (INN_input.Text.Length)
            {
                case 10:
                    INN_input.ResetForeColor();
                    getINNdata_btn.Enabled = true;
                    break;
                case 12:
                    INN_input.ResetForeColor();
                    getINNdata_btn.Enabled = true;
                    break;
                default:
                    INN_input.ForeColor = Color.Firebrick;
                    getINNdata_btn.Enabled = false;
                    break;
            }
        }
        private void INN_input_Click(object sender, EventArgs e)
        {
            switch (INN_input.Text.Length)
            {
                case 0:
                    INN_input.SelectionStart = 0;
                    break;
                case > 0:
                    INN_input.SelectionStart = INN_input.Text.Length;
                    break;
            }
        }
        private async void getINNdata_btn_ClickAsync(object? sender, EventArgs e)
        {
            try
            {
                client = new ClientObj(INN_input.Text);
                await client.setClientInfo(getINNdata_btn);

                switch (INN_input.Text.Length)
                {
                    case 10:
                        UL_rb.Enabled = true;
                        MassPropertyChanger.setDefaultData(InputsPannel);
                        UL_rb.Select();
                        IP_rb.Enabled = false;
                        FL_rb.Enabled = false;

                        CommonName_input.Text = client.CommonName;
                        Surname_input.Text = client.Surname;
                        NameLastName_input.Text = client.NameLastName;
                        FullAdress_input.Text = client.FullAdress;
                        City_input.Text = client.City;
                        Region_input.Text = client.Region;
                        OrgName_input.Text = client.OrgName;
                        Subdivision_input.Text = "Онлайн";
                        JobTitle_input.Text = client.JobTitle;
                        OGRN_input.Text = client.OGRN;
                        INN_IP_Input.Text = client.INN_IP;
                        INN_UL_input.Text = client.INN_UL;
                        SNILS_input.Text = client.SNILS;
                        MassPropertyChanger.setCustomDisable(InputsPannel);
                        break;
                    case 12:
                        UL_rb.Enabled = false;
                        IP_rb.Enabled = true;
                        FL_rb.Enabled = true;

                        MassPropertyChanger.setDefaultData(InputsPannel);
                        FL_rb.Select();
                        switch (subjectInfo[0])
                        {
                            case "FL":
                                CommonName_input.Text = subjectInfo[1] + " " + client.Surname + " " + client.NameLastName;
                                Surname_input.Text = client.Surname;
                                NameLastName_input.Text = client.NameLastName;
                                JobTitle_input.Text = "Физическое лицо";
                                INN_IP_Input.Text = client.INN_IP;
                                SNILS_input.Text = client.SNILS;
                                MassPropertyChanger.setCustomDisable(InputsPannel);
                                break;
                            case "IP":
                                CommonName_input.Text = subjectInfo[1] + " " + client.Surname + " " + client.NameLastName;
                                Surname_input.Text = client.Surname;
                                NameLastName_input.Text = client.NameLastName;
                                JobTitle_input.Text = "Индивидуальный предприниматель";
                                INN_IP_Input.Text = client.INN_IP;
                                OGRN_input.Text = client.OGRN;
                                SNILS_input.Text = client.SNILS;
                                MassPropertyChanger.setCustomDisable(InputsPannel);
                                break;
                        }
                        break;
                }
                downloadEGR_btn.Enabled = true;
                registerINN_btn.Enabled = true;
                showBrowser_chb.Enabled = true;
                httpFix_chb.Enabled = true;
            }
            catch (Exception exception)
            {
                downloadEGR_btn.Enabled = false;
                registerINN_btn.Enabled = false;
                showBrowser_chb.Enabled = false;
                httpFix_chb.Enabled = false;
                FilesCreator.Log_creator(exception);
                MessageBoxCreator.craeteMessageBox("Данные по введённому ИНН отсутствуют!", "Ошибка получения данных", MessageBoxIcon.Error);
            }
        }
        private void Subject_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SubjectSetter.getSubjectState(subjectControl, ref subjectInfo);
            if (FL_rb.Checked)
            {
                CommonName_input.Text = subjectInfo[1] + " " + client.Surname + " " + client.NameLastName;
                OGRNIP_input.Enabled = false;
                OGRNIP_input.Text = "";
                OGRNIP_input.PlaceholderText = "Поле не используется в текущем контексте";
                JobTitle_input.Text = "Физическое лицо";
            }
            else if (IP_rb.Checked)
            {
                CommonName_input.Text = subjectInfo[1] + " " + client.Surname + " " + client.NameLastName;
                OGRNIP_input.Enabled = true;
                OGRNIP_input.Text = client.OGRNIP;
                JobTitle_input.Text = "Индивидуальный предприниматель";
            }

        }

        private void createHistory_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Height != 610)
            {
                SNILS_DataGridView.Enabled = false;
                SNILS_DataGridView.Visible = false;
                Size = new Size(652, 610);

            }
            else
            {
                SNILS_DataGridView.Enabled = true;
                SNILS_DataGridView.Visible = true;
                Size = new Size(652, 850);

            }
        }

        private void registerINN_btn_Click(object sender, EventArgs e)
        {
            BlockerPanel.Enabled = true;
            BlockerLabel.Enabled = true;
            BlockerPanel.Visible = true;
            BlockerLabel.Visible = true;
            Task.Run(() => {
                KeyCreationTask keyCreation = new KeyCreationTask(client, subjectInfo);
                keyCreation.runKeyTask();
            });
        }
        private void httpFix_chb_CheckedChanged(object sender, EventArgs e)
        {
            BasePage.setHTTP_protocol(httpFix_chb.Checked);
        }

        private void showBrowser_chb_CheckedChanged(object sender, EventArgs e)
        {
            BasePage.setSetHeadless(!showBrowser_chb.Checked);
        }
    }
}