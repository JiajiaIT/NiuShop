using Factory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class B_Tokens : ITokens
    {
        public void Add(Tokens obj)
        {
            CreateFactory.GetTokens().Add(obj);
        }

        public bool CheckToken(string token)
        {
            return CreateFactory.GetTokens().CheckToken(token);
        }

        public void Delete(int id)
        {
            CreateFactory.GetTokens().Delete(id);
        }

        public Tokens FindById(int id)
        {
            return CreateFactory.GetTokens().FindById(id);
        }

        public List<Tokens> GetAll()
        {
            return CreateFactory.GetTokens().GetAll();
        }

        public int GetCustomerIDByToken(string token)
        {
            return CreateFactory.GetTokens().GetCustomerIDByToken(token);
        }

        public void Update(int id, Tokens obj)
        {
            CreateFactory.GetTokens().Update(id, obj);
        }
    }
}
