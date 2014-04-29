using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ST2Class.st2tuts.services
{
    /// <summary>
    /// Summary description for Collectibles
    /// </summary>
    public class Collectibles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // Create a few dummy products.
            var products = new List<Product>()
            {
                new Product() {
                    ProductCode = "S10_1678",
                    ProductName = "1969 Harley Davidson Ultimate Chopper",
                    ProductLine = "Motorcycles"
                },
                new Product() {
                    ProductCode = "S10_1949",
                    ProductName = "1952 Alpine Renault 1300",
                    ProductLine = "Classic Cars"
                },
                new Product() {
                    ProductCode = "S10_2016",
                    ProductName = "1996 Moto Guzzi 1100i",
                    ProductLine = "Motorcycles"
                },
                new Product() {
                    ProductCode = "S10_4698",
                    ProductName = "2003 Harley-Davidson Eagle Drag Bike",
                    ProductLine = "Motorcycles"
                },
                new Product() {
                    ProductCode = "S12_1666",
                    ProductName = "1958 Setra Bus",
                    ProductLine = "Trucks and Buses"
                },
                new Product() {
                    ProductCode = "S10_4757",
                    ProductName = "1972 Alfa Romeo GTA",
                    ProductLine = "Classic Cars"
                },
                new Product() {
                    ProductCode = "S12_4473",
                    ProductName = "1957 Chevy Pickup",
                    ProductLine = "Trucks and Buses"
                },
                new Product() {
                    ProductCode = "S18_1097",
                    ProductName = "1940 Ford Pickup Truck",
                    ProductLine = "Trucks and Buses"
                }
            };

            Sorter[] sorters = null;
            string sortersJson = context.Request.QueryString["sort"];

            if (sortersJson != null)
            {
                sorters = JsonConvert.DeserializeObject<Sorter[]>(sortersJson);
            }

            if (sorters.Length > 0)
            {
                foreach (Sorter sorter in sorters)
                {
                    switch (sorter.Property)
                    {
                        case "productCode":
                            if (sorter.Direction.ToUpper() == "ASC")
                            {
                                products = products.OrderBy(p => p.ProductCode).ToList();
                            }
                            else
                            {
                                products = products.OrderByDescending(p => p.ProductCode).ToList();
                            }
                            break;
                        case "productName":
                            if (sorter.Direction.ToUpper() == "ASC")
                            {
                                products = products.OrderBy(p => p.ProductName).ToList();
                            }
                            else
                            {
                                products = products.OrderByDescending(p => p.ProductName).ToList();
                            }
                            break;
                        case "productLine":
                            if (sorter.Direction.ToUpper() == "ASC")
                            {
                                products = products.OrderBy(p => p.ProductLine).ToList();
                            }
                            else
                            {
                                products = products.OrderByDescending(p => p.ProductLine).ToList();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            var result = new ProductsResult()
            {
                Success = true,
                Products = products
            };
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}