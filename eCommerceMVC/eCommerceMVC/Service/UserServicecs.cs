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
                unitofwork.Dispose();
                string temppassword = tempuser[0].Password;
                if (temppassword == password) return true;
                else return false;
            }
        }
        public void register(string username, string password, string email) {
            using (var unitofwork = new UnitofWork(new JooleEntities())) {
                User tempuser = new User();
                tempuser.UserName = username;
                tempuser.Password = password;
                tempuser.Email = email;
                tempuser.RoleDescription = "Customer";
                tempuser.UserRoleId = 2;
                unitofwork.UserRepository.Insert(tempuser);
                unitofwork.Save();
            }
        }
        //public void deletemember(string username) {
        //    using (var unitofwork = new UnitofWork(new JooleEntities())) {
        //        List
        //    }
        //}
    }


}

