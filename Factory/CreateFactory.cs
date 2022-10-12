using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;       //反射命名空间

namespace Factory
{
    public class CreateFactory
    {
        public static IAddress GetAddress()
        {
            return (IAddress)Assembly.Load("DAL").CreateInstance("DAL.D_Address");
        }
        public static IAdmins GetAdmins()
        {
            return (IAdmins)Assembly.Load("DAL").CreateInstance("DAL.D_Admins");
        }
        public static ICustomer GetCustomer()
        {
            return (ICustomer)Assembly.Load("DAL").CreateInstance("DAL.D_Customer");
        }
        public static IOrder GetOrder()
        {
            return (IOrder)Assembly.Load("DAL").CreateInstance("DAL.D_Order");
        }
        public static IOrderDetail GetOrderDetail()
        {
            return (IOrderDetail)Assembly.Load("DAL").CreateInstance("DAL.D_OrderDetail");
        }
        public static IProduct GetProduct()
        {
            return (IProduct)Assembly.Load("DAL").CreateInstance("DAL.D_Product");
        }
        public static IProductProperty GetProductProperty()
        {
            return (IProductProperty)Assembly.Load("DAL").CreateInstance("DAL.D_ProductProperty");
        }
        public static IProductType GetProductType()
        {
            return (IProductType)Assembly.Load("DAL").CreateInstance("DAL.D_ProductType");
        }
        public static IShopCart GetShopCart()
        {
            return (IShopCart)Assembly.Load("DAL").CreateInstance("DAL.D_ShopCart");
        }

        public static ITokens GetTokens()
        {
            return (ITokens)Assembly.Load("DAL").CreateInstance("DAL.D_Tokens");
        }

        public static IProductBoard GetProductBoard()
        {
            return (IProductBoard)Assembly.Load("DAL").CreateInstance("DAL.D_ProductBoard");
        }
    }
}
