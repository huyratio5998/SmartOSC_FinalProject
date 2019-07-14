﻿using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess;
using MS.DataAccess.Models;
using MS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository
{
    public class UserRoleRepository : BaseRepository<IdentityUserRole>, IUserRoleRepository
    {
        public UserRoleRepository(MsContext context) : base(context)
        {
        }
    }
}