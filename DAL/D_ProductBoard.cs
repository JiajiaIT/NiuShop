using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_ProductBoard : IProductBoard
    {
        nd20002Entities _db;

        public D_ProductBoard()
        {
            _db = new nd20002Entities();
        }
        public void Add(ProductBoard obj)
        {
            _db.ProductBoard.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.ProductBoard.Remove(_db.ProductBoard.Find(id));
            _db.SaveChanges();
        }

        public ProductBoard FindById(int id)
        {
            return _db.ProductBoard.Find(id);
        }

        public List<ProductBoard> GetAll()
        {
            return _db.ProductBoard.ToList();
        }

        public void Update(int id, ProductBoard obj)
        {
            var data = _db.ProductBoard.Find(id);
            data.BoardNameCN = obj.BoardNameCN;
            data.BoardNameEN = obj.BoardNameEN;
            data.Power = obj.Power;
            _db.SaveChanges();
        }
    }
}
