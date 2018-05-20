using MyMovieListBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovieListBeta.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "List");
            }

            using (var db = new MyMovieListDBEntities()) {
                var edit = db.Movies.Where(p => p.Id == id);
                Movie item = edit.FirstOrDefault();

                ViewBag.TitleError = TempData["TitleError"];

                return View(item);
            }
        }

        [HttpPost]
        public ActionResult Index(Movie model, HttpPostedFileBase imageFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["TitleError"] = "The title is required and can not exceed 100 characters";
                    return RedirectToAction("Index", model);
                }
                else
                {
                    using (var db = new MyMovieListDBEntities())
                    {

                        Movie test = new Movie();
                        test = (from c in db.Movies where c.Id == model.Id select c).FirstOrDefault();

                        test.Title = model.Title;

                        if (imageFile != null)
                        {
                            test.Poster = null;
                            test.Poster = new byte[imageFile.ContentLength];
                            imageFile.InputStream.Read(test.Poster, 0, imageFile.ContentLength);
                        }
                        test.ReleaseDate = model.ReleaseDate;
                        test.YourSeanceDate = model.YourSeanceDate;
                        test.Score = model.Score;
                        test.LastUpdate = DateTime.Now;
                        test.UpdateType = "Modified";

                        db.SaveChanges();

                        TempData["Result"] = "Successfully edited the movie";

                        return RedirectToAction("Index", "List");
                    }
                }
            }
            catch
            {
                ViewBag.Error = "SOME PROBLEM. PLEASE TRY AGAIN. ";
                return View(model.Id);
            }
        }
    }
}