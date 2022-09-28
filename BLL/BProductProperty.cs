using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using DAL;
using Factory;

namespace BLL
{
    public class BProductProperty : IProductProperty
    {
        public void Add(ProductProperty entity)
        {
            Factory.CreateFactory.GetProductProperty().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetProductProperty().Delete(id);
        }

        public ProductProperty FindByID(int id)
        {
            return Factory.CreateFactory.GetProductProperty().FindByID(id);
        }

        public List<ProductProperty> GetAll()
        {
            return Factory.CreateFactory.GetProductProperty().GetAll();
        }

        public void Update(int id, ProductProperty entity)
        {
            Factory.CreateFactory.GetProductProperty().Update(id, entity);
        }
    }
}
