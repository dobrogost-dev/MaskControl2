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
        private List<Building> Buildings { get; set; }
        private List<Node> Nodes { get; set; }
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
                    AssignDirection(building, BasePoint);
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
            double FarthestNorth = GetPointFarthestNorth(BaseBuilding);
            List<Building> NorthBuildings = new List<Building>();
            foreach (Building building in Buildings)
            {
                double FarthestSouth = GetPointFarthestSouth(building);
                if (FarthestNorth < FarthestSouth)
                {
                    NorthBuildings.Add(building);
                }
            }
            Buildings.RemoveAll(building => NorthBuildings.Contains(building));
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
                Console.WriteLine("     Building direction: " + building.direction);
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
                Color color = Color.Gray;
                switch (building.direction)
                {
                    case Building.Direction.Unspecified: color = Color.Orange; break;
                    case Building.Direction.East_SouthEast: color = Color.Red; break;
                    case Building.Direction.SouthEast_South: color = Color.Green; break;
                    case Building.Direction.South_SouthWest: color = Color.Magenta; break;
                    case Building.Direction.SouthWest_West: color = Color.Brown; break;
                    default: color = Color.Gray; break;
                }
                DrawBuilding(polygonsOverlay, BuildingPolygons, color);
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
        public static double CalculateAzimuth(PointLatLng point1, PointLatLng point2)
        {
            const double radianToDegree = 180.0 / Math.PI;
            const double degreeToRadian = Math.PI / 180.0;

            double dLon = (point2.Lng - point1.Lng) * degreeToRadian;
            point1.Lat *= degreeToRadian;
            point2.Lat *= degreeToRadian;

            double y = Math.Sin(dLon) * Math.Cos(point2.Lat);
            double x = Math.Cos(point1.Lat) * Math.Sin(point2.Lat) - Math.Sin(point1.Lat) * Math.Cos(point2.Lat) * Math.Cos(dLon);
            double azimuth = Math.Atan2(y, x) * radianToDegree;

            return (azimuth + 360) % 360; 
        }
        public void AssignDirection(Building building, PointLatLng point)
        {
            PointLatLng buildingCenter = GetCenterPosition(building);
            double azimuth = CalculateAzimuth(point, buildingCenter);
            if (azimuth < 135)
            {
                building.direction = Building.Direction.East_SouthEast;
            }
            else if (azimuth >= 135 && azimuth < 180)
            {
                building.direction = Building.Direction.SouthEast_South;
            }
            else if (azimuth >= 180 && azimuth < 225)
            {
                building.direction = Building.Direction.South_SouthWest;
            }
            else if (azimuth >= 225)
            {
                building.direction = Building.Direction.SouthWest_West;
            }
            Console.WriteLine("Calculating azimuth for: " + buildingCenter);
            Console.WriteLine("Azimuth: " + azimuth);
        }
        public double GetPointFarthestNorth(Building building)
        {
            double result = -10000;
            foreach(long node in building.nodes)
            {
                Node newNode = Nodes
                    .Select(e => e)
                    .Where(e => e.id == node)
                    .FirstOrDefault();
                if (newNode.lat > result)
                {
                    result = newNode.lat;
                }
            }
            return result;
        }
        public double GetPointFarthestSouth(Building building)
        {
            double result = 10000;
            foreach (long node in building.nodes)
            {
                Node newNode = Nodes
                    .Select(e => e)
                    .Where(e => e.id == node)
                    .FirstOrDefault();
                if (newNode.lat < result)
                {
                    result = newNode.lat;
                }
            }
            return result;
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
