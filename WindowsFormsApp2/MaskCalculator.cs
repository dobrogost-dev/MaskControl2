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
using static WindowsFormsApp2.MaskCalculatorUtilities;

namespace WindowsFormsApp2
{
    public class MaskCalculator
    {
        public Building BaseBuilding {  get; private set; }
        public Facade AnalyzedFacade { get; private set; }
        public List<Building> Buildings { get; private set; }
        public List<Node> Nodes { get; private set; }

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
        public void AssignDirection(Building TargetBuilding, Facade BaseBuildingAnalyzedFacade)
        {
            PointLatLng TargetBuildingCenter = GetCenterPosition(TargetBuilding);
            double BaseAzimuth = BaseBuildingAnalyzedFacade.Azimuth;

            double TargetAzimuth = CalculateAzimuth(BaseBuildingAnalyzedFacade.PointCenter, TargetBuildingCenter);

            // Przekształć azymuty na przedział [0, 360)
            BaseAzimuth = (BaseAzimuth + 360) % 360;
            TargetAzimuth = (TargetAzimuth + 360) % 360;

            double LeftAzimuth = (BaseAzimuth - 90 + 360) % 360;
            double LeftMiddleAzimuth = (BaseAzimuth - 45 + 360) % 360;
            double RightMiddleAzimuth = (BaseAzimuth + 45) % 360;
            double RightAzimuth = (BaseAzimuth + 90) % 360;

            if (IsBetween(TargetAzimuth, LeftAzimuth, LeftMiddleAzimuth))
            {
                TargetBuilding.direction = Building.Direction.East_SouthEast;
            }
            else if (IsBetween(TargetAzimuth, LeftMiddleAzimuth, BaseAzimuth))
            {
                TargetBuilding.direction = Building.Direction.SouthEast_South;
            }
            else if (IsBetween(TargetAzimuth, BaseAzimuth, RightMiddleAzimuth))
            {
                TargetBuilding.direction = Building.Direction.South_SouthWest;
            }
            else if (IsBetween(TargetAzimuth, RightMiddleAzimuth, RightAzimuth))
            {
                TargetBuilding.direction = Building.Direction.SouthWest_West;
            } else
            {
                foreach(Facade facade in TargetBuilding.Facades)
                {
                    double TargetAzimuthExtended = CalculateAzimuth(BaseBuildingAnalyzedFacade.PointCenter, facade.PointCenter);
                    if (IsBetween(TargetAzimuthExtended, LeftAzimuth, LeftMiddleAzimuth))
                    {
                        TargetBuilding.direction = Building.Direction.East_SouthEast;
                    } else if (IsBetween(TargetAzimuthExtended, RightMiddleAzimuth, RightAzimuth))
                    {
                        TargetBuilding.direction = Building.Direction.SouthWest_West;
                    }
                }
            }
        }

        private void InitializeBuildings(PointLatLng BaseDirectionPoint)
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine("Base building id: " + BaseBuilding.id);
            Console.WriteLine("Analyzed facade:");
            Console.WriteLine("   Azimuth: " + AnalyzedFacade.Azimuth);
            Console.WriteLine("   Center Azimuth: " + CalculateAzimuth(AnalyzedFacade.PointCenter, BaseBuilding.CenterPoint));
            foreach (Building building in Buildings)
            {
                CalculateFacades(building);
                AssignDirection(building, AnalyzedFacade);
            }
        }
        private void CalculateFacades(Building building)
        {
            building.Facades = new List<Facade>();
            for (int i = 0; i < building.NodesId.Length - 1; i++)
            {
                Node CurrentNode = GetNodeById(building.NodesId[i]);
                Node NextNode = GetNodeById(building.NodesId[i + 1]);

                double NewLat = (CurrentNode.lat + NextNode.lat) / 2;
                double NewLng = (CurrentNode.lon + NextNode.lon) / 2;

                Facade Facade = new Facade();
                Facade.PointFrom = new PointLatLng(CurrentNode.lat, CurrentNode.lon);
                Facade.PointCenter = new PointLatLng(NewLat, NewLng);
                Facade.PointTo = new PointLatLng(NextNode.lat, NextNode.lon);

                Facade.Azimuth = CalculateAzimuth(Facade.PointFrom, Facade.PointTo) - 90;
                double CenterAzimuth = CalculateAzimuth(Facade.PointCenter, building.CenterPoint);
                if (Math.Abs(Facade.Azimuth - CenterAzimuth) < 90 || Math.Abs(Facade.Azimuth - CenterAzimuth) > 270)
                {
                    Facade.Azimuth += 180;
                }
                
                if (Facade.Azimuth < 0)
                {
                    Facade.Azimuth += 360;
                } else if (Facade.Azimuth > 360)
                {
                    Facade.Azimuth -= 360;
                }

                building.Facades.Add(Facade);
            }
        }
        public Node GetNodeById(long id)
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
                CalculateFacades(building);

                foreach (Facade facade in building.Facades) {
                    double CurrentDistanceToBasePoint = GetDistance(facade.PointCenter, BasePoint);
                    if (CurrentDistanceToBasePoint < HighestDistanceToBasePoint)
                    {
                        HighestDistanceToBasePoint = CurrentDistanceToBasePoint;
                        BaseBuilding = building;
                        AnalyzedFacade = facade;
                    }
                }
            }
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
            {                Node selectedNode = Nodes
                    .Select(e => e)
                    .Where(e => e.id == building.NodesId[i])
                    .FirstOrDefault();
                lat += selectedNode.lat;
                lng += selectedNode.lon;
            }
            return new PointLatLng(lat / length, lng / length);
        }
        public double GetMaskValue(PointLatLng BasePoint, PointLatLng TargetPoint, double height)
        {
            double distance = CalculateDistanceInMeters(BasePoint.Lat, BasePoint.Lng, TargetPoint.Lat, TargetPoint.Lng);
            double diagonal = Math.Sqrt((distance * distance) + (height * height));
            double mask = CalculateAngleBetweenSides(distance, diagonal);
            return mask;
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
            double angleInRadians = Math.Acos(sinAlpha); 
            double angleInDegrees = angleInRadians * (180.0 / Math.PI); 
            return angleInDegrees;
        }
        public double ProcessMask(Building building, double DefaultBuildingFloorHeight, double DefaultBuildingHeight)
        {
            double mask = 0;
            double distance = double.MaxValue;
            PointLatLng BasePoint = new PointLatLng();
            PointLatLng TargetPoint = new PointLatLng();
            foreach (Facade facade in BaseBuilding.Facades)
            {
                foreach(long node in building.NodesId)
                {
                    Node NewNode = GetNodeForId(node);
                    PointLatLng NodePosition = new PointLatLng(NewNode.lat, NewNode.lon);
                    double newDistance = GetDistance(facade.PointCenter, new PointLatLng(NewNode.lat, NewNode.lon));
                    if (newDistance < distance)
                    {
                        distance = newDistance;
                        BasePoint = facade.PointCenter;
                        TargetPoint = NodePosition;
                    }
                }
            }
            if (building.tags.height != null)
            {
                mask = GetMaskValue(BasePoint,
                    TargetPoint, double.Parse(building.tags.height));
            }
            else if (building.tags.BuildingLevels != null)
            {
                mask = GetMaskValue(BasePoint,
                    TargetPoint, double.Parse(building.tags.BuildingLevels) * DefaultBuildingFloorHeight);
            }
            else
            {
                mask = GetMaskValue(BasePoint,
                    TargetPoint, DefaultBuildingHeight);
            }
            return mask;
        }
        public MaskResult CalculateMasks(double DefaultBuildingFloorHeight, double DefaultLeftBuildingHeight,
            double DefaultLeftMiddleBuildingHeight, double DefaultRightMiddleBuildingHeight, double DefaultRightBuildingHeight)
        {
            MaskResult result = new MaskResult();
            if (Buildings.Count == 0 || Nodes.Count == 0)
            {
                return result;
            }
            foreach (Building building in Buildings)
            {
                double mask = 0;
                switch (building.direction)
                {
                    case Building.Direction.East_SouthEast:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultLeftBuildingHeight);
                        if (mask > result.East_SouthEast)
                        {
                            result.East_SouthEast = mask;
                        }
                        break;
                    case Building.Direction.SouthEast_South:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultLeftMiddleBuildingHeight);
                        if (mask > result.SouthEast_South)
                        {
                            result.SouthEast_South = mask;
                        }
                        break;
                    case Building.Direction.South_SouthWest:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultRightMiddleBuildingHeight);
                        if (mask > result.South_SouthWest)
                        {
                            result.South_SouthWest = mask;
                        }
                        break;
                    case Building.Direction.SouthWest_West:
                        mask = ProcessMask(building, DefaultBuildingFloorHeight, DefaultRightBuildingHeight);
                        if (mask > result.SouthWest_West)
                        {
                            result.SouthWest_West = mask;
                        }
                        break;
                }
            }
            return result;
        }
        public PointLatLng GetClosestFacade(PointLatLng Position)
        {
            double MaxDistance = double.MaxValue;
            PointLatLng ClosestSide = new PointLatLng();
            foreach(Facade facade in BaseBuilding.Facades)
            {
                double distance = GetDistance(facade.PointCenter, Position);
                if (distance < MaxDistance)
                {
                    ClosestSide = facade.PointCenter;
                    MaxDistance = distance;
                }
            }
            return ClosestSide;
        }

        public string GetDirectionAsText()
        {
            double Azimuth = AnalyzedFacade.Azimuth;
            if (Azimuth > 315 || Azimuth < 45)
            {
                return "North";
            }
            else if (Azimuth > 45 && Azimuth < 135)
            {
                return "East";

            }
            else if (Azimuth > 135 && Azimuth < 225)
            {
                return "South";

            }
            else if (Azimuth > 225 && Azimuth < 315)
            {
                return "West";

            }
            return "Unspecified";
        }
    }
}
