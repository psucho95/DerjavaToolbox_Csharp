namespace WinFormsApp1
{
    partial class DerjavaTools
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabPage OtherTools;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DerjavaTools));
            MainTabControl = new TabControl();
            KeyGenTab = new TabPage();
            panel1 = new Panel();
            SNILS_DataGridView = new DataGridView();
            Date_clmn = new DataGridViewTextBoxColumn();
            CommonName_clmn = new DataGridViewTextBoxColumn();
            INN_UL_clmn = new DataGridViewTextBoxColumn();
            FIO_clmn = new DataGridViewTextBoxColumn();
            INN_IP_clmn = new DataGridViewTextBoxColumn();
            SNILS_clmn = new DataGridViewTextBoxColumn();
            subjectControl = new Panel();
            IP_rb = new RadioButton();
            UL_rb = new RadioButton();
            FL_rb = new RadioButton();
            formProgressBar = new ProgressBar();
            InputsPannel = new Panel();
            CommonName_label = new Label();
            OGRNIP_input = new TextBox();
            OGRN_label = new Label();
            INN_IP_Input = new TextBox();
            JobTitle_label = new Label();
            INN_UL_input = new TextBox();
            SNILS_label = new Label();
            SNILS_input = new TextBox();
            Subdivision_label = new Label();
            OGRN_input = new TextBox();
            INN_UL_label = new Label();
            JobTitle_input = new TextBox();
            OrgName_label = new Label();
            Subdivision_input = new TextBox();
            INN_IP_Label = new Label();
            OrgName_input = new TextBox();
            Region_label = new Label();
            Region_input = new TextBox();
            OGRNIP_label = new Label();
            City_input = new TextBox();
            City_label = new Label();
            CommonName_input = new TextBox();
            FullAdress_input = new TextBox();
            FullAdress_label = new Label();
            Surname_label = new Label();
            Surname_input = new TextBox();
            NameLastName_input = new TextBox();
            NameLastName_label = new Label();
            httpFix_chb = new CheckBox();
            createHistory_chb = new CheckBox();
            downloadEGR_btn = new Button();
            showBrowser_chb = new CheckBox();
            registerINN_btn = new Button();
            getINNdata_btn = new Button();
            INN_input = new MaskedTextBox();
            INN_label = new Label();
            isManual = new CheckBox();
            OtherTools = new TabPage();
            MainTabControl.SuspendLayout();
            KeyGenTab.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SNILS_DataGridView).BeginInit();
            subjectControl.SuspendLayout();
            InputsPannel.SuspendLayout();
            SuspendLayout();
            // 
            // OtherTools
            // 
            OtherTools.Location = new Point(4, 24);
            OtherTools.Name = "OtherTools";
            OtherTools.Size = new Size(752, 543);
            OtherTools.TabIndex = 2;
            OtherTools.Text = "Другие инструменты";
            OtherTools.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            MainTabControl.Controls.Add(KeyGenTab);
            MainTabControl.Controls.Add(OtherTools);
            MainTabControl.Dock = DockStyle.Fill;
            MainTabControl.Location = new Point(0, 0);
            MainTabControl.Name = "MainTabControl";
            MainTabControl.SelectedIndex = 0;
            MainTabControl.Size = new Size(760, 571);
            MainTabControl.TabIndex = 5;
            // 
            // KeyGenTab
            // 
            KeyGenTab.Controls.Add(isManual);
            KeyGenTab.Controls.Add(panel1);
            KeyGenTab.Controls.Add(subjectControl);
            KeyGenTab.Controls.Add(formProgressBar);
            KeyGenTab.Controls.Add(InputsPannel);
            KeyGenTab.Controls.Add(httpFix_chb);
            KeyGenTab.Controls.Add(createHistory_chb);
            KeyGenTab.Controls.Add(downloadEGR_btn);
            KeyGenTab.Controls.Add(showBrowser_chb);
            KeyGenTab.Controls.Add(registerINN_btn);
            KeyGenTab.Controls.Add(getINNdata_btn);
            KeyGenTab.Controls.Add(INN_input);
            KeyGenTab.Controls.Add(INN_label);
            KeyGenTab.Location = new Point(4, 24);
            KeyGenTab.Name = "KeyGenTab";
            KeyGenTab.Padding = new Padding(3);
            KeyGenTab.Size = new Size(752, 543);
            KeyGenTab.TabIndex = 1;
            KeyGenTab.Text = "Создание ключа";
            KeyGenTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(SNILS_DataGridView);
            panel1.Location = new Point(8, 542);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 235);
            panel1.TabIndex = 55;
            // 
            // SNILS_DataGridView
            // 
            SNILS_DataGridView.AllowUserToAddRows = false;
            SNILS_DataGridView.AllowUserToDeleteRows = false;
            SNILS_DataGridView.AllowUserToResizeColumns = false;
            SNILS_DataGridView.AllowUserToResizeRows = false;
            SNILS_DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SNILS_DataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            SNILS_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SNILS_DataGridView.Columns.AddRange(new DataGridViewColumn[] { Date_clmn, CommonName_clmn, INN_UL_clmn, FIO_clmn, INN_IP_clmn, SNILS_clmn });
            SNILS_DataGridView.Enabled = false;
            SNILS_DataGridView.Location = new Point(-1, 0);
            SNILS_DataGridView.MultiSelect = false;
            SNILS_DataGridView.Name = "SNILS_DataGridView";
            SNILS_DataGridView.ReadOnly = true;
            SNILS_DataGridView.RowHeadersVisible = false;
            SNILS_DataGridView.RowTemplate.Height = 25;
            SNILS_DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            SNILS_DataGridView.ShowCellErrors = false;
            SNILS_DataGridView.ShowCellToolTips = false;
            SNILS_DataGridView.ShowEditingIcon = false;
            SNILS_DataGridView.ShowRowErrors = false;
            SNILS_DataGridView.Size = new Size(739, 235);
            SNILS_DataGridView.TabIndex = 0;
            SNILS_DataGridView.Visible = false;
            SNILS_DataGridView.CellClick += SNILS_DataGridView_CellClick;
            // 
            // Date_clmn
            // 
            Date_clmn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Date_clmn.HeaderText = "Дата";
            Date_clmn.MinimumWidth = 107;
            Date_clmn.Name = "Date_clmn";
            Date_clmn.ReadOnly = true;
            Date_clmn.Width = 107;
            // 
            // CommonName_clmn
            // 
            CommonName_clmn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            CommonName_clmn.HeaderText = "Общее имя";
            CommonName_clmn.MinimumWidth = 160;
            CommonName_clmn.Name = "CommonName_clmn";
            CommonName_clmn.ReadOnly = true;
            CommonName_clmn.Width = 160;
            // 
            // INN_UL_clmn
            // 
            INN_UL_clmn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            INN_UL_clmn.HeaderText = "ИНН ЮЛ";
            INN_UL_clmn.MinimumWidth = 82;
            INN_UL_clmn.Name = "INN_UL_clmn";
            INN_UL_clmn.ReadOnly = true;
            INN_UL_clmn.Width = 82;
            // 
            // FIO_clmn
            // 
            FIO_clmn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            FIO_clmn.HeaderText = "ФИО ИП/ФЛ";
            FIO_clmn.MinimumWidth = 160;
            FIO_clmn.Name = "FIO_clmn";
            FIO_clmn.ReadOnly = true;
            FIO_clmn.Width = 160;
            // 
            // INN_IP_clmn
            // 
            INN_IP_clmn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            INN_IP_clmn.HeaderText = "ИНН ИП/ФЛ";
            INN_IP_clmn.MinimumWidth = 102;
            INN_IP_clmn.Name = "INN_IP_clmn";
            INN_IP_clmn.ReadOnly = true;
            INN_IP_clmn.ToolTipText = "Нажмите, чтобы скопировать значение в буфер обмена";
            INN_IP_clmn.Width = 102;
            // 
            // SNILS_clmn
            // 
            SNILS_clmn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SNILS_clmn.HeaderText = "СНИЛС";
            SNILS_clmn.MinimumWidth = 75;
            SNILS_clmn.Name = "SNILS_clmn";
            SNILS_clmn.ReadOnly = true;
            SNILS_clmn.Width = 75;
            // 
            // subjectControl
            // 
            subjectControl.Controls.Add(IP_rb);
            subjectControl.Controls.Add(UL_rb);
            subjectControl.Controls.Add(FL_rb);
            subjectControl.Location = new Point(7, 61);
            subjectControl.Name = "subjectControl";
            subjectControl.Size = new Size(737, 19);
            subjectControl.TabIndex = 54;
            // 
            // IP_rb
            // 
            IP_rb.AutoSize = true;
            IP_rb.Enabled = false;
            IP_rb.Location = new Point(510, 0);
            IP_rb.Name = "IP_rb";
            IP_rb.Size = new Size(224, 19);
            IP_rb.TabIndex = 53;
            IP_rb.Text = "Индивидуальный предприниматель";
            IP_rb.UseVisualStyleBackColor = true;
            IP_rb.CheckedChanged += Subject_RadioButton_CheckedChanged;
            // 
            // UL_rb
            // 
            UL_rb.AutoSize = true;
            UL_rb.Enabled = false;
            UL_rb.Location = new Point(102, 0);
            UL_rb.Name = "UL_rb";
            UL_rb.Size = new Size(133, 19);
            UL_rb.TabIndex = 51;
            UL_rb.Text = "Юридическое лицо";
            UL_rb.UseVisualStyleBackColor = true;
            UL_rb.CheckedChanged += Subject_RadioButton_CheckedChanged;
            // 
            // FL_rb
            // 
            FL_rb.AutoSize = true;
            FL_rb.Enabled = false;
            FL_rb.Location = new Point(313, 0);
            FL_rb.Name = "FL_rb";
            FL_rb.Size = new Size(122, 19);
            FL_rb.TabIndex = 52;
            FL_rb.Text = "Физическое лицо";
            FL_rb.UseVisualStyleBackColor = true;
            FL_rb.CheckedChanged += Subject_RadioButton_CheckedChanged;
            // 
            // formProgressBar
            // 
            formProgressBar.ForeColor = SystemColors.Desktop;
            formProgressBar.Location = new Point(7, 518);
            formProgressBar.Name = "formProgressBar";
            formProgressBar.Size = new Size(739, 18);
            formProgressBar.TabIndex = 50;
            // 
            // InputsPannel
            // 
            InputsPannel.Controls.Add(CommonName_label);
            InputsPannel.Controls.Add(OGRNIP_input);
            InputsPannel.Controls.Add(OGRN_label);
            InputsPannel.Controls.Add(INN_IP_Input);
            InputsPannel.Controls.Add(JobTitle_label);
            InputsPannel.Controls.Add(INN_UL_input);
            InputsPannel.Controls.Add(SNILS_label);
            InputsPannel.Controls.Add(SNILS_input);
            InputsPannel.Controls.Add(Subdivision_label);
            InputsPannel.Controls.Add(OGRN_input);
            InputsPannel.Controls.Add(INN_UL_label);
            InputsPannel.Controls.Add(JobTitle_input);
            InputsPannel.Controls.Add(OrgName_label);
            InputsPannel.Controls.Add(Subdivision_input);
            InputsPannel.Controls.Add(INN_IP_Label);
            InputsPannel.Controls.Add(OrgName_input);
            InputsPannel.Controls.Add(Region_label);
            InputsPannel.Controls.Add(Region_input);
            InputsPannel.Controls.Add(OGRNIP_label);
            InputsPannel.Controls.Add(City_input);
            InputsPannel.Controls.Add(City_label);
            InputsPannel.Controls.Add(CommonName_input);
            InputsPannel.Controls.Add(FullAdress_input);
            InputsPannel.Controls.Add(FullAdress_label);
            InputsPannel.Controls.Add(Surname_label);
            InputsPannel.Controls.Add(Surname_input);
            InputsPannel.Controls.Add(NameLastName_input);
            InputsPannel.Controls.Add(NameLastName_label);
            InputsPannel.Location = new Point(7, 88);
            InputsPannel.Name = "InputsPannel";
            InputsPannel.Size = new Size(749, 423);
            InputsPannel.TabIndex = 49;
            // 
            // CommonName_label
            // 
            CommonName_label.AutoSize = true;
            CommonName_label.Location = new Point(3, 14);
            CommonName_label.Name = "CommonName_label";
            CommonName_label.Size = new Size(71, 15);
            CommonName_label.TabIndex = 11;
            CommonName_label.Text = "Общее имя";
            // 
            // OGRNIP_input
            // 
            OGRNIP_input.Cursor = Cursors.IBeam;
            OGRNIP_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            OGRNIP_input.Location = new Point(102, 359);
            OGRNIP_input.Name = "OGRNIP_input";
            OGRNIP_input.PlaceholderText = "ОГРНИП ИП";
            OGRNIP_input.ReadOnly = true;
            OGRNIP_input.Size = new Size(637, 22);
            OGRNIP_input.TabIndex = 48;
            // 
            // OGRN_label
            // 
            OGRN_label.AutoSize = true;
            OGRN_label.Location = new Point(3, 275);
            OGRN_label.Name = "OGRN_label";
            OGRN_label.Size = new Size(38, 15);
            OGRN_label.TabIndex = 29;
            OGRN_label.Text = "ОГРН";
            // 
            // INN_IP_Input
            // 
            INN_IP_Input.Cursor = Cursors.IBeam;
            INN_IP_Input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            INN_IP_Input.Location = new Point(102, 301);
            INN_IP_Input.Name = "INN_IP_Input";
            INN_IP_Input.PlaceholderText = "ИНН ИП, ФЛ или ЕИО предприятия";
            INN_IP_Input.ReadOnly = true;
            INN_IP_Input.Size = new Size(637, 22);
            INN_IP_Input.TabIndex = 46;
            // 
            // JobTitle_label
            // 
            JobTitle_label.AutoSize = true;
            JobTitle_label.Location = new Point(3, 246);
            JobTitle_label.Name = "JobTitle_label";
            JobTitle_label.Size = new Size(69, 15);
            JobTitle_label.TabIndex = 27;
            JobTitle_label.Text = "Должность";
            // 
            // INN_UL_input
            // 
            INN_UL_input.Cursor = Cursors.IBeam;
            INN_UL_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            INN_UL_input.Location = new Point(102, 330);
            INN_UL_input.Name = "INN_UL_input";
            INN_UL_input.PlaceholderText = "ИНН предприятия";
            INN_UL_input.ReadOnly = true;
            INN_UL_input.Size = new Size(637, 22);
            INN_UL_input.TabIndex = 34;
            // 
            // SNILS_label
            // 
            SNILS_label.AutoSize = true;
            SNILS_label.Location = new Point(3, 391);
            SNILS_label.Name = "SNILS_label";
            SNILS_label.Size = new Size(49, 15);
            SNILS_label.TabIndex = 31;
            SNILS_label.Text = "СНИЛС";
            // 
            // SNILS_input
            // 
            SNILS_input.Cursor = Cursors.IBeam;
            SNILS_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            SNILS_input.Location = new Point(102, 388);
            SNILS_input.Name = "SNILS_input";
            SNILS_input.PlaceholderText = "Номер СНИЛС. Генерируется автоматически";
            SNILS_input.ReadOnly = true;
            SNILS_input.Size = new Size(637, 22);
            SNILS_input.TabIndex = 32;
            // 
            // Subdivision_label
            // 
            Subdivision_label.AutoSize = true;
            Subdivision_label.Location = new Point(3, 217);
            Subdivision_label.Name = "Subdivision_label";
            Subdivision_label.Size = new Size(92, 15);
            Subdivision_label.TabIndex = 25;
            Subdivision_label.Text = "Подразделение";
            // 
            // OGRN_input
            // 
            OGRN_input.Cursor = Cursors.IBeam;
            OGRN_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            OGRN_input.Location = new Point(102, 272);
            OGRN_input.Name = "OGRN_input";
            OGRN_input.PlaceholderText = "Номер ОГРН предприятия";
            OGRN_input.ReadOnly = true;
            OGRN_input.Size = new Size(637, 22);
            OGRN_input.TabIndex = 30;
            // 
            // INN_UL_label
            // 
            INN_UL_label.AutoSize = true;
            INN_UL_label.Location = new Point(3, 333);
            INN_UL_label.Name = "INN_UL_label";
            INN_UL_label.Size = new Size(57, 15);
            INN_UL_label.TabIndex = 33;
            INN_UL_label.Text = "ИНН ЮЛ";
            // 
            // JobTitle_input
            // 
            JobTitle_input.Cursor = Cursors.IBeam;
            JobTitle_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            JobTitle_input.Location = new Point(102, 243);
            JobTitle_input.Name = "JobTitle_input";
            JobTitle_input.PlaceholderText = "Должность ИП, ФЛ или владельца ключа в предприятии";
            JobTitle_input.ReadOnly = true;
            JobTitle_input.Size = new Size(637, 22);
            JobTitle_input.TabIndex = 28;
            // 
            // OrgName_label
            // 
            OrgName_label.AutoSize = true;
            OrgName_label.Location = new Point(3, 188);
            OrgName_label.Name = "OrgName_label";
            OrgName_label.Size = new Size(79, 15);
            OrgName_label.TabIndex = 23;
            OrgName_label.Text = "Организация";
            // 
            // Subdivision_input
            // 
            Subdivision_input.Cursor = Cursors.IBeam;
            Subdivision_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            Subdivision_input.Location = new Point(102, 214);
            Subdivision_input.Name = "Subdivision_input";
            Subdivision_input.PlaceholderText = "Статический параметр \"Онлайн\"";
            Subdivision_input.ReadOnly = true;
            Subdivision_input.Size = new Size(637, 22);
            Subdivision_input.TabIndex = 26;
            // 
            // INN_IP_Label
            // 
            INN_IP_Label.AutoSize = true;
            INN_IP_Label.Location = new Point(3, 304);
            INN_IP_Label.Name = "INN_IP_Label";
            INN_IP_Label.Size = new Size(77, 15);
            INN_IP_Label.TabIndex = 45;
            INN_IP_Label.Text = "ИНН ИП/ФЛ";
            // 
            // OrgName_input
            // 
            OrgName_input.Cursor = Cursors.IBeam;
            OrgName_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            OrgName_input.Location = new Point(102, 185);
            OrgName_input.Name = "OrgName_input";
            OrgName_input.PlaceholderText = "Полное наименование предприятия, ИП или ФЛ";
            OrgName_input.ReadOnly = true;
            OrgName_input.Size = new Size(637, 22);
            OrgName_input.TabIndex = 24;
            // 
            // Region_label
            // 
            Region_label.AutoSize = true;
            Region_label.Location = new Point(3, 159);
            Region_label.Name = "Region_label";
            Region_label.Size = new Size(53, 15);
            Region_label.TabIndex = 21;
            Region_label.Text = "Область";
            // 
            // Region_input
            // 
            Region_input.Cursor = Cursors.IBeam;
            Region_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            Region_input.Location = new Point(102, 156);
            Region_input.Name = "Region_input";
            Region_input.PlaceholderText = "Область регистрации предприятия, ИП или ФЛ";
            Region_input.ReadOnly = true;
            Region_input.Size = new Size(637, 22);
            Region_input.TabIndex = 22;
            // 
            // OGRNIP_label
            // 
            OGRNIP_label.AutoSize = true;
            OGRNIP_label.Location = new Point(3, 362);
            OGRNIP_label.Name = "OGRNIP_label";
            OGRNIP_label.Size = new Size(56, 15);
            OGRNIP_label.TabIndex = 47;
            OGRNIP_label.Text = "ОГРНИП";
            // 
            // City_input
            // 
            City_input.Cursor = Cursors.IBeam;
            City_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            City_input.Location = new Point(102, 127);
            City_input.Name = "City_input";
            City_input.PlaceholderText = "Город регистрации предприятия, ИП или ФЛ";
            City_input.ReadOnly = true;
            City_input.Size = new Size(637, 22);
            City_input.TabIndex = 20;
            // 
            // City_label
            // 
            City_label.AutoSize = true;
            City_label.Location = new Point(3, 130);
            City_label.Name = "City_label";
            City_label.Size = new Size(40, 15);
            City_label.TabIndex = 19;
            City_label.Text = "Город";
            // 
            // CommonName_input
            // 
            CommonName_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            CommonName_input.Location = new Point(102, 11);
            CommonName_input.Name = "CommonName_input";
            CommonName_input.PlaceholderText = "Сокращенное наименование предприятия, ИП или ФЛ";
            CommonName_input.ReadOnly = true;
            CommonName_input.Size = new Size(637, 22);
            CommonName_input.TabIndex = 12;
            // 
            // FullAdress_input
            // 
            FullAdress_input.Cursor = Cursors.IBeam;
            FullAdress_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            FullAdress_input.Location = new Point(102, 98);
            FullAdress_input.Name = "FullAdress_input";
            FullAdress_input.PlaceholderText = "Полный адрес регистрации предприятия, ИП или ФЛ";
            FullAdress_input.ReadOnly = true;
            FullAdress_input.Size = new Size(637, 22);
            FullAdress_input.TabIndex = 18;
            // 
            // FullAdress_label
            // 
            FullAdress_label.AutoSize = true;
            FullAdress_label.Location = new Point(3, 101);
            FullAdress_label.Name = "FullAdress_label";
            FullAdress_label.Size = new Size(40, 15);
            FullAdress_label.TabIndex = 17;
            FullAdress_label.Text = "Адрес";
            // 
            // Surname_label
            // 
            Surname_label.AutoSize = true;
            Surname_label.Location = new Point(3, 43);
            Surname_label.Name = "Surname_label";
            Surname_label.Size = new Size(58, 15);
            Surname_label.TabIndex = 13;
            Surname_label.Text = "Фамилия";
            // 
            // Surname_input
            // 
            Surname_input.Cursor = Cursors.IBeam;
            Surname_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            Surname_input.Location = new Point(102, 40);
            Surname_input.Name = "Surname_input";
            Surname_input.PlaceholderText = "Фамилия ИП, ФЛ или ЕИО предприятия";
            Surname_input.ReadOnly = true;
            Surname_input.Size = new Size(637, 22);
            Surname_input.TabIndex = 14;
            // 
            // NameLastName_input
            // 
            NameLastName_input.Cursor = Cursors.IBeam;
            NameLastName_input.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            NameLastName_input.Location = new Point(102, 69);
            NameLastName_input.Name = "NameLastName_input";
            NameLastName_input.PlaceholderText = "Имя и Отчество ИП, ФЛ или ЕИО предприятия";
            NameLastName_input.ReadOnly = true;
            NameLastName_input.Size = new Size(637, 22);
            NameLastName_input.TabIndex = 16;
            // 
            // NameLastName_label
            // 
            NameLastName_label.AutoSize = true;
            NameLastName_label.Location = new Point(3, 72);
            NameLastName_label.Name = "NameLastName_label";
            NameLastName_label.Size = new Size(93, 15);
            NameLastName_label.TabIndex = 15;
            NameLastName_label.Text = "Имя и отчество";
            // 
            // httpFix_chb
            // 
            httpFix_chb.AutoSize = true;
            httpFix_chb.Enabled = false;
            httpFix_chb.Location = new Point(548, 37);
            httpFix_chb.Name = "httpFix_chb";
            httpFix_chb.Size = new Size(134, 19);
            httpFix_chb.TabIndex = 13;
            httpFix_chb.Text = "Использовать HTTP";
            httpFix_chb.UseVisualStyleBackColor = true;
            httpFix_chb.CheckedChanged += httpFix_chb_CheckedChanged;
            // 
            // createHistory_chb
            // 
            createHistory_chb.AutoSize = true;
            createHistory_chb.Location = new Point(423, 37);
            createHistory_chb.Name = "createHistory_chb";
            createHistory_chb.Size = new Size(119, 19);
            createHistory_chb.TabIndex = 12;
            createHistory_chb.Text = "История ключей";
            createHistory_chb.UseVisualStyleBackColor = true;
            createHistory_chb.CheckedChanged += createHistory_chb_CheckedChanged;
            // 
            // downloadEGR_btn
            // 
            downloadEGR_btn.Enabled = false;
            downloadEGR_btn.Location = new Point(133, 33);
            downloadEGR_btn.Name = "downloadEGR_btn";
            downloadEGR_btn.Size = new Size(127, 23);
            downloadEGR_btn.TabIndex = 11;
            downloadEGR_btn.Text = "Скачать выписку";
            downloadEGR_btn.UseVisualStyleBackColor = true;
            downloadEGR_btn.Click += downloadEGR_btn_Click;
            // 
            // showBrowser_chb
            // 
            showBrowser_chb.AutoSize = true;
            showBrowser_chb.Enabled = false;
            showBrowser_chb.Location = new Point(277, 37);
            showBrowser_chb.Name = "showBrowser_chb";
            showBrowser_chb.Size = new Size(140, 19);
            showBrowser_chb.TabIndex = 8;
            showBrowser_chb.Text = "Отображать браузер";
            showBrowser_chb.UseVisualStyleBackColor = true;
            showBrowser_chb.CheckedChanged += showBrowser_chb_CheckedChanged;
            // 
            // registerINN_btn
            // 
            registerINN_btn.Enabled = false;
            registerINN_btn.Location = new Point(6, 33);
            registerINN_btn.Name = "registerINN_btn";
            registerINN_btn.Size = new Size(121, 23);
            registerINN_btn.TabIndex = 4;
            registerINN_btn.Text = "Зарегистрировать";
            registerINN_btn.UseVisualStyleBackColor = true;
            registerINN_btn.Click += registerINN_btn_Click;
            // 
            // getINNdata_btn
            // 
            getINNdata_btn.Enabled = false;
            getINNdata_btn.Location = new Point(453, 5);
            getINNdata_btn.Name = "getINNdata_btn";
            getINNdata_btn.Size = new Size(140, 23);
            getINNdata_btn.TabIndex = 3;
            getINNdata_btn.Text = "Получить данные";
            getINNdata_btn.UseVisualStyleBackColor = true;
            getINNdata_btn.Click += getINNdata_btn_ClickAsync;
            // 
            // INN_input
            // 
            INN_input.Culture = new System.Globalization.CultureInfo("");
            INN_input.ForeColor = SystemColors.WindowText;
            INN_input.Location = new Point(97, 6);
            INN_input.Mask = "000000000000";
            INN_input.Name = "INN_input";
            INN_input.PromptChar = ' ';
            INN_input.Size = new Size(350, 23);
            INN_input.TabIndex = 2;
            INN_input.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            INN_input.Click += INN_input_Click;
            INN_input.TextChanged += INN_input_TextChanged;
            // 
            // INN_label
            // 
            INN_label.AutoSize = true;
            INN_label.Location = new Point(7, 9);
            INN_label.Name = "INN_label";
            INN_label.Size = new Size(80, 15);
            INN_label.TabIndex = 0;
            INN_label.Text = "Введите ИНН";
            // 
            // isManual
            // 
            isManual.AutoSize = true;
            isManual.Location = new Point(599, 8);
            isManual.Name = "isManual";
            isManual.Size = new Size(134, 19);
            isManual.TabIndex = 56;
            isManual.Text = "Ручное заполнение";
            isManual.UseVisualStyleBackColor = true;
            isManual.Click += isManual_Click;
            // 
            // DerjavaTools
            // 
            AccessibleName = "MainForm";
            AccessibleRole = AccessibleRole.Window;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(760, 571);
            Controls.Add(MainTabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(776, 610);
            Name = "DerjavaTools";
            Text = "Держава TollBox";
            MainTabControl.ResumeLayout(false);
            KeyGenTab.ResumeLayout(false);
            KeyGenTab.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SNILS_DataGridView).EndInit();
            subjectControl.ResumeLayout(false);
            subjectControl.PerformLayout();
            InputsPannel.ResumeLayout(false);
            InputsPannel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl MainTabControl;
        protected TabPage KeyGenTab;
        private RadioButton IP_rb;
        private Panel panel1;
        private DataGridView SNILS_DataGridView;
        private Panel subjectControl;
        private RadioButton UL_rb;
        private RadioButton FL_rb;
        private ProgressBar formProgressBar;
        private Panel InputsPannel;
        private Label CommonName_label;
        private TextBox OGRNIP_input;
        private Label OGRN_label;
        private TextBox INN_IP_Input;
        private Label JobTitle_label;
        private TextBox INN_UL_input;
        private Label SNILS_label;
        private TextBox SNILS_input;
        private Label Subdivision_label;
        private TextBox OGRN_input;
        private Label INN_UL_label;
        private TextBox JobTitle_input;
        private Label OrgName_label;
        private TextBox Subdivision_input;
        private Label INN_IP_Label;
        private TextBox OrgName_input;
        private Label Region_label;
        private TextBox Region_input;
        private Label OGRNIP_label;
        private TextBox City_input;
        private Label City_label;
        private TextBox CommonName_input;
        private TextBox FullAdress_input;
        private Label FullAdress_label;
        private Label Surname_label;
        private TextBox Surname_input;
        private TextBox NameLastName_input;
        private Label NameLastName_label;
        private CheckBox httpFix_chb;
        private CheckBox createHistory_chb;
        private Button downloadEGR_btn;
        private CheckBox showBrowser_chb;
        private Button registerINN_btn;
        private Button getINNdata_btn;
        private MaskedTextBox INN_input;
        private Label INN_label;
        private DataGridViewTextBoxColumn Date_clmn;
        private DataGridViewTextBoxColumn CommonName_clmn;
        private DataGridViewTextBoxColumn INN_UL_clmn;
        private DataGridViewTextBoxColumn FIO_clmn;
        private DataGridViewTextBoxColumn INN_IP_clmn;
        private DataGridViewTextBoxColumn SNILS_clmn;
        private CheckBox isManual;
    }
}