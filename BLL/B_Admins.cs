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
    public class B_Admins : IAdmins
    {
        public void Add(Admins obj)
        {
            CreateFactory.GetAdmins().Add(obj);
        }

        public Admins CheckUser(string username, string password)
        {
            return CreateFactory.GetAdmins().CheckUser(username, password);
        }

        public void Delete(int id)
        {
            CreateFactory.GetAdmins().Delete(id);
        }

        public Admins FindById(int id)
        {
            return CreateFactory.GetAdmins().FindById(id);
        }

        public List<Admins> GetAll()
        {
            return CreateFactory.GetAdmins().GetAll();
        }

        public void Update(int id, Admins obj)
        {
            CreateFactory.GetAdmins().Update(id, obj);
        }
    }
}
