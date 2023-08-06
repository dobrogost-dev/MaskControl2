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
using GMapRoute = GMap.NET.WindowsForms.GMapRoute;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        public static int BaseZoom = 1;
        public GMapOverlay markersOverlay;
        public GMapOverlay polygonsOverlay;
        public GMapOverlay linesOverlay;
        public GMarkerGoogle currentMarker;
        public MaskCalculator maskCalculator;
        public MainForm()
        {
            currentMarker = new GMarkerGoogle(new PointLatLng(0, 0), GMarkerGoogleType.red_dot);
            maskCalculator = new MaskCalculator();

            InitializeComponent();
            double DefaultLatitude = 52.2188;
            double DefaultLongitude = 21.0026;
            SetMapConfiguration(DefaultLatitude, DefaultLongitude);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            LatitudeTextBox.ReadOnly = true;
            LongitudeTextBox.ReadOnly = true;
            East_SouthEastTextBox.ReadOnly = true;
            SouthEast_SouthTextBox.ReadOnly = true;
            South_SouthWestTextBox.ReadOnly = true;
            SouthWest_WestTextBox.ReadOnly = true;

            string DefaultRadius = "100";
            string DefaultFloorHeight = "2,7";
            string DefaultBuildingHeight = "10";

            RadiusTextBox.Text = DefaultRadius;
            DefaultFloorHeightTextBox.Text = DefaultFloorHeight;
            DefaultBuildingHeightTextBox.Text = DefaultBuildingHeight;

            MaskButton.Enabled = false;
            BuildingDataLegendPanel.Visible = false;
            DirectionLegendPanel.Visible = false;
            linesOverlay.IsVisibile = false;
        }

        private void SetMapConfiguration(double DefaultLatitude, double DefaultLongitude)
        {
            Map.MapProvider = GMapProviders.OpenStreetMap;
            Map.Position = new PointLatLng(DefaultLatitude, DefaultLongitude);
            Map.MouseWheelZoomEnabled = true;
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            Map.ShowCenter = false;
            Map.MaxZoom = 20;
            Map.MinZoom = 3;
            Map.Zoom = Map.MinZoom;
            Map.MouseDoubleClick += GMapControl_MouseDoubleClick;
            Map.DragButton = MouseButtons.Left;
            Map.Margin = new Padding(10);
            Map.BorderStyle = BorderStyle.FixedSingle;

            markersOverlay = new GMapOverlay("markers");
            polygonsOverlay = new GMapOverlay("polygons");
            linesOverlay = new GMapOverlay("lines");
            Map.Overlays.Add(markersOverlay);
            Map.Overlays.Add(polygonsOverlay);
            Map.Overlays.Add(linesOverlay);
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
        private void GMapControl_MouseDoubleClick(object sender, MouseEventArgs e)
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
            MaskButton.Enabled = true;
        }
        private async void MaskButton_Click(object sender, EventArgs e)
        {
            if (RadiusTextBox.Text == string.Empty)
            {
                MessageBox.Show("Radius value is required in order to calculate mask",
                    "Radius required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DefaultFloorHeightTextBox.Text == string.Empty)
            {
                MessageBox.Show("Default building floor height value is required in order to calculate mask",
                    "Default building floor height required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DefaultBuildingHeightTextBox.Text == string.Empty)
            {
                MessageBox.Show("Default building height value is required in order to calculate mask",
                    "Default building height required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (markersOverlay.Markers.Count == 0)
            {
                MessageBox.Show("Marker is required in order to calculate mask",
                    "Marker required", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Console.WriteLine(jsonResponse);
                        OSMdata apiResponse = JsonConvert.DeserializeObject<OSMdata>(jsonResponse);
                        maskCalculator.LoadData(apiResponse, currentMarker.Position);
                        //maskCalculator.ShowBuildingsLogs();
                        maskCalculator.DrawBuildings(polygonsOverlay, DirectionRadioButton.Checked);
                        double DefaultFloorHeight = Double.Parse(DefaultFloorHeightTextBox.Text);
                        double DefaultBuildingHeight = Double.Parse(DefaultBuildingHeightTextBox.Text);
                        MaskResult MaskResults = maskCalculator.CalculateMasks(DefaultFloorHeight, DefaultBuildingHeight);

                        maskCalculator.DrawLines(linesOverlay, radius);
                        Map.Refresh();
                        East_SouthEastTextBox.Text = Math.Round(MaskResults.East_SouthEast, 2).ToString() + "°"; 
                        SouthEast_SouthTextBox.Text = Math.Round(MaskResults.SouthEast_South, 2).ToString() + "°";
                        South_SouthWestTextBox.Text = Math.Round(MaskResults.South_SouthWest, 2).ToString() + "°";
                        SouthWest_WestTextBox.Text = Math.Round(MaskResults.SouthWest_West, 2).ToString() + "°";

                        DirectionLegendPanel.Visible = true;
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
        private void DirectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BuildingDataRadioButton.Checked = !DirectionRadioButton.Checked;
            if (maskCalculator.Initialized)
            {
                maskCalculator.DrawBuildings(polygonsOverlay, true);
                Map.Refresh();
                DirectionLegendPanel.Visible = true;
                BuildingDataLegendPanel.Visible = false;
            }
        }

        private void BuildingDataRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DirectionRadioButton.Checked = !BuildingDataRadioButton.Checked;
            if (maskCalculator.Initialized)
            {
                maskCalculator.DrawBuildings(polygonsOverlay, false);
                Map.Refresh();
                DirectionLegendPanel.Visible = false;
                BuildingDataLegendPanel.Visible = true;
            }
        }
        private void DirectionLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DirectionLinesCheckBox.Checked)
            {
                linesOverlay.IsVisibile = true;
            } else
            {
                linesOverlay.IsVisibile = false;
            }
        }

        private void RadiusTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(RadiusTextBox.Text))
            {
                RadiusTextBox.Text = string.Empty;
            }
        }
        private void DefaultFloorHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(DefaultFloorHeightTextBox.Text))
            {
                DefaultFloorHeightTextBox.Text = string.Empty;
            }
        }

        private void DefaultBuildingHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!MainFormUtilities.IsValidDecimal(DefaultBuildingHeightTextBox.Text))
            {
                DefaultBuildingHeightTextBox.Text = string.Empty;
            }
        }
    }
}
