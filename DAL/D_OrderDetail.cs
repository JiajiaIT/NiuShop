using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_OrderDetail : IOrderDetail
    {

        nd20002Entities _db;

        public D_OrderDetail()
        {
            _db = new nd20002Entities();
        }



        public void Add(Model.OrderDetail obj)
        {
            _db.OrderDetail.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _db.OrderDetail.Find(id);
            _db.OrderDetail.Remove(data);
            _db.SaveChanges();
        }

        public Model.OrderDetail FindById(int id)
        {
            return _db.OrderDetail.Find(id);
        }

        public List<Model.OrderDetail> GetAll()
        {
            return _db.OrderDetail.ToList();
        }

        public void Update(int id, Model.OrderDetail obj)
        {
            var data = _db.OrderDetail.Find(id);
            data.OrderID = obj.OrderID;
            data.ProperID = obj.ProperID;
            data.ProductName = obj.ProductName;
            data.TypeName = obj.TypeName;
            data.ProperName = obj.ProperName;
            data.IMG = obj.IMG;
            data.Quantity = obj.Quantity;
            data.Price = obj.Price;
            data.TotalMoney = obj.TotalMoney;
            _db.SaveChanges();
        }
    }
}
