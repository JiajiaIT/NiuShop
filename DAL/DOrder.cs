using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DOrder : IDAL.IOrder
    {
        NiuShopDBEntities db = new NiuShopDBEntities();
        public void Add(Order entity)
        {
            db.Order.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Order.Where(o => o.OrderID == id).First();
            db.Order.Remove(data);
            db.SaveChanges();
        }

        public Order FindByID(int id)
        {
            var data = db.Order.Where(o => o.OrderID == id).First();
            return data;
        }

        public List<Order> GetAll()
        {
            var data = db.Order.ToList();
            return data;
        }
        public void Update(int id, Order entity)
        {
            var data = db.Order.Where(o => o.OrderID == id).First();
            data.OrderState = entity.OrderState;
            data.OrderMoney = entity.OrderMoney;
            data.SenDate = entity.SenDate;
            data.ReceiveDate = entity.ReceiveDate;
            data.AddressInfo = entity.AddressInfo;
            data.InvoiceName = entity.InvoiceName;
            data.InvoiceType = entity.InvoiceType;
            data.Postage = entity.Postage;
            data.Express = entity.Express;
            data.ExpressNumber = entity.ExpressNumber;
            data.CreateTime = DateTime.Now;
            data.CustomerID = entity.CustomerID;
            db.SaveChanges();
        }
    }
}
