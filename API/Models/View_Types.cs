using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class View_Types
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> ProductID { get; set; }

        public string ProductName { get; set; }
    }
}