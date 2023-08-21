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
    public class GeocodingData
    {
        [JsonProperty("osm_type")]
        public string OsmType;
        public string Lat;
        public string Lon;
        public string Class;
    }
}
