using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Param_Order_Details
    {
        public int OrderID { get; set; }
        public string OrderState { get; set; }
        public Nullable<decimal> OrderMoney { get; set; }
        public Nullable<System.DateTime> SenDate { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public string AddressInfo { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceType { get; set; }
        public Nullable<decimal> Postage { get; set; }
        public string Express { get; set; }
        public string ExpressNumber { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CustomerID { get; set; }

        public List<Param_Detail> Details { get; set; }
    }

    public class Param_Detail
    {
        public int DetailID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProperID { get; set; }
        public string ProductName { get; set; }
        public string TypeName { get; set; }
        public string ProperName { get; set; }
        public string IMG { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> TotalMoney { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }

    }
}