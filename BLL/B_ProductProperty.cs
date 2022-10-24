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
    public class B_ProductProperty : IProductProperty
    {
        public void Add(ProductProperty obj)
        {
            CreateFactory.GetProductProperty().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetProductProperty().Delete(id);
        }

        public ProductProperty FindById(int id)
        {
            return CreateFactory.GetProductProperty().FindById(id);
        }

        public List<ProductProperty> GetAll()
        {
            return CreateFactory.GetProductProperty().GetAll();
        }

        public void Update(int id, ProductProperty obj)
        {
            CreateFactory.GetProductProperty().Update(id, obj);
        }
    }
}
