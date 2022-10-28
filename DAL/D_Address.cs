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
            //1.当添加新地址时，如果是默认地址，则需要将所有之前的地址设为非默认
            //2.当添加新地址时，如果不是默认，还需要判断是否不存在任何地址，如果当前为第一个地址，则必须为默认

            var data = _db.Address.Where(x => x.CustomerID == obj.CustomerID);
            if (obj.IsDefault.Value)
            {
                foreach (var item in data)
                {
                    item.IsDefault = false;
                }
            }
            else
            {
                if (data.Count() == 0)
                {
                    obj.IsDefault = true;
                }
            }
            _db.Address.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            //1.如果删除的是默认，则需要将第一个地址设置为默认

            var data = _db.Address.Find(id);
            var customerid = data.CustomerID;
            _db.Address.Remove(data);
            _db.SaveChanges();

            if (data.IsDefault.Value)
            {
                var result = _db.Address.Where(x => x.CustomerID == customerid);
                if (result.Count() > 0)
                {
                    result.First().IsDefault = true;
                }
                _db.SaveChanges();
            }
        }

        public Model.Address FindById(int id)
        {
            return _db.Address.Find(id);
        }

        //根据token获得用户地址集合
        public List<Address> GetAddress(string token)
        {
            var result = from t in _db.Tokens
                         join c in _db.Customer on t.CustomerID equals c.CustomerID
                         join a in _db.Address on c.CustomerID equals a.CustomerID
                         where t.TokenID == token
                         select a;
            return result.ToList();
        }

        public List<Model.Address> GetAll()
        {
            return _db.Address.ToList();
        }

        //更新地址

        public void Update(int id, Model.Address obj)
        {
            var aa = _db.Address.Where(x => x.CustomerID == obj.CustomerID);
            if (obj.IsDefault.Value)
            {
                foreach (var item in aa)
                {
                    item.IsDefault = false;
                }
            }

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
