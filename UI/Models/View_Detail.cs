using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class View_Detail
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int TypeID  { get; set; }
        public string TypeName { get; set; }
        public List<view_ProductProperty> PPList { get; set; }

    }

    public class view_ProductProperty
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string IMG { get; set; }
    }
}