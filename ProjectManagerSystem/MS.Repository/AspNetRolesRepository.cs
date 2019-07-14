using Microsoft.AspNet.Identity.EntityFramework;
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
    public class AspNetRolesRepository : BaseRepository<IdentityRole>, IAspNetRolesRepository
    {
        public AspNetRolesRepository(MsContext context) : base(context)
        {

        }
    }
    
}
