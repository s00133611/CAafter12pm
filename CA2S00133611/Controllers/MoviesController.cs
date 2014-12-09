using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CA2S00133611.Models;


namespace CA2S00133611.Controllers
{
    public class MoviesController : Controller
    {
         MovieDBContext db = new MovieDBContext();



        // GET: Movies
        public ActionResult Index(string movieGenre, string searchString, string movieActor)
        {
            


            //ViewBag.PageTitle = "List of Movies (Total " + db.Movies.Count() + "TotalMovies)";

            //return View(movieGenre.ToList());
            
            //// search an actor
            //var movieActlst = new List<string>();

            //var movieQry = from a in db.Movies
            //               orderby a.Actor
            //               select a.Actor;
            //movieActlst.AddRange(movieQry.Distinct());
            //ViewBag.movieActor = new SelectList(movieActlst);

            //var moviesact = from a in db.Movies
            //                select a;


            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    moviesact = moviesact.Where(s => s.MovieTitle.Contains(searchString));
            //}

            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    moviesact = moviesact.Where(x => x.Actor == movieActor);
            //}
            //trying to achieve a counter here something like what you did with camp kids
            //ViewBag.Title = "Details of " + movies.ToString();

            //return View(moviesact);

            // query was built already
            // search a genre

            //error created here Genrelst starts a count of 0 
            var GenreLst = new List<string>();
            // the it goes to genreqry which is at null
            
             var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieTitle.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            //trying to achieve a counter here something like what you did with camp kids
            //ViewBag.Title = "Details of " + movies.ToString();

            return View(movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //// GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MovieTitle,Actor,OnScreenName,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MovieTitle,Actor,OnScreenName,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //data added to contorller for partialview
        public PartialViewResult MoviesById(int id)
        {

            var movie = db.Movies.Find(id);
                @ViewBag.Details = movie.MovieTitle;
                return PartialView("_moviedetail", movie.ID);


        }


        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
