using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace BLL
{
    public class B_Address : IAddress
    {
        public void Add(Address obj)
        {
            CreateFactory.GetAddress().Add(obj);
        }

        public void Delete(int id)
        {
            CreateFactory.GetAddress().Delete(id);
        }

        public Address FindById(int id)
        {
            return CreateFactory.GetAddress().FindById(id);
        }

        public List<Address> GetAddress(string token)
        {
            return CreateFactory.GetAddress().GetAddress(token);
        }

        public List<Address> GetAll()
        {
            return CreateFactory.GetAddress().GetAll();
        }

        public void Update(int id, Address obj)
        {
            CreateFactory.GetAddress().Update(id, obj);
        }
    }
}
