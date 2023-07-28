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
        public static int BaseZoom = 1;
        public MainForm()
        {
            InitializeComponent();
            Map.MapProvider = GMapProviders.OpenStreetMap;
            double latitude = 52.2188;
            double longitude = 21.0026;
            Map.Position = new PointLatLng(latitude, longitude);
            Map.MouseWheelZoomEnabled = true;
            Map.MaxZoom = 20;
            Map.MinZoom = 3;
            Map.Zoom = Map.MinZoom;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            /*NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            Console.WriteLine(LatitudeTextBox.Text);
            Console.WriteLine(LongitudeTextBox.Text);
            double latitude = Convert.ToDouble(LatitudeTextBox.Text, provider);
            double longitude = Convert.ToDouble(LongitudeTextBox.Text, provider);*/
            Map.SetPositionByKeywords(AddressTextBox.Text);
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            Map.Zoom = Math.Min(Map.MaxZoom, Map.Zoom + BaseZoom );
            Console.WriteLine(Map.Zoom);
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            Map.Zoom = Math.Max(Map.MinZoom, Map.Zoom - BaseZoom);
            Console.WriteLine(Map.Zoom);

        }

        private void Map_Load(object sender, EventArgs e)
        {

        }
    }
}
