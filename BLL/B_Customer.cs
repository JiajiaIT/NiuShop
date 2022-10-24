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
    public class B_Customer : ICustomer
    {
        public void Add(Customer obj)
        {
            CreateFactory.GetCustomer().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetCustomer().Delete(id);
        }

        public Customer FindById(int id)
        {
            return CreateFactory.GetCustomer().FindById(id);
        }

        public List<Customer> GetAll()
        {
            return CreateFactory.GetCustomer().GetAll();
        }

        public string Login(string account, string password)
        {
            return CreateFactory.GetCustomer().Login(account, password);
        }

        public void Update(int id, Customer obj)
        {
            CreateFactory.GetCustomer().Update(id, obj);
        }
    }
}
