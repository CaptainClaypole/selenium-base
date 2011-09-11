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

        private int GetLatestSearchSession() {
            var sessionQuery = (from m in _myRepo.SearchSessions
                                orderby m.Search_Session_ID_PK descending
                                select m.Search_Session_ID_PK)
                         .FirstOrDefault();

            return sessionQuery;
        }

    }
}
