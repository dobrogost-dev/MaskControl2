using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public static class MaskCalculatorUtilities
    {
        public static double MetersToDegreesLatitude(double meters)
        {
            double earthRadius = 6378137;

            return (meters / (earthRadius * Math.PI)) * 180;
        }
        public static double MetersToDegreesLongitude(double meters, double latitude)
        {
            // Earth's radius in meters
            double earthRadius = 6371000;

            double circumferenceAtLatitude = 2 * Math.PI * earthRadius * Math.Cos(latitude * Math.PI / 180);

            double longitudeDegrees = meters * 360 / circumferenceAtLatitude;

            return longitudeDegrees;
        }
        public static decimal SquareRoot(decimal square)
        {
            if (square <= 0) return 0;

            decimal root = square / 3;
            int i;
            for (i = 0; i < 32; i++)
                root = (root + square / root) / 2;
            return root;
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
        public static bool IsBetween(double angle, double start, double end)
        {
            if (start <= end)
            {
                return angle >= start && angle <= end;
            }
            else
            {
                return angle >= start || angle <= end;
            }
        }
        public static double CalculateAngleBetweenSides(double baseLength, double hypotenuse)
        {
            double sinAlpha = baseLength / hypotenuse;
            double angleInRadians = Math.Acos(sinAlpha);
            double angleInDegrees = angleInRadians * (180.0 / Math.PI);
            return angleInDegrees;
        }
        public static double GetDistance(PointLatLng p1, PointLatLng p2)
        {
            GMapRoute route = new GMapRoute("getDistance");
            route.Points.Add(p1);
            route.Points.Add(p2);
            double distance = route.Distance;
            route.Clear();
            route = null;

            return distance;
        }

    }
}
