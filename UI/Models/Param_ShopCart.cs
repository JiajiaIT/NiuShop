using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class Param_ShopCart
    {
        public int Id { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProperID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}