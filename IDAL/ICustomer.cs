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
        /*前台客户登录
         * 1、通过登录交换出token；
         * 2、账户是手机/邮箱/用户名
         * 3、正确时返回token，失败时返回错误原因*/
        string Login(string account, string password);
        
    }
}
