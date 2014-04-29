using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace ST2Class.st2tuts.services
{
    public class Product
    {
        [JsonProperty(PropertyName = "productCode")]
        public string ProductCode { get; set; }

         [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

         [JsonProperty(PropertyName = "productLine")]
        public string ProductLine { get; set; }
    }

    public class ProductsResult
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "products")]
        public List<Product> Products { get; set; }
    }
}