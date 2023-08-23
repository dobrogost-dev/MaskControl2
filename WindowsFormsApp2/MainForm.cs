using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        public static int BaseZoom = 1;
        string DefaultRadius = "45";
        double DefaultFloorHeight = 2.5;
        public string PreviousAddress;

        public GMapOverlay MarkersOverlay;
        public GMapOverlay PolygonsOverlay;
        public GMapOverlay SemicircleOverlay;
        public GMapOverlay LinesOverlay;

        public GMarkerGoogle CurrentMarker;
        public MaskCalculator MaskCalculatorInstance;
        public MapPainter MapPainterInstance;
        public MainForm()
        {
            CurrentMarker = new GMarkerGoogle(new PointLatLng(0, 0), GMarkerGoogleType.red_dot);
            MaskCalculatorInstance = new MaskCalculator();
            MapPainterInstance = new MapPainter(MaskCalculatorInstance);

            InitializeComponent();
            SetMapConfiguration();
            SetInitialValues();

            FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void SetInitialValues()
        {

            RadiusTextBox.Text = DefaultRadius;

            LatitudeTextBox.ReadOnly = true;
            LongitudeTextBox.ReadOnly = true;
            MaskLeftResult.ReadOnly = true;
            MaskLeftMiddleResult.ReadOnly = true;
            MaskRightMiddleResult.ReadOnly = true;
            MaskRightResult.ReadOnly = true;

            MaskButton.Enabled = false;
            BuildingDataLegendPanel.Visible = false;
            SectorsLegendPanel.Visible = false;
            LinesOverlay.IsVisibile = false;
            SemicircleOverlay.IsVisibile = false;
        }

        private void SetMapConfiguration()
        {
            double DefaultLatitude = 52.2188;
            double DefaultLongitude = 21.0026;

            GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
            GMapProvider.WebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

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

        private void SearchButton_Click(object sender, EventArgs e)
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
                MessageBox.Show("Adresse introuvable!",
                    "Adresse introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                PreviousAddress = Address;
                Map.Zoom = 18;
            }

            /*
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
            */
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
                MessageBox.Show("Veuillez indiquer la rayon afin de calculer les angles des masques!",
                    "Radius required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MarkersOverlay.Markers.Count == 0)
            {
                MessageBox.Show("Marker is required in order to calculate mask!",
                    "Marker required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await ProcessApiCall();
        }

        private async Task ProcessApiCall()
        {
            using (HttpClient Client = new HttpClient())
            {
                try
                {
                    double InitialRadius = 50.0;
                    // Zmiana double na stringa oddzielonego kropką zamiast przecinka
                    string InitialMarkerLatitude = CurrentMarker.Position.Lat.ToString(CultureInfo.InvariantCulture);
                    string InitialMarkerLongitude = CurrentMarker.Position.Lng.ToString(CultureInfo.InvariantCulture);

                    string BaseBuildingApiUrl = $"https://overpass-api.de/api/interpreter?data=[out:json];way[\"building\"](around:{InitialRadius},{InitialMarkerLatitude},{InitialMarkerLongitude});(._;>;);out;";
                    OSMdata BaseBuildingApiResponse = await GetOSMApiResponse(BaseBuildingApiUrl, Client);

                    MaskCalculatorInstance.LoadBaseBuilding(BaseBuildingApiResponse, CurrentMarker.Position);

                    if (MaskCalculatorInstance.BaseBuilding == null)
                    {
                        MessageBox.Show("Immeuble de base introuvable!",
                        "Immeuble de base introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CurrentMarker.Position = MaskCalculatorInstance.GetClosestFacade(CurrentMarker.Position);

                    double Radius = Double.Parse(RadiusTextBox.Text);
                    string BaseBuildingLatitude = MaskCalculatorInstance.AnalyzedFacade.PointCenter.Lat.ToString(CultureInfo.InvariantCulture);
                    string BaseBuildingLongitude = MaskCalculatorInstance.AnalyzedFacade.PointCenter.Lng.ToString(CultureInfo.InvariantCulture);

                    string ApiUrl = $"https://overpass-api.de/api/interpreter?data=[out:json];way[\"building\"](around:{Radius},{BaseBuildingLatitude},{BaseBuildingLongitude});(._;>;);out;";
                    OSMdata apiResponse = await GetOSMApiResponse(ApiUrl, Client);

                    MaskCalculatorInstance.LoadData(apiResponse);


                    MaskResult MaskResults = MaskCalculatorInstance.CalculateMasks(DefaultFloorHeight);

                    MaskLeftResult.Text = Math.Round(MaskResults.East_SouthEast, 2).ToString() + "°";
                    MaskLeftMiddleResult.Text = Math.Round(MaskResults.SouthEast_South, 2).ToString() + "°";
                    MaskRightMiddleResult.Text = Math.Round(MaskResults.South_SouthWest, 2).ToString() + "°";
                    MaskRightResult.Text = Math.Round(MaskResults.SouthWest_West, 2).ToString() + "°";
                    FacadeDirectionLabel.Text = MaskCalculatorInstance.GetDirectionAsText();
                    SectorsLegendPanel.Visible = true;

                    MapPainterInstance.DrawBuildings(PolygonsOverlay, DirectionRadioButton.Checked);
                    MapPainterInstance.DrawSectors(SemicircleOverlay, LinesOverlay, Radius);
                    Map.Refresh();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                }
            }
        }
        private async Task<OSMdata> GetOSMApiResponse(string url, HttpClient Client)
        {
            HttpResponseMessage BaseBuildingResponse = await Client.GetAsync(url);

            if (!BaseBuildingResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"Błąd HTTP: {BaseBuildingResponse.StatusCode}");
                MessageBox.Show("HTTP Error",
                "HTTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string BaseBuildingJsonResponse = await BaseBuildingResponse.Content.ReadAsStringAsync();
            OSMdata BaseBuildingApiResponse = JsonConvert.DeserializeObject<OSMdata>(BaseBuildingJsonResponse);

            return BaseBuildingApiResponse;
        }

        private void DirectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BuildingDataRadioButton.Checked = !DirectionRadioButton.Checked;
            if (MaskCalculatorInstance.Initialized)
            {
                MapPainterInstance.DrawBuildings(PolygonsOverlay, true);
                Map.Refresh();
                SectorsLegendPanel.Visible = true;
                BuildingDataLegendPanel.Visible = false;
            }
        }

        private void BuildingDataRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            DirectionRadioButton.Checked = !BuildingDataRadioButton.Checked;
            if (MaskCalculatorInstance.Initialized)
            {
                MapPainterInstance.DrawBuildings(PolygonsOverlay, false);
                Map.Refresh();
                SectorsLegendPanel.Visible = false;
                BuildingDataLegendPanel.Visible = true;
            }
        }
        private void DirectionLinesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SectorsCheckBox.Checked)
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

        private void Map_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void MaskLeftResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
