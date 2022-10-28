using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class View_CartInfo
    {
        /*
         购物车CartId
        属性表Img
        商品名字FullName（商品+型号+属性值）
        属性表Price
        购物车表Quantity
        小计Total (price*Quantity)
        客户 CustomerID*/
        public int CartId { get; set; }
        public string Img { get; set; }
        public string FullName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int CustomerID { get; set; }
    }
}