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
            var vehicles = GetModels(model);

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


        private List<tblHtmlRow> GetModels(string vehicleModel) {

            int latestSession = GetLatestSearchSession();

            var query = from v in _myRepo.Vehicles
                        from h in v.tblHtmlRows 
                        
                        where v.Vehicle_Model == vehicleModel && h.Search_Session_ID_fk == latestSession
                        select h;

            return query
                .OrderBy(s => s.html_row_id_PK)
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
      


        private int GetLatestSearchSession() {
            var sessionQuery = (from m in _myRepo.SearchSessions
                                orderby m.Search_Session_ID_PK descending
                                select m.Search_Session_ID_PK)
                         .FirstOrDefault();

            return sessionQuery;
        }

    }
}
