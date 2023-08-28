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
using WindowsFormsApp2.Controls;
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
        public double DefaultLeftBuildingHeight = 0;
        public double DefaultLeftMiddleBuildingHeight = 0;
        public double DefaultRightMiddleBuildingHeight = 0;
        public double DefaultRightBuildingHeight = 0;

        public bool DefaultLeftNotFound = false;
        public bool DefaultLeftMiddleNotFound = false;
        public bool DefaultRightMiddleNotFound = false;
        public bool DefaultRightNotFound = false;

        public double radius = 45;
        public void LoadData(OSMdata Data)
        {
            if (Buildings == null)
            {
                Buildings = new List<Building>();
            }
            if (Nodes == null)
            {
                Nodes = new List<Node>();
            }

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
            if (Buildings == null)
            {
                Buildings = new List<Building>();
            }
            if (Nodes == null)
            {
                Nodes = new List<Node>();
            }
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
                    if (!Nodes.Contains(node))
                    {
                        Nodes.Add(node);
                    }
                }
                else if (element.type == "way")
                {
                    Building building = element as Building;
                    if (!Buildings.Any(b => b.id == building.id))
                    {
                        Buildings.Add(building);
                    }
                }
            }
        }
        private void FindBaseBuilding(PointLatLng BasePoint)
        {
            double HighestDistanceToBasePoint = double.MaxValue;
            foreach (Building building in Buildings)
            {
                building.CenterPoint = GetCenterPosition(building);
                CalculateFacades(building);

                foreach (Facade facade in building.Facades)
                {
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

        private void AssignDirection(Building TargetBuilding, Facade BaseBuildingAnalyzedFacade)
        {
            PointLatLng TargetBuildingCenter = GetCenterPosition(TargetBuilding);
            double BaseAzimuth = BaseBuildingAnalyzedFacade.Azimuth;

            double TargetAzimuth = CalculateAzimuth(BaseBuildingAnalyzedFacade.PointCenter, TargetBuildingCenter);

            BaseAzimuth = (BaseAzimuth + 360) % 360;
            TargetAzimuth = (TargetAzimuth + 360) % 360;

            double LeftAzimuth = (BaseAzimuth - 90 + 360) % 360;
            double LeftMiddleAzimuth = (BaseAzimuth - 45 + 360) % 360;
            double RightMiddleAzimuth = (BaseAzimuth + 45) % 360;
            double RightAzimuth = (BaseAzimuth + 90) % 360;


            TargetBuilding.direction = Building.Direction.Unspecified;

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
            if (!AnyPointIsWithin(TargetBuilding, BaseBuildingAnalyzedFacade.PointCenter, radius))
            {
                TargetBuilding.direction = Building.Direction.Unspecified;
            }
        }

        private void InitializeBuildings(PointLatLng BaseDirectionPoint)
        {
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
        private PointLatLng GetCenterPosition(Building building)
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
        private Node GetNodeForId(long id)
        {
            return Nodes
                .Select(e => e)
                .Where(e => e.id == id)
                .FirstOrDefault();
        }
        public MaskResult CalculateMasks(double DefaultBuildingFloorHeight)
        {
            MaskResult result = new MaskResult();
            if (Buildings.Count == 0 || Nodes.Count == 0)
            {
                return result;
            }
            if (CheckForDefaultValues())
            {
                Console.WriteLine("Default values found");
                GetDataFromDefaultHeightForm();
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

        private void GetDataFromDefaultHeightForm()
        {
            DefaultHeightForm Form = new DefaultHeightForm(this);
            Form.ShowDialog();
        }

        private bool CheckForDefaultValues()
        {
            DefaultLeftNotFound = false;
            DefaultLeftMiddleNotFound = false;
            DefaultRightMiddleNotFound = false;
            DefaultRightNotFound = false;

            DefaultLeftBuildingHeight = 0;
            DefaultLeftMiddleBuildingHeight = 0;
            DefaultRightMiddleBuildingHeight = 0;
            DefaultRightBuildingHeight = 0;

            foreach (Building building in Buildings)
            {
                if (building.tags.height == null && building.tags.BuildingLevels == null)
                {
                    switch (building.direction)
                    {
                        case Building.Direction.East_SouthEast: 
                            DefaultLeftNotFound = true;
                            break;
                        case Building.Direction.SouthEast_South:
                            DefaultLeftMiddleNotFound = true;
                            break;
                        case Building.Direction.South_SouthWest:
                            DefaultRightMiddleNotFound = true;
                            break;
                        case Building.Direction.SouthWest_West:
                            DefaultRightNotFound = true;
                            break;
                    }
                }
            }
            return DefaultLeftNotFound || DefaultLeftMiddleNotFound ||
                   DefaultRightMiddleNotFound || DefaultRightNotFound;
        }

        private double ProcessMask(Building building, double DefaultBuildingFloorHeight, double DefaultBuildingHeight)
        {
            double mask = 0;
            double distance = double.MaxValue;
            PointLatLng BasePoint = new PointLatLng();
            PointLatLng TargetPoint = new PointLatLng();
            foreach (Facade facade in BaseBuilding.Facades)
            {
                foreach (long node in building.NodesId)
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
        private double GetMaskValue(PointLatLng BasePoint, PointLatLng TargetPoint, double height)
        {
            double distance = CalculateDistanceInMeters(BasePoint.Lat, BasePoint.Lng, TargetPoint.Lat, TargetPoint.Lng);
            double diagonal = Math.Sqrt((distance * distance) + (height * height));
            double mask = CalculateAngleBetweenSides(distance, diagonal);
            return mask;
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

        internal bool AdjustTargetBuildingHeight(PointLatLng point)
        {
            if (Buildings == null)
            {
                return false;
            }
            foreach(Building building in Buildings)
            {
                if (IsPointInsidePolygon(point, building.NodesId) )
                {
                    Console.WriteLine("Building id: " + building.id + " detected");
                    string InitialHeight = building.tags.height;
                    AdjustHeightForm Form = new AdjustHeightForm(building);
                    Form.ShowDialog();
                    string NewHeight = building.tags.height;
                    if (InitialHeight != NewHeight)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsPointInsidePolygon(PointLatLng point, long[] nodes)
        {
            List<PointLatLng> polygon = new List<PointLatLng>();
            foreach (long node in nodes)
            {
                Node NewNode = GetNodeForId(node);
                PointLatLng Point = new PointLatLng(NewNode.lat, NewNode.lon);
                polygon.Add(Point);
            }
            int i, j;
            bool isInside = false;

            for (i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
            {
                if (((polygon[i].Lat > point.Lat) != (polygon[j].Lat > point.Lat)) &&
                    (point.Lng < (polygon[j].Lng - polygon[i].Lng) * (point.Lat - polygon[i].Lat) / (polygon[j].Lat - polygon[i].Lat) + polygon[i].Lng))
                {
                    isInside = !isInside;
                }
            }

            return isInside;
        }
        public bool AnyPointIsWithin(Building building, PointLatLng point, double radius)
        {
            foreach (Facade facade in building.Facades)
            {
                Console.WriteLine(CalculateDistanceInMeters(facade.PointCenter.Lat, facade.PointCenter.Lng, point.Lat, point.Lng));

                if (CalculateDistanceInMeters(facade.PointCenter.Lat, facade.PointCenter.Lng, point.Lat, point.Lng) < radius)
                {
                    return true;
                }
            }
            foreach (long NodeId in building.NodesId)
            {
                Node node = GetNodeForId(NodeId);
                Console.WriteLine(CalculateDistanceInMeters(node.lat, node.lon, point.Lat, point.Lng));
                if (CalculateDistanceInMeters(node.lat, node.lon, point.Lat, point.Lng) < radius)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
