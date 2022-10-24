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
    public class B_ProductBoard : IProductBoard
    {
        public void Add(ProductBoard obj)
        {
            CreateFactory.GetProductBoard().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetProductBoard().Delete(id);
        }

        public ProductBoard FindById(int id)
        {
            return CreateFactory.GetProductBoard().FindById(id);
        }

        public List<ProductBoard> GetAll()
        {
            return CreateFactory.GetProductBoard().GetAll();
        }

        public void Update(int id, ProductBoard obj)
        {
            CreateFactory.GetProductBoard().Update(id, obj);
        }
    }
}
