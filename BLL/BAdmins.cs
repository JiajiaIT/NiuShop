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
    public class BAdmins : IAdmins
    {
        public void Add(Admins entity)
        {
            Factory.CreateFactory.GetAdmins().Add(entity);
        }

        public void Delete(int id)
        {
            Factory.CreateFactory.GetAdmins().Delete(id);
        }

        public Admins FindByID(int id)
        {
            return Factory.CreateFactory.GetAdmins().FindByID(id);
        }

        public List<Admins> GetAll()
        {
            return Factory.CreateFactory.GetAdmins().GetAll();
        }

        public int Login(string adminname, string adminpwd)
        {
            return Factory.CreateFactory.GetAdmins().Login(adminname, adminpwd);
        }

        public void Update(int id, Admins entity)
        {
            Factory.CreateFactory.GetAdmins().Update(id, entity);
        }
    }
}
