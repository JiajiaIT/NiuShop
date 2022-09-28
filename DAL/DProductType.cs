using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DProductType : IDAL.IProductType
    {
        NiuShopDBEntities db = new NiuShopDBEntities();
        public void Add(ProductType entity)
        {
            db.ProductType.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.ProductType.Where(p => p.TypeID == id).First();
            db.ProductType.Remove(data);
            db.SaveChanges();
        }

        public ProductType FindByID(int id)
        {
            var data = db.ProductType.Where(p => p.TypeID == id).First();
            return data;
        }

        public List<ProductType> GetAll()
        {
            var data = db.ProductType.ToList();
            return data;
        }

        public void Update(int id, ProductType entity)
        {
            var data = db.ProductType.Where(p => p.TypeID == id).First();
            data.TypeName = entity.TypeName;
            data.Description = entity.Description;
            data.CreateTime = DateTime.Now;
            data.ProdutID = entity.ProdutID;
            db.SaveChanges();
        }
    }
}
