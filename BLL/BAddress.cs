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
    public class BAddress : IDAL.IAddress
    {
        public void Add(Address entity)
        {
            Factory.CreateFactory.GetAddress().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetAddress().Delete(id);
        }

        public Address FindByID(int id)
        {
            return Factory.CreateFactory.GetAddress().FindByID(id);
        }

        public List<Address> GetAll()
        {
            return Factory.CreateFactory.GetAddress().GetAll();
        }

        public void Update(int id, Address entity)
        {
            Factory.CreateFactory.GetAddress().Update(id, entity);
        }
    }
}
