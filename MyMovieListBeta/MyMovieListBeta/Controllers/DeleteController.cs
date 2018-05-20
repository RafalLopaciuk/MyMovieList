using MyMovieListBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieListBeta.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public ActionResult Index(int id = 0)
        {
            if (id == 0 || id < 0)
            {
                return RedirectToAction("Index", "List");
            }

            try { 
                using (var db = new MyMovieListDBEntities())
                {
                    Movie search = db.Movies.Where(p => p.Id == id).FirstOrDefault();
                    db.Movies.Remove(search);
                    db.SaveChanges();
                }

                TempData["Result"] = "Successfully removed the movie";

                return RedirectToAction("Index", "List");
            }
            catch
            {
                TempData["Error"] = "Error during removing";

                return RedirectToAction("Index", "List");
            }
        }

    }
}