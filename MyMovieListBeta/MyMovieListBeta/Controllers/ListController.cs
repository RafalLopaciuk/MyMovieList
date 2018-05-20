using MyMovieListBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieListBeta.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            try { 
                using (MyMovieListDBEntities db = new MyMovieListDBEntities()) { 
                    var movies = (from d in db.Movies orderby d.Title select d).ToList();

                    ViewBag.Result = TempData["Result"];
                    ViewBag.Error = TempData["Error"];

                    return View(movies);
                }
            }
            catch (Exception e)
            {
                return Content("Exception found during connecting: <br>" + e);
            }
        }
    }
}