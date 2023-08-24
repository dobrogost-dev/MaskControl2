using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class DefaultHeightForm : Form
    {
        private MaskCalculator MaskCalculatorInstance;
        private string Language;

        public DefaultHeightForm(MaskCalculator maskCalulatorInstance)
        {
            InitializeComponent();
            MaskCalculatorInstance = maskCalulatorInstance;
            SetTextboxesVisible();
        }

        private void SetTextboxesVisible()
        {
            if (MaskCalculatorInstance.DefaultLeftNotFound)
            {
                DefaultLeftBuildingHeightTextBox.Visible = true;
            }
            if (MaskCalculatorInstance.DefaultLeftMiddleNotFound)
            {
                DefaultLeftMiddleBuildingHeightTextBox.Visible = true;

            }
            if (MaskCalculatorInstance.DefaultRightMiddleNotFound)
            {
                DefaultRightMiddleBuildingHeightTextBox.Visible = true;

            }
            if (MaskCalculatorInstance.DefaultRightNotFound)
            {
                DefaultRightBuildingHeightTextBox.Visible = true;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            bool CanExit = true;
            if (DefaultLeftBuildingHeightTextBox.Visible)
            {
                if (DefaultLeftBuildingHeightTextBox.Text == string.Empty)
                {
                    CanExit = false;
                } else
                {
                    MaskCalculatorInstance.DefaultLeftBuildingHeight = double.Parse(DefaultLeftBuildingHeightTextBox.Text);
                }
            }
            if (DefaultLeftMiddleBuildingHeightTextBox.Visible)
            {
                if (DefaultLeftMiddleBuildingHeightTextBox.Text == string.Empty)
                {
                    CanExit = false;
                } else
                {
                    MaskCalculatorInstance.DefaultLeftMiddleBuildingHeight = double.Parse(DefaultLeftMiddleBuildingHeightTextBox.Text);
                }
            }
            if (DefaultRightMiddleBuildingHeightTextBox.Visible)
            {
                if (DefaultRightMiddleBuildingHeightTextBox.Text == string.Empty)
                {
                    CanExit = false;
                } else
                {
                    MaskCalculatorInstance.DefaultRightMiddleBuildingHeight = double.Parse(DefaultRightMiddleBuildingHeightTextBox.Text);
                }
            }
            if (DefaultRightBuildingHeightTextBox.Visible)
            {
                if (DefaultRightBuildingHeightTextBox.Text == string.Empty)
                {
                    CanExit = false;
                } else
                {
                    MaskCalculatorInstance.DefaultRightBuildingHeight = double.Parse(DefaultRightBuildingHeightTextBox.Text);
                }
            }
            
            if (CanExit)
            {
                this.Close();
            } else
            {
                MessageBox.Show("Vous devez entrer des données pour tous les secteurs afin de continuer",
                    "Certaines valeurs manquent", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DefaultLeftBuildingHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(DefaultLeftBuildingHeightTextBox.Text))
            {
                DefaultLeftBuildingHeightTextBox.Text = string.Empty;
            }
        }
        private void DefaultLeftMiddleBuildingHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(DefaultLeftMiddleBuildingHeightTextBox.Text))
            {
                DefaultLeftMiddleBuildingHeightTextBox.Text = string.Empty;
            }
        }

        private void DefaultRightMiddleBuildingHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(DefaultRightMiddleBuildingHeightTextBox.Text))
            {
                DefaultRightMiddleBuildingHeightTextBox.Text = string.Empty;
            }
        }

        private void DefaultRightBuildingHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(DefaultRightBuildingHeightTextBox.Text))
            {
                DefaultRightBuildingHeightTextBox.Text = string.Empty;
            }
        }
    }
}
