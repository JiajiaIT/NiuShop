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
        public void Add(ProductType entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            db.ProductType.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ProductType.Where(p => p.TypeID == id).First();
            db.ProductType.Remove(data);
            db.SaveChanges();
        }

        public ProductType FindByID(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ProductType.Where(p => p.TypeID == id).First();
            return data;
        }

        public List<ProductType> GetAll()
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ProductType.ToList();
            return data;
        }

        public void Update(int id, ProductType entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.ProductType.Where(p => p.TypeID == id).First();
            data.TypeName = entity.TypeName;
            data.Description = entity.Description;
            data.CreateTime = DateTime.Now;
            data.ProdutID = entity.ProdutID;
            db.SaveChanges();
        }
    }
}
