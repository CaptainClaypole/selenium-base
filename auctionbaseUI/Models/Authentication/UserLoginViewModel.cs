using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace auctionbaseUI.Models {
    public class UserLoginViewModel {

        public UserLoginViewModel(string _userName, string _password, string _email) {
            
            this.email = _email;
            this.password = _password;
            this.userName = _userName;

        }

        
        public int userId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string email { get; set; }







    }
}