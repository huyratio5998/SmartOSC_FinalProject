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
    public class UserRepository : BaseRepository<AspNetUser>, IUserRepository
    {
        public UserRepository(MsContext context) : base(context)
        {

        public AspNetUser Add(AspNetUser item, string Role, string Pass)
        {
            var store = new UserStore<AspNetUser>(_context);
            var manager = new UserManager<AspNetUser>(store);
            item.Id = Guid.NewGuid().ToString();
            manager.Create(item, Pass);
            manager.AddToRole(item.Id, Role);
            return item;
        }
    }
}
