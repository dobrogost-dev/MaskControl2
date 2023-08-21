using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp2.MaskCalculatorUtilities;
namespace WindowsFormsApp2
{
    public class MapPainter
    {
        private MaskCalculator MaskCalculatorInstance;

        public MapPainter(MaskCalculator maskCalculatorInstance)
        {
            MaskCalculatorInstance = maskCalculatorInstance;
        }
        private void DrawLine(GMapOverlay linesOverlay, PointLatLng startPoint, PointLatLng endPoint, Color color, int thickness)
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
        public void DrawSectors(GMapOverlay SemicircleOverlay, GMapOverlay LinesOverlay, double radius)
        {
            if (MaskCalculatorInstance.BaseBuilding == null)
            {
                return;
            }
            //Console.WriteLine("Drawing lines: ");
            PointLatLng BasePoint = MaskCalculatorInstance.AnalyzedFacade.PointCenter;
            double BaseAzimuth = MaskCalculatorInstance.AnalyzedFacade.Azimuth;
            SemicircleOverlay.Clear();
            LinesOverlay.Clear();

            List<PointLatLng> SemicirclePolygons = new List<PointLatLng>();
            bool FirstLinePlaced = false;
            bool SecondLinePlaced = false;
            bool ThirdLinePlaced = false;
            double Start = BaseAzimuth - 90;
            double End = BaseAzimuth + 90;

            double FirstQuarter = BaseAzimuth - 45;
            double SecondQuarter = BaseAzimuth + 45;

            if (Start < 0)
            {
                Start += 360;
            }
            if (End > 360)
            {
                End -= 360;
            }
            if (FirstQuarter < 0)
            {
                FirstQuarter += 360;
            }
            if (SecondQuarter > 360)
            {
                SecondQuarter -= 360;
            }
            double BaseBuildingLatitude = MaskCalculatorInstance.BaseBuilding.CenterPoint.Lat;

            for (double a = 3600; a >= -3600; a -= 1)
            {
                if (a == 0)
                {
                    continue;
                }

                double RadiusMetersLongitude = MetersToDegreesLongitude(radius, BaseBuildingLatitude);
                double AddedLongitude = RadiusMetersLongitude * (a / 3600);

                double RadiusMetersLatitude = MetersToDegreesLatitude(radius);

                double RadiusCorrection = ((RadiusMetersLatitude / RadiusMetersLongitude));
                //The correction is supposed to maximalize the accuracy of the calculations
                //By comparing the BasePoint and Relative Correction Point( which is Poiters, France)
                //if BasePoint is above it the semicircle height gets smaller, if its below it gets bigger
                double LongitudeCorrection = (46.590484 / BaseBuildingLatitude) * 0.67;
                LongitudeCorrection = Math.Min(LongitudeCorrection, 1.0);
                LongitudeCorrection = Math.Max(LongitudeCorrection, 0.5);

                double LatitudeSquared = (RadiusMetersLongitude * RadiusMetersLongitude) - (AddedLongitude * AddedLongitude);
                decimal AddedLatitudeSquared = new decimal(LatitudeSquared * RadiusCorrection * LongitudeCorrection);
                double AddedLatitude = decimal.ToDouble(SquareRoot(AddedLatitudeSquared));

                PointLatLng TargetPoint = new PointLatLng(BasePoint.Lat - AddedLatitude, BasePoint.Lng + AddedLongitude);
                double PointAzimuth = CalculateAzimuth(BasePoint, TargetPoint);

                if (IsBetween(PointAzimuth, Start, End))
                {
                    SemicirclePolygons.Add(TargetPoint);
                }
                if (IsBetween(PointAzimuth, FirstQuarter, (FirstQuarter + 1) % 360) && !FirstLinePlaced)
                {
                    DrawLine(LinesOverlay, BasePoint, TargetPoint, Color.Orange, 1);
                    FirstLinePlaced = true;
                    Console.WriteLine("Placing first line at: " + PointAzimuth);

                }
                if (IsBetween(PointAzimuth, BaseAzimuth, (BaseAzimuth + 1) % 360) && !SecondLinePlaced)
                {
                    DrawLine(LinesOverlay, BasePoint, TargetPoint, Color.Orange, 1);
                    SecondLinePlaced = true;
                    Console.WriteLine("Placing Second line at: " + PointAzimuth);

                }
                if (IsBetween(PointAzimuth, SecondQuarter, (SecondQuarter + 1) % 360) && !ThirdLinePlaced)
                {
                    DrawLine(LinesOverlay, BasePoint, TargetPoint, Color.Orange, 1);
                    ThirdLinePlaced = true;
                    Console.WriteLine("Placing third line at: " + PointAzimuth);
                }
            }
            for (double a = -3600; a <= 3600; a += 1)
            {
                if (a == 0)
                {
                    continue;
                }
                double RadiusMetersLongitude = MetersToDegreesLongitude(radius, BaseBuildingLatitude);
                double AddedLongitude = RadiusMetersLongitude * (a / 3600);

                double RadiusMetersLatitude = MetersToDegreesLatitude(radius);

                double RadiusCorrection = ((RadiusMetersLatitude / RadiusMetersLongitude));
                //The correction is supposed to maximalize the accuracy of the calculations
                //By comparing the BasePoint and Relative Correction Point( which is Poiters, France)
                //if BasePoint is above it the semicircle height gets smaller, if its below it gets bigger
                double LongitudeCorrection = (46.590484 / BaseBuildingLatitude) * 0.67;
                LongitudeCorrection = Math.Min(LongitudeCorrection, 1.0);
                LongitudeCorrection = Math.Max(LongitudeCorrection, 0.5);

                double LatitudeSquared = (RadiusMetersLongitude * RadiusMetersLongitude) - (AddedLongitude * AddedLongitude);
                decimal AddedLatitudeSquared = new decimal(LatitudeSquared * RadiusCorrection * LongitudeCorrection);
                double AddedLatitude = decimal.ToDouble(SquareRoot(AddedLatitudeSquared));

                PointLatLng TargetPoint = new PointLatLng(BasePoint.Lat + AddedLatitude, BasePoint.Lng + AddedLongitude);
                double PointAzimuth = CalculateAzimuth(BasePoint, TargetPoint);

                if (IsBetween(PointAzimuth, Start, End))
                {
                    SemicirclePolygons.Add(TargetPoint);
                }
                if (IsBetween(PointAzimuth, FirstQuarter, (FirstQuarter + 1) % 360) && !FirstLinePlaced)
                {
                    DrawLine(LinesOverlay, BasePoint, TargetPoint, Color.Orange, 1);
                    FirstLinePlaced = true;
                    Console.WriteLine("Placing first line at: " + PointAzimuth);

                }
                if (IsBetween(PointAzimuth, BaseAzimuth, (BaseAzimuth + 1) % 360) && !SecondLinePlaced)
                {
                    DrawLine(LinesOverlay, BasePoint, TargetPoint, Color.Orange, 1);
                    SecondLinePlaced = true;
                    Console.WriteLine("Placing Second line at: " + PointAzimuth);

                }
                if (IsBetween(PointAzimuth, SecondQuarter, (SecondQuarter + 1) % 360) && !ThirdLinePlaced)
                {
                    DrawLine(LinesOverlay, BasePoint, TargetPoint, Color.Orange, 1);
                    ThirdLinePlaced = true;
                    Console.WriteLine("Placing third line at: " + PointAzimuth);
                }
            }
            DrawEntity(SemicircleOverlay, SemicirclePolygons, Color.DarkOrange);
        }
        private void DrawEntity(GMapOverlay polygonsOverlay, List<PointLatLng> polygons, Color color)
        {
            GMapPolygon buildingPolygon = new GMapPolygon(polygons, "building");
            buildingPolygon.Fill = new SolidBrush(Color.FromArgb(50, color));
            buildingPolygon.Stroke = new Pen(color, 1);
            polygonsOverlay.Polygons.Add(buildingPolygon);
        }
        public void DrawBuildings(GMapOverlay polygonsOverlay, bool DirectionBuilding)
        {
            if (MaskCalculatorInstance.Buildings.Count == 0 || MaskCalculatorInstance.Nodes.Count == 0)
            {
                return;
            }
            polygonsOverlay.Clear();
            List<PointLatLng> BaseBuildingPolygons = GetPolygons(MaskCalculatorInstance.BaseBuilding);
            DrawEntity(polygonsOverlay, BaseBuildingPolygons, Color.Blue);
            foreach (Building building in MaskCalculatorInstance.Buildings)
            {
                List<PointLatLng> BuildingPolygons = GetPolygons(building);
                Color color = Color.Gray;
                if (DirectionBuilding)
                {
                    switch (building.direction)
                    {
                        case Building.Direction.Unspecified: color = Color.Gray; break;
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
                    if (building.direction == Building.Direction.Unspecified)
                    {
                        color = Color.Gray;
                    }
                }
                DrawEntity(polygonsOverlay, BuildingPolygons, color);
            }
        }
        private List<PointLatLng> GetPolygons(Building building)
        {
            List<PointLatLng> result = new List<PointLatLng>();
            foreach (long node in building.NodesId)
            {
                Node newNode = MaskCalculatorInstance.GetNodeById(node);
                result.Add(new PointLatLng(newNode.lat, newNode.lon));
            }
            return result;
        }
    }
}
