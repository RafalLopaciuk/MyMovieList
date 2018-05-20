using MyMovieListBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieListBeta.Controllers
{
    public class AddController : Controller
    {
        public ActionResult Index()
        {
            Movie start = new Movie();

            return View(start);
        }

        [HttpPost]
        public ActionResult Index(Movie model, HttpPostedFileBase imageFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.TitleError = "The title is required and can not exceed 100 characters";
                    return View("Index", model);
                }
                else
                {
                    using (var db = new MyMovieListDBEntities()) { 
                        model.LastUpdate = DateTime.Now;
                        model.UpdateType = "Add";

                        if (imageFile != null)
                        {
                            model.Poster = new byte[imageFile.ContentLength];
                            imageFile.InputStream.Read(model.Poster, 0, imageFile.ContentLength);

                        }

                        db.Movies.Add(model);
                        db.SaveChanges();

                        TempData["Result"] = "Successfully added the movie";

                        return RedirectToAction("Index", "List");
                    }
                }
            }
            catch
            {
                ViewBag.Error = "SOME PROBLEM. PLEASE TRY AGAIN. ";
                return View(model);
            }
        }
    }
}