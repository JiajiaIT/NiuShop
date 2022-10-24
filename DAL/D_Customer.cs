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
    public class D_Customer : ICustomer
    {
        nd20002Entities _db;
        public D_Customer()
        {
            _db = new nd20002Entities();
        }
        public void Add(Model.Customer obj)
        {
            _db.Customer.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Customer.Remove(_db.Customer.Find(id));
            _db.SaveChanges();
        }

        public Model.Customer FindById(int id)
        {
            return _db.Customer.Find(id);
        }

        public List<Model.Customer> GetAll()
        {
            return _db.Customer.ToList();
        }

        public string Login(string account, string password)
        {
            var result = _db.Customer.Where(x => (x.CustomerName == account && x.CustomerPWD == password) || (x.Tel == account && x.CustomerPWD == password) || (x.Email == account && x.CustomerPWD == password));

            //用户名或密码不正确
            if (result.Count() == 0)
                return "0";

            var data = _db.Tokens.Where(x => x.CustomerID == result.FirstOrDefault().CustomerID && x.OutTime > DateTime.Now);

            //过期或不存在token
            if (data.Count() > 0)
            {
                _db.Tokens.RemoveRange(data.ToList());
                _db.SaveChanges();
            }

            //新建一个token
            var newtoken = _db.Tokens.Add(new Tokens
            {
                CustomerID = result.First().CustomerID,
                OutTime = DateTime.Now.AddDays(1),
                TokenID = Guid.NewGuid().ToString()
            });
            _db.SaveChanges();
            //返回token
            return newtoken.TokenID;


        }

        public void Update(int id, Model.Customer obj)
        {
            var data = _db.Customer.Find(id);
            data.CustomerName = obj.CustomerName;
            data.CustomerPWD = obj.CustomerPWD;
            data.Tel = obj.Tel;
            data.Email = obj.Email;
            _db.SaveChanges();
        }
    }
}
