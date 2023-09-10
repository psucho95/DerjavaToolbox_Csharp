using RestSharp;
using System.Windows.Forms;
using WinFormsApp1.CommonUtils;
using WinFormsApp1.KeyGen.API_logic;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;
using WinFormsApp1.KeyGen.Program_logic.POM;
using WinFormsApp1.KeyGen.Program_logic.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProgressBar = System.Windows.Forms.ProgressBar;
using ToolTip = System.Windows.Forms.ToolTip;

namespace WinFormsApp1
{

    public partial class DerjavaTools : Form
    {
        private string[] subjectInfo = new string[2];
        protected ClientObj client;
        public static ProgressBar Main_ProgressBar;
        private bool isCompleteData;

        public DerjavaTools()
        {
            InitializeComponent();
            Main_ProgressBar = formProgressBar;
            formProgressBar.BackColor = Color.DarkTurquoise;
            updateTable(SNILS_generator.checkSNILSwarehouse());
        }
        private void downloadEGR_btn_Click(object sender, EventArgs e)
        {

            FilesCreator.saveSysIdAsync(INN_input.Text);
            switch (INN_UL_input.Text.Length)
            {
                case 12: MessageBoxCreator.craeteMessageBox("Выписка по инн " + INN_IP_Input.Text + " была сохранена в папке SystemIdInfos", "Сохранение выписки", MessageBoxIcon.Information); break;
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
                Size = new Size(776, 610);

            }
            else
            {
                SNILS_DataGridView.Enabled = true;
                SNILS_DataGridView.Visible = true;
                Size = new Size(776, 850);

            }
        }
        private async void registerINN_btn_Click(object sender, EventArgs e)
        {
            Blocker.createBlocker(this);
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                Blocker.createBlocker(this);


                KeyCreationTask keyCreation = new KeyCreationTask(client, subjectInfo);
                await Task.Run(() => keyCreation.runKeyTask(cts.Token), cts.Token); // передача CancellationToken
                if (keyCreation.isCompleteWork())
                {
                    SNILS_generator.saveUsedSnils(client);
                    updateTable(SNILS_generator.checkSNILSwarehouse());
                }

                Blocker.deleteBlocker(this);
                showBrowser_chb.Enabled = false;
                registerINN_btn.Enabled = false;
                downloadEGR_btn.Enabled = false;
                INN_input.Clear();

                MassPropertyChanger.setDefaultData(InputsPannel);
                MassPropertyChanger.disableAllSubjectControl(subjectControl);
                formProgressBar.BackColor = Color.Green;
                Thread.Sleep(1000);
                formProgressBar.Value = 0;
                MessageBoxCreator.craeteMessageBox("Ключ с ИНН " + client.SubjectINN + " был успешно создан в системе", "Ключ был успешно создан", MessageBoxIcon.Information);
                client = null;
            }
            catch (Exception exception)
            {
                FilesCreator.Log_creator(exception);
                Blocker.deleteBlocker(this);
                showBrowser_chb.Enabled = false;
                registerINN_btn.Enabled = false;
                downloadEGR_btn.Enabled = false;
                INN_input.Clear();
                formProgressBar.Value = 0;
                MassPropertyChanger.setDefaultData(InputsPannel);
                MassPropertyChanger.disableAllSubjectControl(subjectControl);
                formProgressBar.BackColor = Color.DarkRed;
                Thread.Sleep(1000);
                MessageBoxCreator.craeteMessageBox("Не удалось создать ключ по заданным параметрам!", "Ошибка создания ключа", MessageBoxIcon.Error);
                client = null;
            }
        }
        private void httpFix_chb_CheckedChanged(object sender, EventArgs e)
        {
            BasePage.setHTTP_protocol(httpFix_chb.Checked);
        }
        private void showBrowser_chb_CheckedChanged(object sender, EventArgs e)
        {
            BasePage.setSetHeadless(!showBrowser_chb.Checked);
        }
        void updateTable(List<string> TableData)
        {
            SNILS_DataGridView.Rows.Clear();
            foreach (var line in TableData)
            {
                string[] rowData = line.Split("~");
                SNILS_DataGridView.Rows.Add(rowData);
            }

        }

        private void SNILS_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowNumber = e.RowIndex;
                string value = SNILS_DataGridView.Rows[rowNumber].Cells[4].Value.ToString();

                Clipboard.SetText(value);
                MessageBoxCreator.craeteMessageBox("ИНН " + value + " был скопирован в буфер обмена", "ИНН ФЛ/ИП", MessageBoxIcon.Information);
            }
        }

        private void isManual_Click(object sender, EventArgs e)
        {
            if (isManual.Checked)
            {
                INN_input.Enabled = false;
                getINNdata_btn.Enabled = false;
                client = null;
                MassPropertyChanger.setDefaultData(InputsPannel);
                MassPropertyChanger.setEnableAll(InputsPannel);
            }
            else
            {
                INN_input.Enabled = true;
                getINNdata_btn.Enabled = true;
                client = null;
                MassPropertyChanger.setDefaultData(InputsPannel);
                MassPropertyChanger.disableAllSubjectControl(InputsPannel);
            }
        }
    }
}