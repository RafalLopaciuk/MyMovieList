using MyMovieListBeta_withWCF.MoviesServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieListBeta_withWCF.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            try
            {
                using (ServiceMoviesClient spc = new ServiceMoviesClient())
                {

                List<Movies> list = spc.MyList().ToList();

                    return View(list);
                }
            }
            catch (Exception e)
            {
                return Content("Exception found during connecting: <br>" + e);
            }
        }
    }
}