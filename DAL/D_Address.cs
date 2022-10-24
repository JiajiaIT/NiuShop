using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class D_Address : IAddress
    {
        nd20002Entities _db;
        public D_Address()
        {
            _db = new nd20002Entities();
        }

        public void Add(Model.Address obj)
        {
            _db.Address.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _db.Address.Find(id);
            _db.Address.Remove(data);
            _db.SaveChanges();
        }

        public Model.Address FindById(int id)
        {
            return _db.Address.Find(id);
        }

        public List<Model.Address> GetAll()
        {
            return _db.Address.ToList();
        }

        public void Update(int id, Model.Address obj)
        {
            var data = _db.Address.Find(id);
            data.AddressInfo = obj.AddressInfo;
            data.Postcode = obj.Postcode;
            data.IsDefault = obj.IsDefault;
            data.Tel = obj.Tel;
            data.Phone = obj.Phone;
            data.AddressType = obj.AddressType;
            //data.CreateTime = obj.CreateTime;
            data.CustomerID = obj.CustomerID;
            data.AddresssName = obj.AddresssName;
            data.Areas = obj.Areas;
            _db.SaveChanges();
        }
    }
}
