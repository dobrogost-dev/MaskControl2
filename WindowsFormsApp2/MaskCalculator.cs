using GMap.NET;
using System;
using System.Collections.Generic;
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
            bool FirstBuildingIteration = true;
            foreach (Element element in Data.elements)
            {
                if (element.type == "node")
                {
                    Node node = element as Node;
                    Nodes.Add(node);
                }
                else if (FirstBuildingIteration)
                {
                    Building building = element as Building;
                    BaseBuilding = building;
                    FirstBuildingIteration = false;
                }
                else if (element.type == "way")
                {
                    Building building = element as Building;
                    Buildings.Add(building);
                }
            }
        }
        public void ShowBuildings()
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
