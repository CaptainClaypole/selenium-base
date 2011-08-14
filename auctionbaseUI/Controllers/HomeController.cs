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
            var vehicles = GetAllVehicles();

            //ViewBag.ListVehicles = vehicles;
            //ViewBag.MyName = "Jonny Boy Clayton";
            //ViewBag.DateTime = new DateTime(1980, 2, 1);


            //return View(vehicles);
            return View(vehicles);
        }

        private List<tblVehicle> GetAllVehicles()
        {
            // return all the vehicles in the vehicles table.  Sort by vehicle make.

            return _repo.Vehicles
                .OrderBy(a => a.Vehicle_Make)
                .ToList();

        }

    }
}
