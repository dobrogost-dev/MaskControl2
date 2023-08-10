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
        public Building BaseBuilding {  get; private set; }
        private List<Building> Buildings { get; set; }
        private List<Node> Nodes { get; set; }

        public bool Initialized = false;
        public void LoadData(OSMdata Data)
        {
            Buildings = new List<Building>();
            Nodes = new List<Node>();

            if (Data.elements.Length == 0)
            {
                return;
            }

            LoadElements(Data);
            InitializeBuildings(BaseBuilding.CenterPoint);
            RemoveBaseBuilding();
            RemoveNorthernBuildings();

            Initialized = true;
        }
        private void RemoveBaseBuilding()
        {
            Buildings.RemoveAll(b => b.id == BaseBuilding.id);
        }
        public void LoadBaseBuilding(OSMdata Data, PointLatLng LoadedBasePoint)
        {
            Buildings = new List<Building>();
            Nodes = new List<Node>();
            BaseBuilding = null;

            if (Data.elements.Length == 0)
            {
                return;
            }
            LoadElements(Data);
            FindBaseBuilding(LoadedBasePoint);
        }

        private void LoadElements(OSMdata Data)
        {
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
            //Console.WriteLine("Calculating azimuth for: " + buildingCenter);
            // Console.WriteLine("Azimuth: " + azimuth);
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
        private void InitializeBuildings(PointLatLng BaseDirectionPoint)
        {
            foreach (Building building in Buildings)
            {
                //Not used
                //AssignNodes(building);
                CalculateSideCenterPoints(building);
                AssignDirection(building, BaseDirectionPoint);
            }
        }
        private void AssignNodes(Building building)
        {
            building.Nodes = new List<Node>();
            foreach(long node in building.NodesId)
            {
                Node NodeInstance = GetNodeById(node);
                building.Nodes.Add(NodeInstance);
            }
        }
        private void CalculateSideCenterPoints(Building building)
        {
            building.SideCenterPoints = new List<PointLatLng>();
            for (int i = 0; i < building.NodesId.Length - 1; i++)
            {
                //Node CurrentNode = building.Nodes.Select(e => e).Where(e => e.id == building.NodesId[i]).FirstOrDefault();
                Node CurrentNode = GetNodeById(building.NodesId[i]);
                Node NextNode = GetNodeById(building.NodesId[i + 1]);

                double NewLat = (CurrentNode.lat + NextNode.lat) / 2;
                double NewLng = (CurrentNode.lon + NextNode.lon) / 2;

                PointLatLng SideCenterPoint = new PointLatLng(NewLat, NewLng);
                building.SideCenterPoints.Add(SideCenterPoint);
                //Console.WriteLine("     Side point: " + SidePoint);
            }
        }
        private Node GetNodeById(long id)
        {
            return Nodes
                .Select(e => e)
                .Where(e => e.id == id)
                .FirstOrDefault();
        }
        private void FindBaseBuilding(PointLatLng BasePoint)
        {
            double HighestDistanceToBasePoint = double.MaxValue;
            foreach (Building building in Buildings)
            {
                building.CenterPoint = GetCenterPosition(building);
                double CurrentDistanceToBasePoint = GetDistance(building.CenterPoint, BasePoint);
                if (CurrentDistanceToBasePoint < HighestDistanceToBasePoint)
                {
                    HighestDistanceToBasePoint = CurrentDistanceToBasePoint;
                    BaseBuilding = building;
                    CalculateSideCenterPoints(BaseBuilding);
                }
            }
        }
        private void RemoveNorthernBuildings()
        {
            // We are not removing partially included building
            double FarthestNorth = GetCenterPosition(BaseBuilding).Lat;
            List<Building> NorthernBuildings = new List<Building>();
            foreach (Building building in Buildings)
            {
                double FarthestSouth = GetPointFarthestSouth(building);
                if (FarthestNorth < FarthestSouth)
                {
                    NorthernBuildings.Add(building);
                }
            }
            Buildings.RemoveAll(building => NorthernBuildings.Contains(building));
        }

        public void ShowBuildingsLogs()
        {
            if (Buildings.Count == 0 || Nodes.Count == 0)
            {
                return;
            }
            Console.WriteLine("/////////////////////////////////////////////////////////////");
            Console.WriteLine("Default building id: " + BaseBuilding.id);
            foreach (long node in BaseBuilding.NodesId)
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
                foreach (long node in building.NodesId)
                {
                    Console.WriteLine("     Node id: " + node);
                    Console.WriteLine("         Node latitude: " + Nodes.FirstOrDefault(e => e.id == node).lat);
                    Console.WriteLine("         Node longitude: " + Nodes.FirstOrDefault(e => e.id == node).lon);
                }
            }
        }

        public void DrawBuildings(GMapOverlay polygonsOverlay, bool DirectionBuilding)
        {
            if (Buildings.Count == 0 || Nodes.Count == 0)
            {
                return;
            }
            polygonsOverlay.Clear();
            List<PointLatLng> BaseBuildingPolygons = GetPolygons(BaseBuilding);
            DrawEntity(polygonsOverlay, BaseBuildingPolygons, Color.Blue);
            foreach (Building building in Buildings)
            {
                List<PointLatLng> BuildingPolygons = GetPolygons(building);
                Color color = Color.Gray;
                if (DirectionBuilding)
                {
                    switch (building.direction)
                    {
                        case Building.Direction.Unspecified: color = Color.Orange; break;
                        case Building.Direction.East_SouthEast: color = Color.LimeGreen; break;
                        case Building.Direction.SouthEast_South: color = Color.DeepSkyBlue; break;
                        case Building.Direction.South_SouthWest: color = Color.Magenta; break;
                        case Building.Direction.SouthWest_West: color = Color.Red; break;
                        default: color = Color.Gray; break;
                    }
                }
                else
                {
                    if (building.tags.height != null)
                    {
                        color = Color.Green;
                    }
                    else if (building.tags.BuildingLevels != null)
                    {
                        color = Color.Orange;
                    }
                    else
                    {
                        color = Color.Red;
                    }
                }
                DrawEntity(polygonsOverlay, BuildingPolygons, color);
            }
        }

        private void DrawEntity(GMapOverlay polygonsOverlay, List<PointLatLng> polygons, System.Drawing.Color color)
        {
            GMapPolygon buildingPolygon = new GMapPolygon(polygons, "building");
            buildingPolygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, color));
            buildingPolygon.Stroke = new Pen(color, 1);
            polygonsOverlay.Polygons.Add(buildingPolygon);
        }
        public List<PointLatLng> GetPolygons(Building building)
        {
            List<PointLatLng> result = new List<PointLatLng>();
            foreach(long node in building.NodesId)
            {
                Node newNode = GetNodeById(node);
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
            int length = building.NodesId.Length - 1;
            for (int i = 0; i < length; i++)
            {
                Node selectedNode = Nodes
                    .Select(e => e)
                    .Where(e => e.id == building.NodesId[i])
                    .FirstOrDefault();
                lat += selectedNode.lat;
                lng += selectedNode.lon;
            }
            return new PointLatLng(lat / length, lng / length);
        }
        public double GetPointFarthestNorth(Building building)
        {
            double result = -10000;
            foreach(long node in building.NodesId)
            {
                Node newNode = GetNodeById(node);
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
            foreach (long node in building.NodesId)
            {
                Node newNode = GetNodeById(node);
                if (newNode.lat < result)
                {
                    result = newNode.lat;
                }
            }
            return result;
        }
        public double GetMaskValue(PointLatLng BasePoint, PointLatLng TargetPoint, double height)
        {
            double distance = CalculateDistanceInMeters(BasePoint.Lat, BasePoint.Lng, TargetPoint.Lat, TargetPoint.Lng);
            //Console.WriteLine("         Distance: " + distance);
            double diagonal = Math.Sqrt((distance * distance) + (height * height));
            //Console.WriteLine("         Diagonal: " + diagonal);
            double mask = CalculateAngleBetweenSides(distance, diagonal);
            //Console.WriteLine("         Mask: " + mask);
            return mask;
        }
        public static double CalculateDistanceInMeters(double lat1, double lon1, double lat2, double lon2)
        {
            const double radiusEarth = 6371.0; 

            double dLat = (lat2 - lat1) * (Math.PI / 180.0);
            double dLon = (lon2 - lon1) * (Math.PI / 180.0);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * (Math.PI / 180.0)) * Math.Cos(lat2 * (Math.PI / 180.0)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = radiusEarth * c;

            return distance * 1000;
        }
        public Node GetNodeForId(long id)
        {
            return Nodes
                .Select(e => e)
                .Where(e => e.id == id)
                .FirstOrDefault();
        }
        public static double CalculateAngleBetweenSides(double baseLength, double hypotenuse)
        {
            double sinAlpha = baseLength / hypotenuse;
            //Console.WriteLine("Sinus alfa: " +  sinAlpha);
            double angleInRadians = Math.Acos(sinAlpha); // Używamy funkcji Asin do obliczenia kąta w radianach
            //Console.WriteLine("Kat w radianach: " + angleInRadians);
            double angleInDegrees = angleInRadians * (180.0 / Math.PI); // Konwersja radianów na stopnie
            //Console.WriteLine("Kat w stopniach: " + angleInDegrees);


            return angleInDegrees;
        }
        public double ProcessMask(Building building, double DefaultBuildingFloorHeight, double DefaultBuildingHeight)
        {
            double mask = 0;
            double distance = 1000000;
            PointLatLng BasePoint = new PointLatLng();
            PointLatLng TargetPoint = new PointLatLng();
            foreach (PointLatLng SidePoint in BaseBuilding.SideCenterPoints)
            {
                foreach(long node in building.NodesId)
                {
                    Node NewNode = GetNodeForId(node);
                    PointLatLng NodePosition = new PointLatLng(NewNode.lat, NewNode.lon);
                    double newDistance = GetDistance(SidePoint, new PointLatLng(NewNode.lat, NewNode.lon));
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        BasePoint = SidePoint;
                        TargetPoint = NodePosition;
                    }
                }
            }
            //Console.WriteLine("Building id: " + building.id);
            //Console.WriteLine("Base point: " + BasePoint);
            //Console.WriteLine("Target point: " + TargetPoint);

            if (building.tags.height != null)
            {
                //Console.WriteLine("     Using height");
                mask = GetMaskValue(BasePoint,
                    TargetPoint, Double.Parse(building.tags.height));
            }
            else if (building.tags.BuildingLevels != null)
            {
                //Console.WriteLine("     Using building levels");
                mask = GetMaskValue(BasePoint,
                    TargetPoint, Double.Parse(building.tags.BuildingLevels) * DefaultBuildingFloorHeight);
            }
            else
            {
                //Console.WriteLine("     Using default value");
                mask = GetMaskValue(BasePoint,
                    TargetPoint, DefaultBuildingHeight);
            }
            return mask;
        }
        public MaskResult CalculateMasks(double DefaultBuildingFloorHeight, double DefaultBuildingHeight)
        {
            MaskResult result = new MaskResult();
            if (Buildings.Count == 0 || Nodes.Count == 0)
            {
                return result;
            }
            foreach (Building building in Buildings)
            {
                //Console.WriteLine("Calculating mask");
                //Console.WriteLine("Building id " + building.id);
                //Console.WriteLine("Building direction " + building.direction);
                //Console.WriteLine("Coordinates " + GetCenterPosition(building));
                double mask = 0;
                switch (building.direction)
                {
                    case Building.Direction.East_SouthEast:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultBuildingHeight);
                        if (mask > result.East_SouthEast)
                        {
                            result.East_SouthEast = mask;
                        }
                        break;
                    case Building.Direction.SouthEast_South:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultBuildingHeight);
                        if (mask > result.SouthEast_South)
                        {
                            result.SouthEast_South = mask;
                        }
                        break;
                    case Building.Direction.South_SouthWest:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultBuildingHeight);
                        if (mask > result.South_SouthWest)
                        {
                            result.South_SouthWest = mask;
                        }
                        break;
                    case Building.Direction.SouthWest_West:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultBuildingHeight);
                        if (mask > result.SouthWest_West)
                        {
                            result.SouthWest_West = mask;
                        }
                        break;
                }
            }
            return result;
        }
        private static double MetersToDegreesLatitude(double meters)
        {
            double earthRadius = 6378137; // Promień Ziemi w metrach

            // Wzór: stopnie = (metry / (promień Ziemi * π)) * 180
            return (meters / (earthRadius * Math.PI)) * 180;
        }
        public static double MetersToDegreesLongitude(double meters, double latitude)
        {
            // Earth's radius in meters
            double earthRadius = 6371000;

            // Calculate the circumference of Earth at given latitude
            double circumferenceAtLatitude = 2 * Math.PI * earthRadius * Math.Cos(latitude * Math.PI / 180);

            // Calculate the longitude degrees for the given distance
            double longitudeDegrees = meters * 360 / circumferenceAtLatitude;

            return longitudeDegrees;
        }

        public void DrawLines(GMapOverlay SemicircleOverlay, GMapOverlay LinesOverlay, double radius)
        {
            if (BaseBuilding == null)
            {
                return;
            }
            //Console.WriteLine("Drawing lines: ");
            PointLatLng basePoint = GetCenterPosition(BaseBuilding);
            SemicircleOverlay.Clear();
            LinesOverlay.Clear();

            List<PointLatLng> SemicirclePolygons = new List<PointLatLng>();

            bool FirstAzmiuth = true;
            bool SecondAzimuth = true;
            bool ThirdAzmiuth = true;

            for (double a = 100; a >= -100; a -= 1)
            {
                if (a == 0)
                {
                    continue;
                }
                double RadiusMetersLongitude = MetersToDegreesLongitude(radius, BaseBuilding.CenterPoint.Lat);
                double AddedLongitude = RadiusMetersLongitude * (a / 100);

                double RadiusMetersLatitude = MetersToDegreesLatitude(radius);

                double RadiusCorrection = ((RadiusMetersLatitude / RadiusMetersLongitude));
                //The correction is supposed to maximalize the accuracy of the calculations
                //By comparing the BasePoint and Relative Correction Point( which is Poiters, France)
                //if BasePoint is above it the semicircle height gets smaller, if its below it gets bigger
                double LongitudeCorrection = (46.590484 / BaseBuilding.CenterPoint.Lat) * 0.67;
                LongitudeCorrection = Math.Min(LongitudeCorrection, 1.0);
                LongitudeCorrection = Math.Max(LongitudeCorrection, 0.5);

                double LatitudeSquared = (RadiusMetersLongitude * RadiusMetersLongitude) - (AddedLongitude * AddedLongitude);
                decimal AddedLatitudeSquared = new decimal(LatitudeSquared * RadiusCorrection * LongitudeCorrection);
                double AddedLatitude = decimal.ToDouble(SquareRoot(AddedLatitudeSquared));

                //Console.WriteLine("     Drawing line: " + a);
                //Console.WriteLine("         RadiusMetersLatitude: " + (RadiusMetersLatitude));
                //Console.WriteLine("         RadiusMetersLongitude: " + (RadiusMetersLongitude));
                //
                //Console.WriteLine("         Added Latitude Squared: " + (AddedLatitudeSquared));
                //
                //Console.WriteLine("         Added longitude: " + (AddedLongitude));
                //Console.WriteLine("         Added latitude: " + (AddedLatitude));
                PointLatLng TargetPoint = new PointLatLng(basePoint.Lat - AddedLatitude, basePoint.Lng + AddedLongitude);
                SemicirclePolygons.Add(TargetPoint);
                double azimuth = CalculateAzimuth(BaseBuilding.CenterPoint, TargetPoint);
                if (azimuth > 135 && FirstAzmiuth)
                {
                    DrawLine(LinesOverlay, basePoint, TargetPoint, Color.Orange, 1);
                    FirstAzmiuth = false;
                } 
                if (azimuth > 180 && SecondAzimuth)
                {
                    DrawLine(LinesOverlay, basePoint, TargetPoint, Color.Orange, 1);
                    SecondAzimuth = false;
                }
                if (azimuth > 225 && ThirdAzmiuth)
                {
                    DrawLine(LinesOverlay, basePoint, TargetPoint, Color.Orange, 1);
                    ThirdAzmiuth = false;
                }
            }
            DrawEntity(SemicircleOverlay, SemicirclePolygons, Color.DarkOrange);

        }
        private static decimal SquareRoot(decimal square)
        {
            if (square <= 0) return 0;

            decimal root = square / 3;
            int i;
            for (i = 0; i < 32; i++)
                root = (root + square / root) / 2;
            return root;
        }
        public void DrawLine(GMapOverlay linesOverlay, PointLatLng startPoint, PointLatLng endPoint, Color color, int thickness)
        {
            List<PointLatLng> points = new List<PointLatLng>
            {
                startPoint,
                endPoint
            };

            GMapRoute lineRoute = new GMapRoute(points, "line");
            lineRoute.Stroke = new Pen(color, thickness);
            linesOverlay.Routes.Add(lineRoute);
        }
    }
}
