using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_ProductProperty : IProductProperty
    {
        nd20002Entities _db;
        public D_ProductProperty()
        {
            _db = new nd20002Entities();
        }
        public void Add(ProductProperty obj)
        {
            _db.ProductProperty.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.ProductProperty.Remove(_db.ProductProperty.Find(id));
            _db.SaveChanges();
        }

        public ProductProperty FindById(int id)
        {
            return _db.ProductProperty.Find(id);
        }

        public List<ProductProperty> GetAll()
        {
            return _db.ProductProperty.ToList();
        }

        public void Update(int id, ProductProperty obj)
        {
            var data = _db.ProductProperty.Find(id);
            data.PropertyName = obj.PropertyName;
            data.IMG = obj.IMG;
            data.Quantity = obj.Quantity;
            data.Price = obj.Price;
            data.Description = obj.Description;
            data.TypeID = obj.TypeID;
            _db.SaveChanges();
        }
    }
}
