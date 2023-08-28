using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Controls
{
    public partial class AdjustHeightForm : Form
    {
        Building BuildingInstance;
        public AdjustHeightForm(Building buildingInstance)
        {
            InitializeComponent();
            BuildingInstance = buildingInstance;
        }

        private void ChoosingHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(ChoosingHeightTextBox.Text))
            {
                ChoosingHeightTextBox.Text = string.Empty;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ChoosingHeightTextBox.Text != string.Empty)
            {
                BuildingInstance.tags.height = ChoosingHeightTextBox.Text;
                BuildingInstance.HeightChanged = true;
                this.Close();
            } else
            {
                MessageBox.Show("You need to choose building height",
                 "Choose height", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
