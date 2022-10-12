using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAdmins:IBase<Admins>
    {
        Admins CheckUser(string username, string password);
    }
}
