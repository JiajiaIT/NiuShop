using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_Order : IOrder
    {
        nd20002Entities _db;

        public D_Order()
        {
            _db = new nd20002Entities();
        }

        public void Add(Model.Order obj)
        {
            _db.Order.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _db.Order.Find(id);
            _db.Order.Remove(data);
            _db.SaveChanges();
        }

        public Model.Order FindById(int id)
        {
            return _db.Order.Find(id);
        }

        public List<Model.Order> GetAll()
        {
            return _db.Order.ToList();
        }

        public void Update(int id, Model.Order obj)
        {
            var data = _db.Order.Find(id);
            data.OrderState = obj.OrderState;
            data.OrderMoney = obj.OrderMoney;
            data.SenDate = obj.SenDate;
            data.ReceiveDate = obj.ReceiveDate;
            data.AddressInfo = obj.AddressInfo;
            data.InvoiceName = obj.InvoiceName;
            data.InvoiceType = obj.InvoiceType;
            data.Postage = obj.Postage;
            data.Express = obj.Express;
            data.ExpressNumber = obj.ExpressNumber;
            data.CustomerID = obj.CustomerID;
            _db.SaveChanges();
        }
    }
}
