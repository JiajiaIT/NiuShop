using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_ShopCart : IShopCart
    {
        nd20002Entities _db;

        public D_ShopCart()
        {
            _db = new nd20002Entities();
        }

        public void Add(ShopCart obj)
        {
            //添加购物车时，如果该用户存在指定商品就修改数量，否则添加
            var data = _db.ShopCart.Where(x => x.CustomerID == obj.CustomerID && x.ProperID == obj.ProperID);
            if (data.Count() == 0)
            {
                _db.ShopCart.Add(obj);
            }
            else
            {
                var sc = data.First();
                sc.Quantity += obj.Quantity;
            }
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.ShopCart.Remove(_db.ShopCart.Find(id));
            _db.SaveChanges();
        }

        public ShopCart FindById(int id)
        {
            return _db.ShopCart.Find(id);
        }

        public List<ShopCart> GetAll()
        {
            return _db.ShopCart.ToList();
        }

        public void Update(int id, ShopCart obj)
        {
            var data = _db.ShopCart.Find(id);
            data.CustomerID = obj.CustomerID;
            data.ProperID = obj.ProperID;
            data.Quantity = obj.Quantity;
            _db.SaveChanges();
        }
    }
}
