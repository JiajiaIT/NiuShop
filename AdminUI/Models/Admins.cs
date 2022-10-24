using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public partial class Admins
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminPWD { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}