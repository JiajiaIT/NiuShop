using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class D_Admins : IAdmins
    {
        Model.nd20002Entities _db;

        public D_Admins()
        {
            _db = new nd20002Entities();
        }


        public void Add(Model.Admins obj)
        {
            _db.Admins.Add(obj);
            _db.SaveChanges();
        }

        public Admins CheckUser(string username, string password)
        {
            Admins admin = _db.Admins.FirstOrDefault((x) => x.AdminName == username && x.AdminPWD == password);
            return admin;
        }

        public void Delete(int id)
        {
            var data = _db.Admins.Find(id);
            _db.Admins.Remove(data);
            _db.SaveChanges();
        }

        public Model.Admins FindById(int id)
        {
           return _db.Admins.Find(id);
        }

        public List<Model.Admins> GetAll()
        {
            var list = _db.Admins.ToList();
            return list;
        }

        public void Update(int id, Model.Admins obj)
        {
            var data = _db.Admins.Find(id);
            data.AdminPWD = obj.AdminPWD;
            _db.SaveChanges();
        }
    }
}
