using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Reflection;

namespace Factory
{
    public class CreateFactory
    {
        public static IAddress GetAddress()
        {
            return (IAddress)Assembly.Load("DAL").CreateInstance("DAL.DAddress");
        }
        public static IAdmins GetAdmins()
        {
            return (IAdmins)Assembly.Load("DAL").CreateInstance("DAL.DAdmins");
        }
        public static ICustomer GetCustomer()
        {
            return (ICustomer)Assembly.Load("DAL").CreateInstance("DAL.DCustomer");
        }
        public static IOrder GetOrder()
        {
            return (IOrder)Assembly.Load("DAL").CreateInstance("DAL.DOrder");
        }
        public static IOrderDetail GetOrderDetail()
        {
            return (IOrderDetail)Assembly.Load("DAL").CreateInstance("DAL.DOrderDetail");
        }
        public static IProduct GetProduct()
        {
            return (IProduct)Assembly.Load("DAL").CreateInstance("DAL.DProduct");
        }
        public static IProductProperty GetProductProperty()
        {
            return (IProductProperty)Assembly.Load("DAL").CreateInstance("DAL.DProductProperty");
        }
        public static IProductType GetProductType()
        {
            return (IProductType)Assembly.Load("DAL").CreateInstance("DAL.DProductType");
        }
        public static IShopCart GetShopCart()
        {
            return (IShopCart)Assembly.Load("DAL").CreateInstance("DAL.DShopCart");
        }
    }
}
