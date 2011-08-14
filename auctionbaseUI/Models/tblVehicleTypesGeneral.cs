using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace auctionbaseUI.Models {

    [MetadataType(typeof(GeneralTypesMetaData))]  
   
    public partial class tblVehicleTypeGeneral {

        public class GeneralTypesMetaData
        {
            public object VehicleTypeGeneral_pk { get; set; }
            public object VehicleTypeGeneral { get; set; }
        }
    }
}