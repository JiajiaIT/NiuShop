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
    public class BCustomer : ICustomer
    {
        public void Add(Customer entity)
        {
            Factory.CreateFactory.GetCustomer().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetCustomer().Delete(id);
        }

        public Customer FindByID(int id)
        {
            return Factory.CreateFactory.GetCustomer().FindByID(id);
        }

        public List<Customer> GetAll()
        {
            return Factory.CreateFactory.GetCustomer().GetAll();
        }

        public void Update(int id, Customer entity)
        {
            Factory.CreateFactory.GetCustomer().Update(id, entity);
        }
    }
}
