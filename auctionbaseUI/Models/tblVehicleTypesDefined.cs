using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace auctionbaseUI.Models {

    [MetadataType(typeof(DefinedTypesMetaData))]  
   
    public partial class tblVehicleTypeDefined {

        public class DefinedTypesMetaData
        {
            public object VehicleTypeDefined_id_pk { get; set; }
            public object VehicleTypeDefined { get; set; }
        }
    }
}