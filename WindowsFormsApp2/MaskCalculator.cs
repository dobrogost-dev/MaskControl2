using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class MaskCalculator
    {
        private ICollection<Building> buildings { get; set; }
        private ICollection<Node> nodes { get; set; }
        public void LoadData(OSMdata data) 
        {
            buildings = new List<Building>();
            nodes = new List<Node>();
            foreach (Element element in data.elements)
            {
                if (element.type == "way")
                {
                    Building building = element as Building;
                    buildings.Add(building);
                }
                else if (element.type == "node")
                {
                    Node node = element as Node;
                    nodes.Add(node);
                }
            }
        }
        public void ShowBuildings()
        {
            foreach(Building building in buildings)
            {
                Console.WriteLine("Building id: " + building.id);
                foreach (long node in building.nodes)
                {
                    Console.WriteLine("Node id: " + node);
                    Console.WriteLine("Node latitude: " + nodes.FirstOrDefault(e => e.id == node).lat);
                    Console.WriteLine("Node longitude: " + nodes.FirstOrDefault(e => e.id == node).lon);
                }
            }
        }

    }
}
