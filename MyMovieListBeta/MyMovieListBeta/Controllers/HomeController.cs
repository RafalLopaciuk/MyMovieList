using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMovieListBeta.Models;

namespace MyMovieListBeta.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try { 
                using (MyMovieListDBEntities db = new MyMovieListDBEntities()) { 
                    var last = (from d in db.Movies orderby d.LastUpdate descending, d.Id descending select d).Take(3).ToList();

                    return View(last);
                }
            }
            catch (Exception e)
            {
                return Content("Exception found during connecting: <br>" + e);
            }
        }
    }
}