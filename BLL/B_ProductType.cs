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
    public class B_ProductType : IProductType
    {
        public void Add(ProductType obj)
        {
            CreateFactory.GetProductType().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetProductType().Delete(id);
        }

        public ProductType FindById(int id)
        {
            return CreateFactory.GetProductType().FindById(id);
        }

        public List<ProductType> GetAll()
        {
            return CreateFactory.GetProductType().GetAll();
        }

        public void Update(int id, ProductType obj)
        {
            CreateFactory.GetProductType().Update(id, obj);
        }
    }
}
