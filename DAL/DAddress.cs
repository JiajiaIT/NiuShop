using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;

namespace DAL
{
    public class DAddress : IDAL.IAddress
    {
        NiuShopDBEntities db = new NiuShopDBEntities();
        public void Add(Address entity)
        {
            db.Address.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = db.Address.Where(a => a.AddressID == id).First();
            db.Address.Remove(data);
            db.SaveChanges();
        }

        public Address FindByID(int id)
        {
            var data = db.Address.Where(a => a.AddressID == id).First();
            return data;
        }

        public List<Address> GetAll()
        {
            var data = db.Address.ToList();
            return data;
        }

        public void Update(int id, Address entity)
        {
            var data = db.Address.Where(a => a.AddressID == id).First();
            data.AddressInfo = entity.AddressInfo;
            data.Postcode = entity.Postcode;
            data.IsDefault = entity.IsDefault;
            data.Tel = entity.Tel;
            data.Phone = entity.Phone;
            data.AddressType = entity.AddressType;
            data.CreateTime = DateTime.Now;
            data.CustomerID = entity.CustomerID;
            data.Areas = entity.Areas;
            data.AddressName = entity.AddressName;
            db.SaveChanges();
        }
    }
}
