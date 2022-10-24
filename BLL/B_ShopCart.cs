using Factory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class B_ShopCart : IShopCart
    {
        public void Add(ShopCart obj)
        {
            CreateFactory.GetShopCart().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetShopCart().Delete(id);
        }

        public ShopCart FindById(int id)
        {
            return CreateFactory.GetShopCart().FindById(id);
        }

        public List<ShopCart> GetAll()
        {
            return CreateFactory.GetShopCart().GetAll();
        }

        public void Update(int id, ShopCart obj)
        {
            CreateFactory.GetShopCart().Update(id, obj);
        }
    }
}
