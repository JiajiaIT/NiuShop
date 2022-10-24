using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Principal;

namespace DAL
{
    public class D_Tokens : ITokens
    {
        nd20002Entities _db;


        public D_Tokens()
        {
            _db = new nd20002Entities();
        }

        public bool CheckToken(string token)
        {
            var data = _db.Tokens.Where(x => x.TokenID == token && x.OutTime > DateTime.Now);

            if (data.Count() > 0)
            {
                //将用户ID保存起来   
                string id = data.First().CustomerID.ToString();
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(id), null);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCustomerIDByToken(string token)
        {
            var data = _db.Tokens.Find(token);
            return data != null ? data.CustomerID.Value : 0;
        }

        void IBase<Tokens>.Add(Tokens obj)
        {
            _db.Tokens.Add(obj);
        }

        void IBase<Tokens>.Delete(int id)
        {
            _db.Tokens.Remove(_db.Tokens.Find(id));
            _db.SaveChanges();
        }

        Tokens IBase<Tokens>.FindById(int id)
        {
            return _db.Tokens.Find(id);
        }

        List<Tokens> IBase<Tokens>.GetAll()
        {
            return _db.Tokens.ToList();
        }

        void IBase<Tokens>.Update(int id, Tokens obj)
        {
            var data = _db.Tokens.Find(id);
            data.TokenID = obj.TokenID;
            data.CustomerID = obj.CustomerID;
            data.OutTime = obj.OutTime;
            _db.SaveChanges();
        }
    }
}
