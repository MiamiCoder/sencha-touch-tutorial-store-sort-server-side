using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ST2Class.st2tuts.services
{
    public class Sorter
    {
       [JsonProperty(PropertyName = "property")]
        public string Property { get; set; }

        [JsonProperty(PropertyName = "direction")]

        public string Direction { get; set; }
    }
}