using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace auctionbaseUI.Models {


public class HTMLVehicle {



   
    public int Vehicle_ID_Pk { get; set; }
    
    public string Vehicle_Make { get; set; }
    
    public string Vehicle_Model { get; set; }
    
    public string htmlData { get; set; }

    public int htmlDataID { get; set; }



    }
}

//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;

//namespace MvcMusicStore.Models
//{
//    [MetadataType(typeof(AlbumMetaData))]
//    public partial class Album
//    {
//        // Validation rules for the Album class

//        [Bind(Exclude = "AlbumId")]
//        public class AlbumMetaData
//        {
//            [ScaffoldColumn(false)]
//            public object AlbumId { get; set; }

//            [DisplayName("Genre")]
//            public object GenreId { get; set; }

//            [DisplayName("Artist")]
//            public object ArtistId { get; set; }

//            [Required(ErrorMessage = "An Album Title is required")]
//            [StringLength(160)]
//            public object Title { get; set; }

//            [DisplayName("Album Art URL")]
//            [StringLength(1024)]
//            public object AlbumArtUrl { get; set; }

//            [Required(ErrorMessage = "Price is required")]
//            [Range(0.01, 100.00, ErrorMessage="Price must be between 0.01 and 100.00")]
//            public object Price { get; set; }
//        }
//    }
//}