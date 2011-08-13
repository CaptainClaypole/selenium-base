using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using Ninject;


namespace auctionbaseUI.Models {
    public partial class seleniumScrapeEntities {
        public static seleniumScrapeEntities Current
        {
            get { return (seleniumScrapeEntities) MvcApplication.Container.Get<ObjectContext>(); }
        }
    }
}