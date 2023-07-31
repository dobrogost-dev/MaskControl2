﻿using GMap.NET;
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
        public GMarkerGoogle currentMarker = new GMarkerGoogle(new PointLatLng(0,0), GMarkerGoogleType.red_dot);
        public MaskCalculator maskCalculator = new MaskCalculator();
        public MainForm()
        {
            InitializeComponent();
            Map.MapProvider = GMapProviders.OpenStreetMap;
            double latitude = 52.2188;
            double longitude = 21.0026;
            Map.Position = new PointLatLng(latitude, longitude);
            Map.MouseWheelZoomEnabled = true;
            Map.ShowCenter = false;
            Map.MaxZoom = 20;
            Map.MinZoom = 3;
            Map.Zoom = Map.MinZoom;
            markersOverlay = new GMapOverlay("markers");
            Map.Overlays.Add(markersOverlay);
            Map.MouseClick += GMapControl_MouseClick;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Map.SetPositionByKeywords(AddressTextBox.Text);
            Map.Zoom = 18;
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
            }
        }

        private async void MaskButton_Click(object sender, EventArgs e)
        {
            double radius = Double.Parse(RadiusTextBox.Text);
            string latitude = currentMarker.Position.Lat.ToString(CultureInfo.InvariantCulture);
            string longitude = currentMarker.Position.Lng.ToString(CultureInfo.InvariantCulture);

            string apiUrl = $"https://overpass-api.de/api/interpreter?data=[out:json];way[\"building\"](around:{radius},{latitude},{longitude});(._;>;);out;";
            Console.WriteLine(apiUrl);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Wysyłamy żądanie GET do API OpenStreetMap
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    Console.WriteLine($"Response: {response}");
                    Console.WriteLine($"Response: {response.Content.ReadAsStringAsync()}");
                    if (response.IsSuccessStatusCode)
                    {
                        // Odczytujemy odpowiedź jako ciąg JSON
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(jsonResponse);
                        OSMdata apiResponse = JsonConvert.DeserializeObject<OSMdata>(jsonResponse);
                        maskCalculator.LoadData(apiResponse);
                        maskCalculator.ShowBuildings();
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
        // Klasa do deserializacji odpowiedzi JSON z API OpenStreetMap
    }
}
