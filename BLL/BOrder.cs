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
    public class BOrder : IOrder
    {
        public void Add(Order entity)
        {
            Factory.CreateFactory.GetOrder().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetOrder().Delete(id);
        }

        public Order FindByID(int id)
        {
            return Factory.CreateFactory.GetOrder().FindByID(id);
        }

        public List<Order> GetAll()
        {
            return Factory.CreateFactory.GetOrder().GetAll();
        }

        public void Update(int id, Order entity)
        {
            Factory.CreateFactory.GetOrder().Update(id, entity);
        }
    }
}
