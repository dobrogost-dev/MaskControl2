using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsPresentation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GMap.NET.Entity.OpenStreetMapGraphHopperGeocodeEntity;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        public static int BaseZoom = 1;
        public GMapOverlay markersOverlay;
        public GMapOverlay polygonsOverlay;
        public GMarkerGoogle currentMarker = new GMarkerGoogle(new PointLatLng(0,0), GMarkerGoogleType.red_dot);
        public MaskCalculator maskCalculator = new MaskCalculator();
        public MainForm()
        {
            InitializeComponent();

            Map.MapProvider = GMapProviders.OpenStreetMap;
            double DefaultLatitude = 52.2188;
            double Defaultongitude = 21.0026;
            Map.Position = new PointLatLng(DefaultLatitude, Defaultongitude);
            Map.MouseWheelZoomEnabled = true;
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            Map.ShowCenter = false;
            Map.MaxZoom = 20;
            Map.MinZoom = 3;
            Map.Zoom = Map.MinZoom;
            markersOverlay = new GMapOverlay("markers");
            polygonsOverlay = new GMapOverlay("polygons");
            Map.Overlays.Add(markersOverlay);
            Map.Overlays.Add(polygonsOverlay);
            Map.MouseClick += GMapControl_MouseClick;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LatitudeTextBox.ReadOnly = true;
            LongitudeTextBox.ReadOnly = true;
            East_SouthEastTextBox.ReadOnly = true;
            SouthEast_SouthTextBox.ReadOnly = true;
            South_SouthWestTextBox.ReadOnly = true;
            SouthWest_WestTextBox.ReadOnly = true;

            string DefaultRadius = "100";
            RadiusTextBox.Text = DefaultRadius;
            string DefaultFloorHeight = "2,7";
            DefaultFloorHeightTextBox.Text = DefaultFloorHeight;
            string DefaultBuildingHeight = "10";
            DefaultBuildingHeightTextBox.Text = DefaultBuildingHeight;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (AddressTextBox.Text != string.Empty)
            {
                Map.SetPositionByKeywords(AddressTextBox.Text);
                Map.Zoom = 18;
            }
        }
        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            Map.Zoom = Math.Min(Map.MaxZoom, Map.Zoom + BaseZoom );
            Console.WriteLine("Zoom: " + Map.Zoom);
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            Map.Zoom = Math.Max(Map.MinZoom, Map.Zoom - BaseZoom);
            Console.WriteLine("Zoom: " + Map.Zoom);
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }
        private void GMapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (markersOverlay.Markers.Count == 0) 
                {
                    markersOverlay.Markers.Add(currentMarker);
                }
                PointLatLng point = Map.FromLocalToLatLng(e.X, e.Y);
                currentMarker.Position = point;
                Map.Refresh();
                LatitudeTextBox.Text = point.Lat.ToString();
                LongitudeTextBox.Text = point.Lng.ToString();

            }
        }

        private async void MaskButton_Click(object sender, EventArgs e)
        {
            if (markersOverlay.Markers.Count == 0 ||
                RadiusTextBox.Text == string.Empty ||
                DefaultFloorHeightTextBox.Text == string.Empty ||
                DefaultBuildingHeightTextBox.Text == string.Empty)
            {
                return;
            }
            double radius = Double.Parse(RadiusTextBox.Text);
            // Zmiana double na stringa oddzielonego kropką zamiast przecinka
            string latitude = currentMarker.Position.Lat.ToString(CultureInfo.InvariantCulture);
            string longitude = currentMarker.Position.Lng.ToString(CultureInfo.InvariantCulture);

            string apiUrl = $"https://overpass-api.de/api/interpreter?data=[out:json];way[\"building\"](around:{radius},{latitude},{longitude});(._;>;);out;";
            //Console.WriteLine(apiUrl);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Wysyłamy żądanie GET do API OpenStreetMap
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    //Console.WriteLine($"Response: {response}");
                    //Console.WriteLine($"Response: {response.Content.ReadAsStringAsync()}");
                    if (response.IsSuccessStatusCode)
                    {
                        // Odczytujemy odpowiedź jako ciąg JSON
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        //Console.WriteLine(jsonResponse);
                        OSMdata apiResponse = JsonConvert.DeserializeObject<OSMdata>(jsonResponse);
                        maskCalculator.LoadData(apiResponse, currentMarker.Position);
                        maskCalculator.ShowBuildings(polygonsOverlay);
                        double DefaultFloorHeight = Double.Parse(DefaultFloorHeightTextBox.Text);
                        double DefaultBuildingHeight = Double.Parse(DefaultBuildingHeightTextBox.Text);
                        MaskResult MaskResults = maskCalculator.CalculateMasks(DefaultFloorHeight, DefaultBuildingHeight);
                        Map.Refresh();
                        East_SouthEastTextBox.Text = Math.Round(MaskResults.East_SouthEast, 2).ToString() + "°"; 
                        SouthEast_SouthTextBox.Text = Math.Round(MaskResults.SouthEast_South, 2).ToString() + "°";
                        South_SouthWestTextBox.Text = Math.Round(MaskResults.South_SouthWest, 2).ToString() + "°";
                        SouthWest_WestTextBox.Text = Math.Round(MaskResults.SouthWest_West, 2).ToString() + "°";

                    }
                    else
                    {
                        Console.WriteLine($"Błąd HTTP: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidDecimal(RadiusTextBox.Text))
            {
                RadiusTextBox.Text = string.Empty;
            }
        }

        private void DefaultFloorHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidDecimal(DefaultFloorHeightTextBox.Text))
            {
                DefaultFloorHeightTextBox.Text = string.Empty;
            }
        }

        private void DefaultBuildingHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsValidDecimal(DefaultBuildingHeightTextBox.Text))
            {
                DefaultBuildingHeightTextBox.Text = string.Empty;
            }
        }
        private bool IsValidDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }

        private void LongitudeLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
