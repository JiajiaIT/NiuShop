using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    class DProductProperty : IDAL.IProductProperty
    {
        NiuShopDBEntities db = new NiuShopDBEntities();
        public void Add(ProductProperty entity)
        {
            db.ProductProperty.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.ProductProperty.Where(p => p.PropertyID == id).First();
            db.ProductProperty.Remove(data);
            db.SaveChanges();
        }

        public ProductProperty FindByID(int id)
        {
            var data = db.ProductProperty.Where(p => p.PropertyID == id).First();
            return data;
        }

        public List<ProductProperty> GetAll()
        {
            var data = db.ProductProperty.ToList();
            return data;
        }

        public void Update(int id, ProductProperty entity)
        {
            var data = db.ProductProperty.Where(p => p.PropertyID == id).First();
            data.PropertyName = entity.PropertyName;
            data.IMG = entity.IMG;
            data.Price = entity.Price;
            data.Quantity = entity.Quantity;
            data.Description = entity.Description;
            data.CreateTime = DateTime.Now;
            data.TypeID = entity.TypeID;
            db.SaveChanges();
        }
    }
}
