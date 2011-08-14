using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auctionbaseUI.Models;

namespace auctionbaseUI.Controllers
{
    public class HtmlController : Controller
    {
        //
        // GET: /Html/

        private IMyRepo _repo;

        public HtmlController (IMyRepo repo)
        {
            this._repo = repo;
        }

        public ActionResult Index()
        {
            var htmlList = GetAllHtmls();

            return View(htmlList);
        }


        private List<tblHtml> GetAllHtmls() {
            // return all the vehicles in the vehicles table.  Sort by vehicle make.
           
            // get the highest session count id for most recent.
            var sessionQuery = ((from m in _repo.SearchSessions
                                 orderby m.Search_Session_ID_PK descending )
                                 select m.Search_Session_ID_PK).FirstOrDefault();
            

            return _repo.Htmls.Where(a => a.Search_Session_ID_fk == sessionQuery)
                .OrderBy(s => s.html_id_pk)
                .ToList();

        }

    }
}
