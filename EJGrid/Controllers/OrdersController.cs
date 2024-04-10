using EJGrid.Models;
using Microsoft.OData.Core.UriParser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.OData;
using System.Web.OData.Query;

namespace EJGrid.Controllers
{
    public class OrdersController : ODataController
    {
        public static List<Orders> order = new List<Orders>();
        // GET: Orders
        [EnableQuery]
        public IQueryable<Orders> Get()
        {
            if (order.Count == 0)
                BindDataSource();
            return order.AsQueryable();
        }
        public Orders Patch([FromODataUri]int key, [FromBody]Delta<Orders> patch)
        {
            Orders data = order.Where(p => p.OrderID == key).FirstOrDefault();
            patch.Patch(data);
            return data;
        }
        public HttpResponseMessage Post(Orders value)
        {
            order.Add(value);
            return Request.CreateResponse(HttpStatusCode.OK, value);
        }

        public HttpResponseMessage Delete([FromODataUri]int key)
        {
            Orders data = order.Where(p => p.OrderID == key).FirstOrDefault();
            if (data != null)
            {
                order.Remove(data);
            }
            else
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Removed");
        }
        private void BindDataSource()
        {
            order.Add(new Orders(10248, "ALFKI", 1, 2.3, "Berlin", new DateTime(1990, 05, 04), "2024-05-08T00:00:00-04:00", true, state.Dried));
            order.Add(new Orders(10249, "ALFKI", 2, 3.3, "Madrid", new DateTime(1990, 04, 04), "2024-05-08T00:00:00-04:00", true, state.Cutted));
            order.Add(new Orders(10250, "ANTON", 3, 4.3, "Cholchester", new DateTime(1990, 04, 05), "2024-04-10T00:00:00-04:00", false, state.Delivery));
            order.Add(new Orders(10251, "BLONP", 4, 5.3, "Marseille", new DateTime(1994, 04, 04), "2024-02-07T00:00:00-05:00", true, state.Drying));
            order.Add(new Orders(10252, "BOLID", 5, 6.3, "Tsawassen", new DateTime(1995, 06, 15), "2019-07-18T00:00:00-05:00", false, state.Warehouse));
        }
        public class Orders
        {
            public Orders()
            {

            }
            public Orders(long OrderId, string CustomerId, int EmployeeId, double Freight, string ShipCity, DateTime OrderDate, string ShippedDate, Boolean Verified, state State)
            {
                this.OrderID = OrderId;
                this.CustomerID = CustomerId;
                this.EmployeeID = EmployeeId;
                this.Freight = Freight;
                this.ShipCity = ShipCity;
                this.OrderDate = OrderDate;
                this.ShippedDate = ShippedDate;
                this.Verified = Verified;
                this.State = State;
            }
            [Key]
            public long OrderID { get; set; }
            public string CustomerID { get; set; }
            public int EmployeeID { get; set; }
            public double Freight { get; set; }
            public string ShipCity { get; set; }
            public DateTime OrderDate { get; set; }
            public string ShippedDate { get; set; }
            public Boolean Verified { get; set; }
            [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
            public state State { get; set; }

        }

        public enum state
        {
            [EnumMember(Value = "Delivery")]
            Delivery = 0,
            [EnumMember(Value = "Warehouse")]
            Warehouse = 1,
            [EnumMember(Value = "Drying")]
            Drying = 2,
            [EnumMember(Value = "Dried")]
            Dried = 3,
            [EnumMember(Value = "Cutting")]
            Cutting = 4,
            [EnumMember(Value = "Cutted")]
            Cutted = 5
        }

    }
}