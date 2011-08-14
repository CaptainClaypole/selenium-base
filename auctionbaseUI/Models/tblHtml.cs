using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace auctionbaseUI.Models {
    public partial class tblHtml {

        public class HtmlMetaData
        {
            public int html_id { get; set; }
            public string html_data { get; set; }
            public int Vehicle_id_fk { get; set; }
            public DateTime Search_Date_Timestamp { get; set; }
            public int Search_Session_ID_fk { get; set; } 
        }
       
   
    }
}