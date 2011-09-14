using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auctionbaseUI.Models;

namespace auctionbaseUI.Controllers
{
    public class HomeController : Controller
    {
      

        private IMyRepo _repo;
        public HomeController(IMyRepo repo)
        {
            _repo = repo;
        }
      
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // Get all Vehicles
            var vehicleData = new WelcomeViewData();
            vehicleData.vehicleModels = GetAllVehicles();
            
            vehicleData.vehicleDefinedTypes = GetAllVehiclesDefined();
            vehicleData.selectList = BuildModelsSelectList();
            
         //   var vehicles = GetAllVehicles();

            //ViewBag.ListVehicles = vehicles;
            //ViewBag.MyName = "Jonny Boy Clayton";
            //ViewBag.DateTime = new DateTime(1980, 2, 1);

           // var vehiclesDefined = GetAllVehiclesDefined();



            //return View(vehicles);
            return View(vehicleData);
        }

        private IEnumerable<SelectListItem> BuildModelsSelectList()
        {

            var vehicles = GetAllVehicles();

            IEnumerable<SelectListItem> selectList =
                from v in vehicles
                select new SelectListItem()
                           {
                               Text = v.Vehicle_Model,
                               Value = v.Vehicle_Model
                           };

            return selectList;

        }

        [Authorize]
        public ActionResult Welcome() {
            return View();
        }

        private List<tblVehicle> GetAllVehicles()
        {
            // return all the vehicles in the vehicles table.  Sort by vehicle make.

            return _repo.Vehicles
                .OrderBy(a => a.Vehicle_Make)
                .ToList();

        }

        private List<tblVehicleTypeDefined> GetAllVehiclesDefined() {
            // return all the vehicles in the vehicles table.  Sort by vehicle make.

            return _repo.DefinedTypes
                //.OrderBy(a => a.Vehicle_Make)
                .ToList();

        }

    }
}
