using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DOrderDetail : IDAL.IOrderDetail
    {
        public void Add(OrderDetail entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            db.OrderDetail.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.OrderDetail.Where(o => o.DetailID == id).First();
            db.OrderDetail.Remove(data);
            db.SaveChanges();
        }

        public OrderDetail FindByID(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.OrderDetail.Where(o => o.DetailID == id).First();
            return data;
        }

        public List<OrderDetail> GetAll()
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.OrderDetail.ToList();
            return data;
        }

        public void Update(int id, OrderDetail entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.OrderDetail.Where(o => o.DetailID == id).First();
            data.OrderID = entity.OrderID;
            data.ProperID = entity.ProperID;
            data.ProperName = entity.ProperName;
            data.TypeName = entity.TypeName;
            data.ProperName = entity.ProperName;
            data.IMG = entity.IMG;
            data.Quantity = entity.Quantity;
            data.Price = entity.Price;
            data.TotalMoney = entity.TotalMoney;
            data.CreateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
