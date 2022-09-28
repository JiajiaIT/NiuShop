using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DAdmins : IDAL.IAdmins
    {
        NiuShopDBEntities db = new NiuShopDBEntities();
        public void Add(Admins entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Admins.Where(a => a.AdminID == id).First();
            db.Admins.Remove(data);
            db.SaveChanges();
        }

        public Admins FindByID(int id)
        {
            var data = db.Admins.Where(a => a.AdminID == id).First();
            return data;
        }

        public List<Admins> GetAll()
        {
            var data = db.Admins.ToList();
            return data;
        }

        public void Update(int id, Admins entity)
        {
            var data = db.Admins.Where(a => a.AdminID == id).First();
            data.AdminName = entity.AdminName;
            data.AdminPWD = entity.AdminPWD;
            data.CreateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
