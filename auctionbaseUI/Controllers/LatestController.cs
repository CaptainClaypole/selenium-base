﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auctionbaseUI.Models;

namespace auctionbaseUI.Controllers
{
    public class LatestController : Controller
    {
        //
        // GET: /Latest/

        private IMyRepo _myRepo;
        private string _model = "HIACE VAN";

        public LatestController (IMyRepo myRepo)
        {

            this._myRepo = myRepo;

        }

        public ActionResult Index()
        {
          

            return View();
        }

        public ActionResult Hiace()
        {
            var hiace = GetAllVehicles(_model);

            ViewBag.Model = GetModel(_model);
              


            return View(hiace);
        }

        public ActionResult Vehicles(string model)
        {
            var vehicles = GetAllVehicles(model);
            ViewBag.Data = GetModel(model);

            return View(vehicles);

        }

        public ActionResult Astro()
        {
            var astro = GetAllVehicles("CHEVROLET ASTRO");

            ViewBag.Astro = "Chevrolet Astro";

            return View(astro);

        }


        public ActionResult DayVans()
        {
            var vehicles = GetAllTypeOfVehicles("Day Van");

            ViewBag.Type = "Day Vans";

            return View(vehicles);

        }


        public ActionResult Campers() {
            var vehicles = GetAllTypeOfVehicles("Camper");

            ViewBag.Type = "Camper Vans";

            return View(vehicles);

        }

        public ActionResult TownaceLiteace()
        {

            var vehicles = _myRepo.GetLiteaceTownace;

            var vehiclesList = vehicles.ToList();
            
            return View(vehiclesList);
        }

        public ActionResult Defined(string type)
        {

            //var vehicles = GetAllDefinedTypeOfVehicles(type);
            var vehicles = GetAllDefinedTypeOfVehicles_WithModels(type);

            ViewBag.Data = type;


            
                                                      
            //ViewBag.Data = 
           

            return View(vehicles);
        }


        private List<tblHtml> GetAllVehicles(string vehicleModel)
        {

            int latestSession = GetLatestSearchSession();

            var query = from v in _myRepo.Vehicles
                        from h in v.tblHtmls
                        where v.Vehicle_Model == vehicleModel && h.Search_Session_ID_fk == latestSession
                        select h;

            return query
                .OrderBy(s => s.html_id_pk)
                .ToList();

        }

        private List<tblHtml> GetAllDefinedTypeOfVehicles(string definedType) {
            int latestSession = GetLatestSearchSession();

            // remove percentage 20s and replace with normal space.
            definedType = RemoveSpacesFromParam(definedType);

            var query = from d in _myRepo.DefinedTypes
                        from v in d.tblVehicles
                        from h in v.tblHtmls
                        where d.VehicleTypeDefined == definedType && h.Search_Session_ID_fk == latestSession
                        select h;

            return query
                .OrderBy(s => s.html_id_pk)
                .ToList();
        }

        private List<HTMLVehicle> GetAllDefinedTypeOfVehicles_WithModels(string definedType) {
            int latestSession = GetLatestSearchSession();

            // remove percentage 20s and replace with normal space.
            //definedType = RemoveSpacesFromParam(definedType);

            var query = from d in _myRepo.DefinedTypes
                        from v in d.tblVehicles
                        from h in v.tblHtmls
                        where d.VehicleTypeDefined == definedType && h.Search_Session_ID_fk == latestSession
                        select new HTMLVehicle(){
                            htmlData = h.html_data,
                            Vehicle_Model = v.Vehicle_Model,
                            Vehicle_Make = v.Vehicle_Make,
                            htmlDataID = h.html_id_pk
                           
                        };

            

                                  

            return query
                .OrderBy(s => s.htmlDataID)
                .ToList();
        }

        private List<tblHtml> GetAllTypeOfVehicles(string vehicleType)
        {
            int latestSession = GetLatestSearchSession();

            var query = from g in _myRepo.GeneralTypes
                        from v in g.tblVehicles
                        from h in v.tblHtmls
                        where g.VehicleTypeGeneral == vehicleType && h.Search_Session_ID_fk == latestSession
                        select h;

            return query
                .OrderBy(s => s.html_id_pk)
                .ToList();
        }

        private string GetModel(string vehicleModel) {

            int latestSession = GetLatestSearchSession();

            var query = (from v in _myRepo.Vehicles
                        from h in v.tblHtmls
                        where v.Vehicle_Model == vehicleModel && h.Search_Session_ID_fk == latestSession
                        select v.Vehicle_Model).FirstOrDefault();

            return query;



        }

        private int GetLatestSearchSession()
        {
                    var sessionQuery = (from m in _myRepo.SearchSessions
                                 orderby m.Search_Session_ID_PK descending
                                             select m.Search_Session_ID_PK)
                                 .FirstOrDefault();

            return sessionQuery;
        }

        private string RemoveSpacesFromParam(string input)
        {
            string newInput = input.Replace("%20", " ");
            return newInput;
        }

    }
}
