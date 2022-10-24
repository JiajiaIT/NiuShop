using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class View_Products
    {
        public int BoardId { get; set; }
        public string BoardNameCN { get; set; }
        public string BoardNameEN { get; set; }
        public List<View_ProductItem> ProductList { get; set; }
    }

    public class View_ProductItem
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

    }
}