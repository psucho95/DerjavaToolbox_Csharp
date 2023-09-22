using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DerjavaToolbox
{
    public partial class Form2 : Form
    {
        private static string selectedSNILS = null;
        private int rowIndex;
        public Form2()
        {
            InitializeComponent();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            if (selectedSNILS == null)
            {
                selectedSNILS = Selector_DataGridView.Rows[0].Cells[0].Value.ToString();
            }

            this.Close();
        }

        private void Confirm_btn_Click(object sender, EventArgs e)
        {
            selectedSNILS = Selector_DataGridView.CurrentCell.Value.ToString();
            this.Close();
        }

        public string returnSelectedSNILS()
        {
            return selectedSNILS;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (selectedSNILS == null)
            {
                selectedSNILS = Selector_DataGridView.Rows[0].Cells[0].Value.ToString();
            }
        }
    }
}
