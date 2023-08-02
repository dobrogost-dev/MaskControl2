using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public class MaskCalculator
    {
        private Building BaseBuilding;
        private ICollection<Building> Buildings { get; set; }
        private ICollection<Node> Nodes { get; set; }
        public void LoadData(OSMdata Data, PointLatLng BasePoint) 
        {
            Console.WriteLine(BasePoint);
            Buildings = new List<Building>();
            Nodes = new List<Node>();
            foreach (Element element in Data.elements)
            {
                if (element.type == "node")
                {
                    Node node = element as Node;
                    Nodes.Add(node);
                }
                else if (element.type == "way")
                {
                    Building building = element as Building;
                    Buildings.Add(building);
                }
            }
            double distance = 100000000000;
            foreach(Building building in Buildings)
            {
                PointLatLng buildingCenter = GetCenterPosition(building);
                double buildingDistance = GetDistance(buildingCenter, BasePoint);
                Console.WriteLine("Building id: " + building.id);
                Console.WriteLine("     Center: " + buildingCenter);
                Console.WriteLine("     Distance: " + buildingDistance);
                if (buildingDistance < distance)
                {
                    distance = buildingDistance;
                    Console.WriteLine("Assigning building id " + building.id + " as a base building");
                    BaseBuilding = building;
                }
            }
            Buildings.Remove(BaseBuilding);
        }
        public void ShowBuildings(GMapOverlay polygonsOverlay)
        {
            Console.WriteLine("/////////////////////////////////////////////////////////////");
            Console.WriteLine("Default building id: " + BaseBuilding.id);
            foreach (long node in BaseBuilding.nodes)
            {
                Console.WriteLine("     Node id: " + node);
                Console.WriteLine("         Node latitude: " + Nodes.FirstOrDefault(e => e.id == node).lat);
                Console.WriteLine("         Node longitude: " + Nodes.FirstOrDefault(e => e.id == node).lon);
            }
            foreach (Building building in Buildings)
            {
                Console.WriteLine("Building id: " + building.id);
                Console.WriteLine("     Building height: " + building.tags.height);
                Console.WriteLine("     Building levels: " + building.tags.BuildingLevels);
                foreach (long node in building.nodes)
                {
                    Console.WriteLine("     Node id: " + node);
                    Console.WriteLine("         Node latitude: " + Nodes.FirstOrDefault(e => e.id == node).lat);
                    Console.WriteLine("         Node longitude: " + Nodes.FirstOrDefault(e => e.id == node).lon);
                }
            }
            polygonsOverlay.Clear();
            List<PointLatLng> BaseBuildingPolygons = GetPolygons(BaseBuilding);
            DrawBuilding(polygonsOverlay, BaseBuildingPolygons, Color.Blue);
            foreach (Building building in Buildings)
            {
                List<PointLatLng> BuildingPolygons = GetPolygons(building);
                DrawBuilding(polygonsOverlay, BuildingPolygons, Color.Orange);
            }
        }
        public void DrawBuilding(GMapOverlay polygonsOverlay, List<PointLatLng> polygons, System.Drawing.Color color)
        {
            GMapPolygon buildingPolygon = new GMapPolygon(polygons, "building");
            buildingPolygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, color));
            buildingPolygon.Stroke = new Pen(color, 1);
            polygonsOverlay.Polygons.Add(buildingPolygon);
        }
        public List<PointLatLng> GetPolygons(Building building)
        {
            List<PointLatLng> result = new List<PointLatLng>();
            foreach(long node in building.nodes)
            {
                Node newNode = Nodes
                    .Select(e => e)
                    .Where(e => e.id == node)
                    .FirstOrDefault();
                result.Add(new PointLatLng(newNode.lat, newNode.lon));
            }
            return result;
        }
        public double GetDistance(PointLatLng p1, PointLatLng p2)
        {
            GMapRoute route = new GMapRoute("getDistance");
            route.Points.Add(p1);
            route.Points.Add(p2);
            double distance = route.Distance;
            route.Clear();
            route = null;

            return distance;
        }
        public PointLatLng GetCenterPosition(Building building)
        {
            double lat = 0;
            double lng = 0;
            //We're checking 1 less because last one is a repetition
            int length = building.nodes.Length - 1;
            for (int i = 0; i < length; i++)
            {
                Node selectedNode = Nodes
                    .Select(e => e)
                    .Where(e => e.id == building.nodes[i])
                    .FirstOrDefault();
                lat += selectedNode.lat;
                lng += selectedNode.lon;
            }
            return new PointLatLng(lat / length, lng / length);
        }

        public MaskResult CalculateMask()
        {
            return null;
        }

    }
    public class MaskResult
    {
        private long East_SouthEast { get; set; }
        private long SouthEast_South { get; set; }
        private long South_SouthWest { get; set; }
        private long SouthWest_West { get; set; }
    }
}
