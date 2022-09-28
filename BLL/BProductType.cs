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
    public class BProductType : IProductType
    {
        public void Add(ProductType entity)
        {
            Factory.CreateFactory.GetProductType().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetProductType().Delete(id);
        }

        public ProductType FindByID(int id)
        {
            return Factory.CreateFactory.GetProductType().FindByID(id);
        }

        public List<ProductType> GetAll()
        {
            return Factory.CreateFactory.GetProductType().GetAll();
        }

        public void Update(int id, ProductType entity)
        {
            Factory.CreateFactory.GetProductType().Update(id, entity);
        }
    }
}
