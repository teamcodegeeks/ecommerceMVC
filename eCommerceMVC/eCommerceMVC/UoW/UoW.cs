using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerceMVC.Models;
using eCommerceMVC.Repository;

namespace eCommerceMVC.UoW
{
    public class UnitofWork:IDisposable
    {
        private JooleEntities dbcontext;
        private static UserRepository userrepository;
        public UnitofWork(JooleEntities dbcontext) {
            this.dbcontext = dbcontext;
        }
        
        public UserRepository UserRepository
        {
            get {
                if (userrepository == null) {
                    userrepository = new UserRepository(dbcontext);
                }
                return userrepository;
            }
        }
        public void Save() {
            dbcontext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing) {
            if (!this.disposed)
                if (disposing)
                    dbcontext.Dispose();
            this.disposed = true;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
    }
}