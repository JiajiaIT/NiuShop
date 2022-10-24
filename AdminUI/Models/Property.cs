using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class Property
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public string IMG { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateTIme { get; set; }
        public Nullable<int> TypeID { get; set; }
    }
}