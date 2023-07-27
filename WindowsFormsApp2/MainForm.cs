using GMap.NET;
using GMap.NET.MapProviders;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            GMap.MapProvider = GMapProviders.OpenStreetMap;
            double latitude = Convert.ToDouble(LatitudeTextBox.Text);
            double longitude = Convert.ToDouble(LongitudeTextBox.Text);
            GMap.Position = new PointLatLng(latitude, longitude);
        }
    }
}
