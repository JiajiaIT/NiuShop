using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_Product : IProduct
    {
        nd20002Entities _db;

        public D_Product()
        {
            _db = new nd20002Entities();
        }

        public void Add(Model.Product obj)
        {
            _db.Product.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _db.Product.Find(id);
            _db.Product.Remove(data);
            _db.SaveChanges();
        }

        public Model.Product FindById(int id)
        {
            return _db.Product.Find(id);
        }

        public List<Model.Product> GetAll()
        {
            return _db.Product.ToList();
        }

        public void Update(int id, Model.Product obj)
        {
            var data = _db.Product.Find(id);
            data.ProductName = obj.ProductName;
            data.Description = obj.Description;
            data.Postage = obj.Postage;
            data.IsOnline = obj.IsOnline;
            data.BoardID = obj.BoardID;
            data.Cover = obj.Cover;
            _db.SaveChanges();
        }
    }
}
