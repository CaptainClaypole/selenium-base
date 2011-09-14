using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auctionbaseUI.Models;

namespace auctionbaseUI.Controllers
{
    public class MainNavController : Controller
    {
        //
        // GET: /MainNav/

           private IMyRepo _myRepo;
        

        public MainNavController (IMyRepo myRepo)
        {

            this._myRepo = myRepo;

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Models(string model) {

            //var vehicles = GetAllDefinedTypeOfVehicles(type);
            var vehicles = GetAllVehicles(model);

            ViewBag.Data = model;


            return View(vehicles);
        }

        public ActionResult definedSearch (string type)
        {

            var vehicles = getVehiclesDefined(type);

            return View(vehicles);

        }

        private List<tblHtml> getVehiclesDefined(string vehicleModel) {
            int latestSession = GetLatestSearchSession();

            

            var query = from d in _myRepo.DefinedTypes
                        from v in d.tblVehicles
                        from h in v.tblHtmls
                        where d.VehicleTypeDefined == vehicleModel && h.Search_Session_ID_fk == latestSession
                        select h;

            return query
                .OrderBy(s => s.html_id_pk)
                .ToList();

        }


        private List<tblHtml> GetAllVehicles(string vehicleModel) {

            int latestSession = GetLatestSearchSession();

            var query = from v in _myRepo.Vehicles
                        from h in v.tblHtmls
                        
                        where v.Vehicle_Model == vehicleModel && h.Search_Session_ID_fk == latestSession
                        select h;

            return query
                .OrderBy(s => s.html_id_pk)
                .ToList();

        }

        private List<int> GetAllHtmlIds(string vehicleModel) {

            int latestSession = GetLatestSearchSession();

            var query = from v in _myRepo.Vehicles
                        from h in v.tblHtmls

                        where v.Vehicle_Model == vehicleModel && h.Search_Session_ID_fk == latestSession
                        select h.html_id_pk;

            return query.ToList();


        }
        // FIX THIS BIT NEXT.
        private List<tblHtmlRow> GetAllHtmlIds(List<int> htmlBatchList)
        {

            var htmlRows = new List<string>();

           
                var query = from h in _myRepo.Html
                            from r in h.tblHtmlRows
                            where r.html_data_id_fk == html_id 
                            select r.html_row_data;

                foreach (var htmlRow in query)
                {
                    htmlRows.Add(htmlRow);
                }
                htmlRows.Add()
            }
          

           

                       

                        
                        

            return query.ToList();


        }


        private int GetLatestSearchSession() {
            var sessionQuery = (from m in _myRepo.SearchSessions
                                orderby m.Search_Session_ID_PK descending
                                select m.Search_Session_ID_PK)
                         .FirstOrDefault();

            return sessionQuery;
        }

    }
}
