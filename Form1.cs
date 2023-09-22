using DerjavaToolbox.KeyGen.Program_logic.Utils;
using WinFormsApp1.CommonUtils;
using WinFormsApp1.KeyGen.API_logic;
using WinFormsApp1.KeyGen.Program_logic.FileGenerator;
using WinFormsApp1.KeyGen.Program_logic.POM;
using WinFormsApp1.KeyGen.Program_logic.Utils;
using ProgressBar = System.Windows.Forms.ProgressBar;
using ToolTip = System.Windows.Forms.ToolTip;
using System.Text.RegularExpressions;
using static WinFormsApp1.KeyGen.StaticData.StaticData;
using System.Diagnostics;
using DerjavaToolbox;


namespace WinFormsApp1
{

    public partial class DerjavaTools : Form
    {
        private string[] subjectInfo = new string[2];
        protected ClientObj client;
        public static ProgressBar Main_ProgressBar;
        private bool isCompleteData;
        protected string innFlInfosMessage = "Нет данных";
        protected ToolTip tt = new ToolTip();
        protected ToolTip warninToolTip = new ToolTip();

        public DerjavaTools()
        {
            InitializeComponent();
            Main_ProgressBar = formProgressBar;
            formProgressBar.BackColor = Color.DarkTurquoise;
            updateTable(SNILS_generator.checkSNILSwarehouse());
            Dictionary<string, bool> finalData = NeededDataChecker.neededDataChecker();
            if (finalData.Values.Contains(false))
            {
                Blocker.needDataCheck(this);
                foreach (var param in finalData)
                {


                    if (param.Value == false && param.Key == "ROOTcerExist")
                    {
                        Blocker.blockPanel.Controls.Add(Blocker.RootKeyLabelCreater());
                    }

                    if (param.Value == false && param.Key == "isCSPinstalled")
                    {
                        Blocker.blockPanel.Controls.Add(Blocker.CSPLabelCreater());
                    }

                    if (param.Value == false && param.Key == "isCSPpluginInstalled")
                    {
                        Blocker.blockPanel.Controls.Add(Blocker.CSPpluginLabelCreater());
                    }
                }

                Blocker.blockPanel.Controls.Add(Blocker.openNeedeDataFolder());
            }

            if (NeededDataChecker.getCSPversion() < Version.Parse("5.0.0.0"))
            {
                infoWarnin.Visible = true;
            }
            else
            {
                infoWarnin.Visible = false;
            }

        }
        private void downloadEGR_btn_Click(object sender, EventArgs e)
        {
            FilesCreator.saveSysIdAsync(INN_input.Text);
            switch (INN_input.Text.Length)
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

                        if (SNILS_generator.getSameSNILS().Count > 1)
                        {
                            ExistingSNILSselector();
                        }
                        else
                        {
                            SNILS_input.Text = client.SNILS;
                        }

                        MassPropertyChanger.setCustomDisable(InputsPannel);
                        isINN_Fl_Exist.Visible = true;
                        if (await ResponseObj.checkIfExist(client.INN_IP))
                        {
                            isINN_Fl_Exist.Visible = true;
                            innFlInfosMessage = null;
                            isINN_Fl_Exist.Text = "✔";
                            isINN_Fl_Exist.ForeColor = Color.Green;
                            innFlInfosMessage = "Данные по ИНН " + client.INN_IP + " присутствуют в ЕГРИП";
                        }
                        else
                        {
                            isINN_Fl_Exist.Visible = true;
                            innFlInfosMessage = null;
                            isINN_Fl_Exist.Text = "✖";
                            isINN_Fl_Exist.ForeColor = Color.DarkRed;
                            innFlInfosMessage = "Данные по ИНН " + client.INN_IP + " отсутствуют в ЕГРИП";
                        }

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
                                break;
                            case "IP":
                                CommonName_input.Text = subjectInfo[1] + " " + client.Surname + " " + client.NameLastName;
                                Surname_input.Text = client.Surname;
                                NameLastName_input.Text = client.NameLastName;
                                JobTitle_input.Text = "Индивидуальный предприниматель";
                                INN_IP_Input.Text = client.INN_IP;
                                OGRN_input.Text = client.OGRN;
                                break;
                        }
                        if (SNILS_generator.getSameSNILS().Count > 1)
                        {
                            ExistingSNILSselector();
                        }
                        else
                        {
                            SNILS_input.Text = client.SNILS;
                        }
                        MassPropertyChanger.setCustomDisable(InputsPannel);
                        break;
                }
                downloadEGR_btn.Enabled = true;
                registerINN_btn.Enabled = true;
                showBrowser_chb.Enabled = true;
                httpFix_chb.Enabled = true;
                MassPropertyChanger.unbockManual(ManualEditing_panel, true);
                updateSNILS_btn.Enabled = true;
            }
            catch (Exception exception)
            {
                downloadEGR_btn.Enabled = false;
                registerINN_btn.Enabled = false;
                showBrowser_chb.Enabled = false;
                httpFix_chb.Enabled = false;
                FilesCreator.Log_creator(exception);
                MessageBoxCreator.craeteMessageBox("Данные по введённому ИНН отсутствуют!", "Ошибка получения данных", MessageBoxIcon.Error);
                isINN_Fl_Exist.Visible = false;
                updateSNILS_btn.Enabled = false;
            }
        }
        private void Subject_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SubjectSetter.getSubjectState(subjectControl, ref subjectInfo);
            if (UL_rb.Checked)
            {
                isINN_Fl_Exist.Visible = true;
            }

            if (FL_rb.Checked)
            {
                CommonName_input.Text = subjectInfo[1] + " " + client.Surname + " " + client.NameLastName;
                OGRNIP_input.Enabled = false;
                OGRNIP_input.Text = "";
                OGRNIP_input.PlaceholderText = "Поле не используется в текущем контексте";
                JobTitle_input.Text = "Физическое лицо";
                isINN_Fl_Exist.Visible = false;
            }
            else if (IP_rb.Checked)
            {

                CommonName_input.Text = subjectInfo[1] + " " + client.Surname + " " + client.NameLastName;
                OGRNIP_input.Enabled = true;
                OGRNIP_input.Text = client.OGRNIP;
                JobTitle_input.Text = "Индивидуальный предприниматель";
                isINN_Fl_Exist.Visible = false;
            }

        }
        private void createHistory_chb_CheckedChanged(object sender, EventArgs e)
        {
            int allRowsHeight = 0;
            switch (SNILS_DataGridView.Rows.Count)
            {
                case <= 10: allRowsHeight = (SNILS_DataGridView.Rows.Count * 25) + 50; break;
                case > 10: allRowsHeight = 250; break;
            }
            if (this.Height != 610)
            {
                SNILS_DataGridView.Enabled = false;
                SNILS_DataGridView.Visible = false;
                Size = new Size(795, 610);

            }
            else
            {
                SNILS_DataGridView.Enabled = true;
                SNILS_DataGridView.Visible = true;
                Size = new Size(795, 610 + allRowsHeight);

            }
        }
        private async void registerINN_btn_Click(object sender, EventArgs e)
        {
            Blocker.createBlocker(this);
            try
            {
                foreach (Control node in ManualEditing_panel.Controls)
                {
                    if (node is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)node;
                        if (checkBox.Checked)
                        {
                            switch (checkBox.Name)
                            {
                                case "Manual_Surname_chb": client.Surname = Surname_input.Text; break;
                                case "Manual_NameLastName_chb": client.NameLastName = NameLastName_input.Text; break;
                                case "Manual_JobTitle_chb": client.JobTitle = JobTitle_input.Text; break;
                                case "Manual_INN_FL_chb": client.INN_IP = INN_IP_Input.Text; break;
                            }
                        }
                    }
                }

                KeyCreationTask keyCreation = new KeyCreationTask(client, subjectInfo);
                await Task.Run(() => keyCreation.runKeyTask());

                if (keyCreation.isCompleteWork())
                {
                    SNILS_generator.saveUsedSnils(client, subjectInfo);
                    updateTable(SNILS_generator.checkSNILSwarehouse());
                }

                INN_input.Clear();
                MassPropertyChanger.setDefaultData(InputsPannel);
                MassPropertyChanger.disableAllSubjectControl(subjectControl);
                MassPropertyChanger.unbockManual(ManualEditing_panel, false);
                MassPropertyChanger.uncheckManual(Manual_INN_FL_chb);
                Blocker.deleteBlocker(this);
                showBrowser_chb.Enabled = false;
                registerINN_btn.Enabled = false;
                downloadEGR_btn.Enabled = false;
                updateSNILS_btn.Enabled = false;

                await MessageBoxCreator.craeteMessageBox("Ключ с ИНН " + client.SubjectINN + " был успешно создан в системе", "Ключ был успешно создан", MessageBoxIcon.Information);
                formProgressBar.Value = 0;

                client = null;

            }
            catch (Exception exception)
            {
                FilesCreator.Log_creator(exception);
                Blocker.deleteBlocker(this);
                showBrowser_chb.Enabled = false;
                registerINN_btn.Enabled = false;
                downloadEGR_btn.Enabled = false;
                updateSNILS_btn.Enabled = false;

                INN_input.Clear();

                if (Regex.IsMatch(exception.Message, "^[А-Яа-я]+$"))
                {
                    MessageBoxCreator.craeteMessageBox(exception.Message, "Ошибка создания ключа", MessageBoxIcon.Error);
                }
                else
                {
                    MessageBoxCreator.craeteMessageBox("Создание ключа не было завершено. Пожалуйста, обратитесь к логам программы", "Ошибка создания ключа", MessageBoxIcon.Error);
                }


                formProgressBar.Value = 0;
                MassPropertyChanger.setDefaultData(InputsPannel);
                MassPropertyChanger.disableAllSubjectControl(subjectControl);
                client = null;
                MassPropertyChanger.unbockManual(ManualEditing_panel, false);
                MassPropertyChanger.uncheckManual(ManualEditing_panel);
                isINN_Fl_Exist.Visible = false;
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
                switch (e.ColumnIndex)
                {
                    case 2:
                        string INN_ULvalue = SNILS_DataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        if (Regex.IsMatch(INN_ULvalue, @"^\d+$"))
                        {
                            Clipboard.SetText(INN_ULvalue);
                            MessageBoxCreator.craeteMessageBox("ИНН ЮЛ " + INN_ULvalue + " был скопирован в буфер обмена", "ИНН ФЛ/ИП", MessageBoxIcon.Information);
                        }
                        break;

                    case 4:
                        string INN_IPvalue = SNILS_DataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                        Clipboard.SetText(INN_IPvalue);
                        MessageBoxCreator.craeteMessageBox("ИНН ФЛ/ИП " + INN_IPvalue + " был скопирован в буфер обмена", "ИНН ФЛ/ИП", MessageBoxIcon.Information);
                        break;
                }
            }
        }
        private void isINN_Fl_Exist_MouseEnter(object sender, EventArgs e)
        {
            if (isINN_Fl_Exist.Visible)
            {
                tt.Show(innFlInfosMessage, isINN_Fl_Exist);
            }
        }
        private void isINN_Fl_Exist_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(isINN_Fl_Exist);
        }
        private void Manual_Surname_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (Manual_Surname_chb.Checked)
            {
                Surname_input.ReadOnly = false;
            }

            else
            {
                Surname_input.ReadOnly = true;
            }
        }
        private void Manual_NameLastName_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (Manual_NameLastName_chb.Checked)
            {
                NameLastName_input.ReadOnly = false;
            }

            else
            {
                NameLastName_input.ReadOnly = true;
            }
        }
        private void Manual_JobTitle_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (Manual_JobTitle_chb.Checked)
            {
                JobTitle_input.ReadOnly = false;
            }

            else
            {
                JobTitle_input.ReadOnly = true;
            }
        }
        private void Manual_INN_FL_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (Manual_INN_FL_chb.Checked)
            {
                INN_IP_Input.ReadOnly = false;
                isINN_Fl_Exist.Visible = false;
            }

            else
            {
                INN_IP_Input.ReadOnly = true;
                isINN_Fl_Exist.Visible = true;
            }
        }
        private void INN_IP_Input_TextChanged(object sender, EventArgs e)
        {
            if (INN_IP_Input.Text.Length < 12)
            {
                INN_IP_Input.ForeColor = Color.Red;
                registerINN_btn.Enabled = false;
            }
            else
            {
                INN_IP_Input.ForeColor = Color.Black;
                if (INN_IP_Input.Text.Length == 12 && Surname_input.Text.Length > 1 && NameLastName_input.Text.Length > 1 && JobTitle_input.Text.Length > 1) registerINN_btn.Enabled = true;
            }
        }
        private void Surname_input_TextChanged(object sender, EventArgs e)
        {
            if (Surname_input.Text.Length <= 0)
            {
                registerINN_btn.Enabled = false;
            }
            else
            {
                if (INN_IP_Input.Text.Length == 12 && Surname_input.Text.Length > 1 && NameLastName_input.Text.Length > 1 && JobTitle_input.Text.Length > 1) registerINN_btn.Enabled = true;
            }
        }
        private void NameLastName_input_TextChanged(object sender, EventArgs e)
        {
            if (NameLastName_input.Text.Length <= 0)
            {
                registerINN_btn.Enabled = false;
            }
            else
            {
                if (INN_IP_Input.Text.Length == 12 && Surname_input.Text.Length > 1 && NameLastName_input.Text.Length > 1 && JobTitle_input.Text.Length > 1) registerINN_btn.Enabled = true;
            }
        }
        private void JobTitle_input_TextChanged(object sender, EventArgs e)
        {
            if (JobTitle_input.Text.Length <= 0)
            {
                registerINN_btn.Enabled = false;
            }
            else
            {
                if (INN_IP_Input.Text.Length == 12 && Surname_input.Text.Length > 1 && NameLastName_input.Text.Length > 1 && JobTitle_input.Text.Length > 1) registerINN_btn.Enabled = true;
            }
        }
        private void Logs_btn_Click(object sender, EventArgs e)
        {
            string dir = rootDirectory + logFolderPath;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            Process.Start("explorer.exe", dir);

        }
        private void SysIdInfo_btn_Click(object sender, EventArgs e)
        {
            string dir = rootDirectory + sysIdInfosFolderPath;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            Process.Start("explorer.exe", dir);
        }
        private void updateSNILS_btn_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("При повторной генерации СНИЛС он будет привязан к новому ключу без возможности изменения?", "Внимание!", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                client.SNILS = SNILS_generator.GenerateSnils();
                SNILS_input.Text = client.SNILS;
            }
        }
        private void ExistingSNILSselector()
        {
            string[] SNILSarr = SNILS_generator.getSameSNILS().ToArray();
            if (SNILSarr.Length > 1)
            {
                Form2 form2 = new Form2();

                string inn = INN_IP_Input.Text;
                form2.richTextBox1.Text = String.Format("ИНН ФЛ/ИП {0} связан со следующими СНИЛС", inn);
                form2.richTextBox1.Select(10, 12); // выделяем текст
                form2.richTextBox1.SelectionFont = new Font(form2.richTextBox1.Font, FontStyle.Bold); // устанавливаем жирный шрифт
                foreach (var line in SNILSarr)
                {
                    form2.Selector_DataGridView.Rows.Add(line);
                }
                form2.ShowDialog();
                client.SNILS = form2.returnSelectedSNILS();
                SNILS_input.Text = client.SNILS;
            }
        }
        private void infoWarnin_MouseEnter(object sender, EventArgs e)
        {
            warninToolTip.Show("Ваша текущая версия CryptoPRO CSP устарела. Ваша версия - " + NeededDataChecker.getCSPversion().ToString().Substring(0, 7) + ", актуальная версия 5.0+", infoWarnin);
        }
    }
}