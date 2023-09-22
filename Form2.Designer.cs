namespace DerjavaToolbox
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            Confirm_btn = new Button();
            Cancel_btn = new Button();
            Selector_DataGridView = new DataGridView();
            richTextBox1 = new RichTextBox();
            SNILS_clmn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Selector_DataGridView).BeginInit();
            SuspendLayout();
            // 
            // Confirm_btn
            // 
            Confirm_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Confirm_btn.Location = new Point(225, 165);
            Confirm_btn.Name = "Confirm_btn";
            Confirm_btn.Size = new Size(75, 23);
            Confirm_btn.TabIndex = 0;
            Confirm_btn.Text = "Выбрать";
            Confirm_btn.UseVisualStyleBackColor = true;
            Confirm_btn.Click += Confirm_btn_Click;
            // 
            // Cancel_btn
            // 
            Cancel_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Cancel_btn.Location = new Point(306, 165);
            Cancel_btn.Name = "Cancel_btn";
            Cancel_btn.Size = new Size(75, 23);
            Cancel_btn.TabIndex = 1;
            Cancel_btn.Text = "Отмена";
            Cancel_btn.UseVisualStyleBackColor = true;
            Cancel_btn.Click += Cancel_btn_Click;
            // 
            // Selector_DataGridView
            // 
            Selector_DataGridView.AllowUserToAddRows = false;
            Selector_DataGridView.AllowUserToDeleteRows = false;
            Selector_DataGridView.AllowUserToResizeColumns = false;
            Selector_DataGridView.AllowUserToResizeRows = false;
            Selector_DataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Selector_DataGridView.BackgroundColor = SystemColors.Control;
            Selector_DataGridView.BorderStyle = BorderStyle.None;
            Selector_DataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Selector_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Selector_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Selector_DataGridView.Columns.AddRange(new DataGridViewColumn[] { SNILS_clmn });
            Selector_DataGridView.GridColor = SystemColors.Control;
            Selector_DataGridView.Location = new Point(12, 27);
            Selector_DataGridView.MultiSelect = false;
            Selector_DataGridView.Name = "Selector_DataGridView";
            Selector_DataGridView.ReadOnly = true;
            Selector_DataGridView.RowHeadersVisible = false;
            Selector_DataGridView.RowTemplate.Height = 25;
            Selector_DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Selector_DataGridView.ShowCellErrors = false;
            Selector_DataGridView.ShowCellToolTips = false;
            Selector_DataGridView.ShowEditingIcon = false;
            Selector_DataGridView.ShowRowErrors = false;
            Selector_DataGridView.Size = new Size(366, 132);
            Selector_DataGridView.TabIndex = 5;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(12, 8);
            richTextBox1.MaxLength = 12;
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.ShortcutsEnabled = false;
            richTextBox1.Size = new Size(354, 14);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "ИНН";
            richTextBox1.WordWrap = false;
            // 
            // SNILS_clmn
            // 
            SNILS_clmn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter;
            SNILS_clmn.DefaultCellStyle = dataGridViewCellStyle2;
            SNILS_clmn.HeaderText = "СНИЛС";
            SNILS_clmn.MaxInputLength = 15;
            SNILS_clmn.MinimumWidth = 362;
            SNILS_clmn.Name = "SNILS_clmn";
            SNILS_clmn.ReadOnly = true;
            SNILS_clmn.Resizable = DataGridViewTriState.False;
            SNILS_clmn.Width = 362;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 200);
            Controls.Add(richTextBox1);
            Controls.Add(Selector_DataGridView);
            Controls.Add(Cancel_btn);
            Controls.Add(Confirm_btn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            Text = "Выбор существующего СНИЛС";
            FormClosing += Form2_FormClosing;
            ((System.ComponentModel.ISupportInitialize)Selector_DataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        protected internal Button Confirm_btn;
        protected internal Button Cancel_btn;
        protected internal DataGridView Selector_DataGridView;
        protected internal RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn SNILS_clmn;
    }
}