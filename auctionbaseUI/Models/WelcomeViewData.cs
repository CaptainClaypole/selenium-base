using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace auctionbaseUI.Models {
    public class WelcomeViewData
    {
        public List<tblVehicle> vehicleModels { get; set; }
        public List<tblVehicleTypeDefined> vehicleDefinedTypes { get; set; }
        public IEnumerable<SelectListItem> selectList { get; set; }
  
    }
}