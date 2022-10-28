using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class View_Address
    {
        public int AddressID { get; set; }
        public string AddressInfo { get; set; }
        public string Postcode { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public string Tel { get; set; }
        public string Phone { get; set; }
        public string AddressType { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string AddresssName { get; set; }
        public string Areas { get; set; }
    }
}