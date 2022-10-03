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
        public void Add(Admins entity)
        {
            entity.CreateTime = DateTime.Now;
            NiuShopDBEntities db = new NiuShopDBEntities();
            db.Admins.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Admins.Where(a => a.AdminID == id).First();
            db.Admins.Remove(data);
            db.SaveChanges();
        }

        public Admins FindByID(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Admins.Where(a => a.AdminID == id).First();
            return data;
        }

        public List<Admins> GetAll()
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Admins.ToList();
            return data;
        }

        public Admins Login(string adminname, string adminpwd)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Admins.Where(a => a.AdminName == adminname && a.AdminPWD == adminpwd).First();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public void Update(int id, Admins entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Admins.Where(a => a.AdminID == id).First();
            data.AdminName = entity.AdminName;
            data.AdminPWD = entity.AdminPWD;
            data.CreateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
