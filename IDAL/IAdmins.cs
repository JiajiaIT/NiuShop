﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IAdmins : IBase<Admins>
    {
        Admins Login(string adminname, string adminpwd);
    }
}
