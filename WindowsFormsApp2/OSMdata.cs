using Newtonsoft.Json;
using System;
using JsonSubTypes;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;

namespace WindowsFormsApp2
{

    public class OSMdata
    {
        public float version { get; set; }
        public string generator { get; set; }
        public Osm3s osm3s { get; set; }
        [JsonConverter(typeof(JsonSubtypes), "type")]
        public Element[] elements { get; set; }
    }

    public class Osm3s
    {
        public DateTime timestamp_osm_base { get; set; }
        public string copyright { get; set; }
    }


    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(Node), "node")]
    [JsonSubtypes.KnownSubType(typeof(Building), "way")]
    public abstract class Element : OSMdata
    {
        public abstract string type { get; }
    }

    public class Node : Element
    {
        public override string type { get { return "node"; } }
        public long id { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
    }
    public class Building : Element
    {
        public override string type { get { return "way"; } }
        public long id { get; set; }
        public long[] nodes { get; set; }
        public BuildingTags tags { get; set; }
    }

    public class BuildingTags
    {
        public string height { get; set; }
        [JsonProperty("building:levels")]
        public string BuildingLevels { get; set; }
    }

}
