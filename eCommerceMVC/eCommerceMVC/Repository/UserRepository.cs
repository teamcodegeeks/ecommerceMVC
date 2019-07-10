using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using eCommerceMVC.Models;
using System.Linq.Expressions;
using eCommerceMVC.Repository;

namespace eCommerceMVC.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private JooleEntities _dbcontext;
        private DbSet<User> dbset;
        public UserRepository(JooleEntities dbcontext) : base(dbcontext) {
            this._dbcontext = dbcontext;
            this.dbset = _dbcontext.Set<User>();
        }
    }
}