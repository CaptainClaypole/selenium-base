using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auctionbaseUI.Models {
    public class MyRepo : IMyRepo
    {

        public IQueryable<tblVehicle> Vehicles
        {
            get { return seleniumScrapeEntities.Current.tblVehicles; }
        }

        public IQueryable<tblHtml> Htmls
        {
            get { return seleniumScrapeEntities.Current.tblHtmls; }
        }

        public IQueryable<tblSearchSession> SearchSessions
        {
            get { return seleniumScrapeEntities.Current.tblSearchSessions; }
        }

        public IQueryable<tblVehicleTypeGeneral> GeneralTypes
        {
            get { return seleniumScrapeEntities.Current.tblVehicleTypeGenerals; }
        }

        public IQueryable<tblVehicleTypeDefined> DefinedTypes
        {
            get { return seleniumScrapeEntities.Current.tblVehicleTypeDefineds; }
        }

        public IQueryable<HTMLVehicle> GetLiteaceTownace
        {
            get { var db = seleniumScrapeEntities.Current;
                var vehicles = from v in db.tblVehicles
                               from h in v.tblHtmls
                               where v.Vehicle_Model == "TOWN ACE TRUCK" || v.Vehicle_Model == "LITE ACE TRUCK"
                               select new HTMLVehicle()
                                          {
                                              htmlData = h.html_data,
                                              Vehicle_Make = v.Vehicle_Make,
                                              Vehicle_Model = v.Vehicle_Model

                                          };
                return vehicles;
            }
        }

       

        public void Add<T>(T item) {
            seleniumScrapeEntities.Current.AddObject(GetSetName<T>(), item);
        }
        public void Delete<T>(T item) {
            seleniumScrapeEntities.Current.DeleteObject(item);
        }
        public void SaveChanges() {
            seleniumScrapeEntities.Current.SaveChanges();
        }


        public string GetSetName<T>() {

            //If you get an error here it's because your namespace
            //for your EDM doesn't match the partial model class
            //to change - open the properties for the EDM FILE and change "Custom Tool Namespace"
            //Not - this IS NOT the Namespace setting in the EDM designer - that's for something
            //else entirely. This is for the EDMX file itself (r-click, properties)

            var entitySetProperty =
               
            seleniumScrapeEntities.Current.GetType().GetProperties()
               .Single(p => p.PropertyType.IsGenericType && typeof(IQueryable<>)
               .MakeGenericType(typeof(T)).IsAssignableFrom(p.PropertyType));

            return entitySetProperty.Name;
        }
    }
}