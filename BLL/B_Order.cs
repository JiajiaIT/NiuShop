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
    public class B_Order : IOrder
    {
        public void Add(Order obj)
        {
            CreateFactory.GetOrder().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetOrder().Delete(id);
        }

        public Order FindById(int id)
        {
            return CreateFactory.GetOrder().FindById(id);
        }

        public List<Order> GetAll()
        {
            return CreateFactory.GetOrder().GetAll();
        }

        public void Update(int id, Order obj)
        {
            CreateFactory.GetOrder().Update(id, obj);
        }
    }
}
