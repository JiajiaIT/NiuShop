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
    public class BOrderDetail : IOrderDetail
    {
        public void Add(OrderDetail entity)
        {
            Factory.CreateFactory.GetOrderDetail().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetOrderDetail().Delete(id);
        }

        public OrderDetail FindByID(int id)
        {
            return Factory.CreateFactory.GetOrderDetail().FindByID(id);
        }

        public List<OrderDetail> GetAll()
        {
            return Factory.CreateFactory.GetOrderDetail().GetAll();
        }

        public void Update(int id, OrderDetail entity)
        {
            Factory.CreateFactory.GetOrderDetail().Update(id, entity);
        }
    }
}
