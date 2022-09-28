using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using BLL;
using Factory;

namespace BLL
{
    public class BShopCart : IShopCart
    {
        public void Add(ShopCart entity)
        {
            Factory.CreateFactory.GetShopCart().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetShopCart().Delete(id);
        }

        public ShopCart FindByID(int id)
        {
            return Factory.CreateFactory.GetShopCart().FindByID(id);
        }

        public List<ShopCart> GetAll()
        {
            return Factory.CreateFactory.GetShopCart().GetAll();
        }

        public void Update(int id, ShopCart entity)
        {
            Factory.CreateFactory.GetShopCart().Update(id, entity);
        }
    }
}
