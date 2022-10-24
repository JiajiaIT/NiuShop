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
    public class B_OrderDetail : IOrderDetail
    {
        public void Add(OrderDetail obj)
        {
            CreateFactory.GetOrderDetail().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetOrderDetail().Delete(id);
        }

        public OrderDetail FindById(int id)
        {
            return CreateFactory.GetOrderDetail().FindById(id);
        }

        public List<OrderDetail> GetAll()
        {
            return CreateFactory.GetOrderDetail().GetAll();
        }

        public void Update(int id, OrderDetail obj)
        {
            CreateFactory.GetOrderDetail().Update(id, obj);
        }
    }
}
