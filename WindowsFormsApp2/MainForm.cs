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
using static GMap.NET.Entity.OpenStreetMapGeocodeEntity;
using static GMap.NET.Entity.OpenStreetMapGraphHopperGeocodeEntity;
using GMapRoute = GMap.NET.WindowsForms.GMapRoute;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        public static int BaseZoom = 1;
        public GMapOverlay MarkersOverlay;
        public GMapOverlay PolygonsOverlay;
        public GMapOverlay SemicircleOverlay;
        public GMapOverlay LinesOverlay;
        public GMarkerGoogle CurrentMarker;
        public MaskCalculator MaskCalculatorInstance;
        public string PreviousAddress;
        public MainForm()
        {
            CurrentMarker = new GMarkerGoogle(new PointLatLng(0, 0), GMarkerGoogleType.red_dot);
            MaskCalculatorInstance = new MaskCalculator();

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
            LinesOverlay.IsVisibile = false;
            SemicircleOverlay.IsVisibile = false;
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

            MarkersOverlay = new GMapOverlay("markers");
            PolygonsOverlay = new GMapOverlay("polygons");
            SemicircleOverlay = new GMapOverlay("polygons");
            LinesOverlay = new GMapOverlay("lines");
            Map.Overlays.Add(MarkersOverlay);
            Map.Overlays.Add(PolygonsOverlay);
            Map.Overlays.Add(LinesOverlay);
            Map.Overlays.Add(SemicircleOverlay);

        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string Address = AddressTextBox.Text;
            if (Address == string.Empty)
            {
                return;
            }
            PointLatLng initialPosition = Map.Position;
            Map.SetPositionByKeywords(Address);
            if (Address == PreviousAddress)
            {

            } else if (Map.Position == initialPosition)
            {
                Console.WriteLine("Address not found");
                MessageBox.Show("Address not found",
                    "Wrong address", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            PreviousAddress = Address;
            Map.Zoom = 18;
            using (HttpClient Client = new HttpClient())
            {
                try
                {
                    string GeocodingApiUrl = $"https://geocode.maps.co/search?q={Address}";
                    HttpResponseMessage GeocodingResponse = await Client.GetAsync(GeocodingApiUrl);

                    if (!GeocodingResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Błąd HTTP: {GeocodingResponse.StatusCode}");
                        MessageBox.Show("HTTP Error",
                        "Geocoding Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string GeocodingJsonResponse = await GeocodingResponse.Content.ReadAsStringAsync();
                    List<GeocodingData> Data = JsonConvert.DeserializeObject<List<GeocodingData>>(GeocodingJsonResponse);
                    Console.WriteLine($"{GeocodingJsonResponse}");

                    foreach (GeocodingData data in Data)
                    {
                        double Latitude = double.Parse(data.Lat.Replace('.', ','));
                        double Longitude = double.Parse(data.Lon.Replace('.', ','));
                        Console.WriteLine("OSM type: " + data.OsmType);
                        Console.WriteLine("lat: " + Latitude);
                        Console.WriteLine("lon: " + Longitude);
                        if (data.OsmType == "way" && data.Class == "building")
                        {
                            if (MarkersOverlay.Markers.Count == 0)
                            {
                                MarkersOverlay.Markers.Add(CurrentMarker);
                            }
                            PointLatLng point = new PointLatLng(Latitude, Longitude);
                            CurrentMarker.Position = point;
                            Map.Refresh();
                            MaskButton.Enabled = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                }
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
            if (MarkersOverlay.Markers.Count == 0)
            {
                MarkersOverlay.Markers.Add(CurrentMarker);
            }
            PointLatLng point = Map.FromLocalToLatLng(e.X, e.Y);
            CurrentMarker.Position = point;
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
            if (MarkersOverlay.Markers.Count == 0)
            {
                MessageBox.Show("Marker is required in order to calculate mask",
                    "Marker required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double InitialRadius = 50.0;
            double Radius = Double.Parse(RadiusTextBox.Text);
            // Zmiana double na stringa oddzielonego kropką zamiast przecinka
            string MarkerLatitude = CurrentMarker.Position.Lat.ToString(CultureInfo.InvariantCulture);
            string MarkerLongitude = CurrentMarker.Position.Lng.ToString(CultureInfo.InvariantCulture);

            string BaseBuildingApiUrl = $"https://overpass-api.de/api/interpreter?data=[out:json];way[\"building\"](around:{InitialRadius},{MarkerLatitude},{MarkerLongitude});(._;>;);out;";
            using (HttpClient Client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage BaseBuildingResponse = await Client.GetAsync(BaseBuildingApiUrl);

                    if (!BaseBuildingResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Błąd HTTP: {BaseBuildingResponse.StatusCode}");
                        MessageBox.Show("HTTP Error",
                        "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string BaseBuildingJsonResponse = await BaseBuildingResponse.Content.ReadAsStringAsync();
                    OSMdata BaseBuildingApiResponse = JsonConvert.DeserializeObject<OSMdata>(BaseBuildingJsonResponse);

                    MaskCalculatorInstance.LoadBaseBuilding(BaseBuildingApiResponse, CurrentMarker.Position);

                    if (MaskCalculatorInstance.BaseBuilding == null)
                    {
                        MessageBox.Show("Base building not found",
                        "Base building not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CurrentMarker.Position = MaskCalculatorInstance.PlaceAtClosestFacade(CurrentMarker.Position);
                    string BaseBuildingLatitude = MaskCalculatorInstance.BaseBuilding.CenterPoint.Lat.ToString(CultureInfo.InvariantCulture);
                    string BaseBuildingLongitude = MaskCalculatorInstance.BaseBuilding.CenterPoint.Lng.ToString(CultureInfo.InvariantCulture);
                    string ApiUrl = $"https://overpass-api.de/api/interpreter?data=[out:json];way[\"building\"](around:{Radius},{BaseBuildingLatitude},{BaseBuildingLongitude});(._;>;);out;";
                    HttpResponseMessage Response = await Client.GetAsync(ApiUrl);

                    if (!Response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Buildings not found",
                            "Buildings not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine($"Błąd HTTP: {BaseBuildingResponse.StatusCode}");
                    }
                    string jsonResponse = await Response.Content.ReadAsStringAsync();
                    OSMdata apiResponse = JsonConvert.DeserializeObject<OSMdata>(jsonResponse);
                    MaskCalculatorInstance.LoadData(apiResponse);
                    MaskCalculatorInstance.DrawBuildings(PolygonsOverlay, DirectionRadioButton.Checked);
                    double DefaultFloorHeight = Double.Parse(DefaultFloorHeightTextBox.Text);
                    double DefaultBuildingHeight = Double.Parse(DefaultBuildingHeightTextBox.Text);
                    MaskResult MaskResults = MaskCalculatorInstance.CalculateMasks(DefaultFloorHeight, DefaultBuildingHeight);

                    MaskCalculatorInstance.DrawLines(SemicircleOverlay, LinesOverlay, Radius);
                    Map.Refresh();
                    East_SouthEastTextBox.Text = Math.Round(MaskResults.East_SouthEast, 2).ToString() + "°";
                    SouthEast_SouthTextBox.Text = Math.Round(MaskResults.SouthEast_South, 2).ToString() + "°";
                    South_SouthWestTextBox.Text = Math.Round(MaskResults.South_SouthWest, 2).ToString() + "°";
                    SouthWest_WestTextBox.Text = Math.Round(MaskResults.SouthWest_West, 2).ToString() + "°";

                    DirectionLegendPanel.Visible = true;
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
            if (MaskCalculatorInstance.Initialized)
            {
                MaskCalculatorInstance.DrawBuildings(PolygonsOverlay, true);
                Map.Refresh();
                DirectionLegendPanel.Visible = true;
                BuildingDataLegendPanel.Visible = false;
            }
        }

        private void BuildingDataRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DirectionRadioButton.Checked = !BuildingDataRadioButton.Checked;
            if (MaskCalculatorInstance.Initialized)
            {
                MaskCalculatorInstance.DrawBuildings(PolygonsOverlay, false);
                Map.Refresh();
                DirectionLegendPanel.Visible = false;
                BuildingDataLegendPanel.Visible = true;
            }
        }
        private void DirectionLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DirectionLinesCheckBox.Checked)
            {
                LinesOverlay.IsVisibile = true;
                SemicircleOverlay.IsVisibile = true;
            } else
            {
                LinesOverlay.IsVisibile = false;
                SemicircleOverlay.IsVisibile = false;
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
