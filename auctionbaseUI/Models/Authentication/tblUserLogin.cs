using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auctionbaseUI.Models {
    public class tblUserLogin {

        public virtual int userId { get; set; }
        public virtual string userName { get; set; }
        public virtual string userEmail { get; set; }


        public tblUserLogin(int userId, string userName, string email) {

            this.userId = userId;
            this.userName = userName;
            this.userEmail = email;


        }

    }

}