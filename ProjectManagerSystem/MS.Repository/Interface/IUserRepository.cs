﻿using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<AspNetUser>
    {
         AspNetUser Add(AspNetUser item, string Role, string Pass);
    }
}
