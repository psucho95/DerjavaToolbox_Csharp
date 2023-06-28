namespace WinFormsApp1
{
    public partial class RegNumFinder : Form
    {
        public RegNumFinder()
        {
            InitializeComponent();
        }

        private void getData_btn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                List<string> listOfRegnums = RegNumInfosGetter.getTagInfo(tenderId_input.Text);
                ContractsGetter.getContractsInfo(listOfRegnums, progressBar, tenderId_input, getData_btn);
            }
            catch (Exception exception)
            {
                tenderId_input.Text = "";
                getData_btn.Enabled = false;
                ToolTipCreator.creteToolTip(tenderId_input, 25, 30, 3000, "Ошибка введённого тендера");
            }
        }

        private void tenderId_input_TextChanged(object sender, EventArgs e)
        {
            tenderId_input.SelectionStart = 0;
            if (tenderId_input.Text.Length != 19)
            {
                getData_btn.Enabled = false;
            }
            else if (tenderId_input.Text.Length == 19)
            {
                getData_btn.Enabled = true;
            }
        }

        private void tenderId_input_MouseClick(object sender, MouseEventArgs e)
        {
            tenderId_input.SelectionStart = 0;
        }
    }
}