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
   public class MyAccountRepository: BaseRepository<AspNetUser>, IMyAccountRepository
    {
        public MyAccountRepository(MsContext context):base(context)
        {

        }
    }
}
