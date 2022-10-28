using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Param_Order
    {
        /*
         整个订单表（order）
            [{
            properid、quantity
            }]
         */
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
        public string TokenID { get; set; }
        public int[] Carts { get; set; }
    }

}