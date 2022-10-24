using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class View_Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<int> Postage { get; set; }
        public Nullable<System.DateTime> CreateTIme { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public Nullable<int> BoardID { get; set; }
        public string Cover { get; set; }
        public string BoardName { get; set; }
    }
}