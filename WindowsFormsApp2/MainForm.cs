using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            Map.MapProvider = GMapProviders.OpenStreetMap;
            double latitude = 52.2188;
            double longitude = 21.0026;
            Map.Position = new PointLatLng(latitude, longitude);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            Console.WriteLine(LatitudeTextBox.Text);
            Console.WriteLine(LongitudeTextBox.Text);
            double latitude = Convert.ToDouble(LatitudeTextBox.Text, provider);
            double longitude = Convert.ToDouble(LongitudeTextBox.Text, provider);
            Map.Position = new PointLatLng(latitude, longitude);
        }
    }
}
