using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class Board
    {
        public int BoardID { get; set; }
        public string BoardNameCN { get; set; }
        public string BoardNameEN { get; set; }
        public Nullable<int> Power { get; set; }
    }
}