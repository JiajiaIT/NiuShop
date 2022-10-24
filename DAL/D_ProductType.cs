using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_ProductType : IProductType
    {
        nd20002Entities _db;
        public D_ProductType() {
            _db = new nd20002Entities();
        }
        public void Add(ProductType obj)
        {
            _db.ProductType.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.ProductType.Remove(_db.ProductType.Find(id));
            _db.SaveChanges();
        }

        public ProductType FindById(int id)
        {
            return _db.ProductType.Find(id);
        }

        public List<ProductType> GetAll()
        {
            return _db.ProductType.ToList();
        }

        public void Update(int id, ProductType obj)
        {
            var data = _db.ProductType.Find(id);
            data.TypeName = obj.TypeName;
            data.Description = obj.Description;
            data.ProductID = obj.ProductID;
            _db.SaveChanges();
        }
    }
}
