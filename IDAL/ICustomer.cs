using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface ICustomer:IBase<Customer>
    {
        //前台客户登录(通过登录交换出token、账户既可以是手机也可以是邮箱也可以是用户名)
        string Login(string account, string password);
        
    }
}
