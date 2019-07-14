﻿using Microsoft.AspNet.Identity.EntityFramework;
using MS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Repository.Interface
{
    public interface IAspNetUserRolesRepository : IBaseRepository<IdentityUserRole>
    {
    }

}
