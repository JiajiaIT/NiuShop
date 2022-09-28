using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using DAL;
using Factory;

namespace BLL
{
    public class BProduct : IProduct
    {
        public void Add(Product entity)
        {
            Factory.CreateFactory.GetProduct().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetProduct().Delete(id);
        }

        public Product FindByID(int id)
        {
            return Factory.CreateFactory.GetProduct().FindByID(id);
        }

        public List<Product> GetAll()
        {
            return Factory.CreateFactory.GetProduct().GetAll();
        }

        public void Update(int id, Product entity)
        {
            Factory.CreateFactory.GetProduct().Update(id, entity);
        }
    }
}
