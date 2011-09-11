using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using auctionbaseUI.Models;

namespace auctionbaseUI.Models.Authentication {
    public class UserManager {

        private seleniumScrapeEntities ctx;

        public void Add(UserLoginViewModel user) {

            ctx = new seleniumScrapeEntities();

            var tblUserLogin = new tblUserLogin();

            tblUserLogin.tblUserLoginEmail = user.email;
            tblUserLogin.tblUserLoginName = user.userName;
            tblUserLogin.tblUserLoginPassword = user.password;

            ctx.tblUserLogins.AddObject(tblUserLogin);
            ctx.SaveChanges();


        
        }



    }
}