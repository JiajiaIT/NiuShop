using Factory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class B_Product : IProduct
    {
        public void Add(Product obj)
        {
            CreateFactory.GetProduct().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetProduct().Delete(id);
        }

        public Product FindById(int id)
        {
            return CreateFactory.GetProduct().FindById(id);
        }

        public List<Product> GetAll()
        {
            return CreateFactory.GetProduct().GetAll();
        }

        public void Update(int id, Product obj)
        {
            CreateFactory.GetProduct().Update(id, obj);
        }
    }
}
