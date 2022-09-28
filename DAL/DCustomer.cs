using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DCustomer : IDAL.ICustomer
    {
        public void Add(Customer entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            db.Customer.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Customer.Where(c => c.CustomerID == id).First();
            db.Customer.Remove(data);
            db.SaveChanges();
        }

        public Customer FindByID(int id)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Customer.Where(c => c.CustomerID == id).First();
            return data;
        }

        public List<Customer> GetAll()
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Customer.ToList();
            return data;
        }

        public void Update(int id, Customer entity)
        {
            NiuShopDBEntities db = new NiuShopDBEntities();
            var data = db.Customer.Where(c => c.CustomerID == id).First();
            data.CustomerName = entity.CustomerName;
            data.CustomerPWD = entity.CustomerPWD;
            data.Tel = entity.Tel;
            data.Email = entity.Email;
            data.CreateTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
