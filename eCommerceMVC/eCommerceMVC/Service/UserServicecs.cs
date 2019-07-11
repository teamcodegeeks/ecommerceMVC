using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerceMVC.Models;
using eCommerceMVC.Repository;
using eCommerceMVC.UoW;

namespace eCommerceMVC.Service
{
    public class UserServicecs
    {
        public bool Login(string username, string password) {
            using (var unitofwork = new UnitofWork(new JooleEntities())) {
                List<User> tempuser = unitofwork.UserRepository.Get(
                    filter: u => u.UserName == username
                    ).ToList();
                string temppassword = tempuser[0].Password;
                if (temppassword == password) return true;
                else return false;
            }
        }
    }


}

