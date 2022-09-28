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

        public int Login(string adminname, string adminpwd)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Admins.Where(a => a.AdminName == adminname && a.AdminPWD == adminpwd);
            if (data.Count() > 0)
            {
                return 1;
            }
            else
            {
                return 0;
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
