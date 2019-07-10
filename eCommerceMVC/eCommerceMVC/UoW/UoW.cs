using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerceMVC.Models;
using eCommerceMVC.Repository;

namespace eCommerceMVC.UoW
{
    public class UoW
    {
        private JooleEntities dbcontext = new JooleEntities();
        private UserRepository userrepository;
        public UserRepository UserRepository
        {
            get {
                if (this.userrepository == null) {
                    this.userrepository = new UserRepository(dbcontext);
                }
                return userrepository;
            }
        }
    }
}