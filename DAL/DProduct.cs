using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DProduct : IDAL.IProduct
    {
        NiuShopDBEntities db = new NiuShopDBEntities();
        public void Add(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Product.Where(p => p.ProductID == id).First();
            db.Product.Remove(data);
            db.SaveChanges();
        }

        public Product FindByID(int id)
        {
            var data = db.Product.Where(p => p.ProductID == id).First();
            return data;
        }

        public List<Product> GetAll()
        {
            var data = db.Product.ToList();
            return data;
        }

        public void Update(int id, Product entity)
        {
            var data = db.Product.Where(p => p.ProductID == id).First();
            data.ProductName = entity.ProductName;
            data.Description = entity.Description;
            data.Postage = entity.Postage;
            data.CreateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
