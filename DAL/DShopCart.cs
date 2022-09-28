using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DShopCart : IDAL.IShopCart
    {
        public void Add(ShopCart entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            db.ShopCart.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ShopCart.Where(s => s.Id == id).First();
            db.ShopCart.Remove(data);
            db.SaveChanges();
        }

        public ShopCart FindByID(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ShopCart.Where(s => s.Id == id).First();
            return data;
        }

        public List<ShopCart> GetAll()
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ShopCart.ToList();
            return data;
        }

        public void Update(int id, ShopCart entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ShopCart.Where(s => s.Id == id).First();
            data.CustomerID = entity.CustomerID;
            data.ProperID = entity.ProperID;
            data.Quantity = entity.Quantity;
            data.CreateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
