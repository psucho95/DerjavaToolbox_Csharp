namespace WinFormsApp1
{
    partial class RegNumFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegNumFinder));
            tenderId_input = new MaskedTextBox();
            TipLabel = new Label();
            getData_btn = new Button();
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // tenderId_input
            // 
            tenderId_input.AccessibleRole = AccessibleRole.Row;
            tenderId_input.Location = new Point(153, 6);
            tenderId_input.Mask = "0000000000000000000";
            tenderId_input.Name = "tenderId_input";
            tenderId_input.PromptChar = ' ';
            tenderId_input.Size = new Size(207, 23);
            tenderId_input.TabIndex = 1;
            tenderId_input.MouseClick += tenderId_input_MouseClick;
            tenderId_input.TextChanged += tenderId_input_TextChanged;
            // 
            // TipLabel
            // 
            TipLabel.AccessibleName = "TipLabel";
            TipLabel.AutoSize = true;
            TipLabel.Location = new Point(12, 9);
            TipLabel.Name = "TipLabel";
            TipLabel.Size = new Size(135, 15);
            TipLabel.TabIndex = 2;
            TipLabel.Text = "Введите номер закупки";
            // 
            // getData_btn
            // 
            getData_btn.AccessibleRole = AccessibleRole.PushButton;
            getData_btn.Enabled = false;
            getData_btn.Location = new Point(12, 37);
            getData_btn.Name = "getData_btn";
            getData_btn.Size = new Size(111, 23);
            getData_btn.TabIndex = 3;
            getData_btn.Text = "Получть данные";
            getData_btn.UseVisualStyleBackColor = true;
            getData_btn.MouseClick += getData_btn_MouseClick;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(153, 35);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(207, 25);
            progressBar.TabIndex = 4;
            // 
            // RegNumFinder
            // 
            AccessibleName = "MainForm";
            AccessibleRole = AccessibleRole.Window;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 72);
            Controls.Add(progressBar);
            Controls.Add(getData_btn);
            Controls.Add(TipLabel);
            Controls.Add(tenderId_input);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegNumFinder";
            Text = "RegNumFinder 9000";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox tenderId_input;
        private Label TipLabel;
        private Button getData_btn;
        private ProgressBar progressBar;
    }
}