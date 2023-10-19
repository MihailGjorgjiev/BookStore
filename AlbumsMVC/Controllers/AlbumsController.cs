using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlbumsMVC.Models;

namespace AlbumsMVC.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Albums
        public ActionResult Index()
        {
            var books = db.Books.Include(a => a.Author).Include(a => a.Genre);
            if (User.IsInRole("Admin"))
            {
                return View(books.ToList());
            }
            return View("IndexAjax",books.ToList());
            
        }

       

        //na details da moze samo uloga User da pristapi
        //[Authorize(Roles ="User")]
        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Include(b=>b.Author).Include(b=>b.Genre).Where(b=>b.Id== id).FirstOrDefault();
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            var authors = db.Authors.ToList();
            ViewBag.Authors = authors;
            var genres = db.Genres.ToList();
            ViewBag.Genres = genres;
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GenreId,AuthorId,Title,Description,Price,BookImageUrl,Quantity")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var authors = db.Authors.ToList();
            ViewBag.Authors = authors;
            var genres = db.Genres.ToList();
            ViewBag.Genres = genres;
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var authors = db.Authors.ToList();
            ViewBag.Authors = authors;
            var genres = db.Genres.ToList();
            ViewBag.Genres = genres;
            return View(book);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GenreId,AuthorId,Title,Description,Price,BookImageUrl,Quantity")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var authors = db.Authors.ToList();
            ViewBag.Authors = authors;
            var genres = db.Genres.ToList();
            ViewBag.Genres = genres;
            return View(book);
        }

        // GET: Albums/Delete/5
       
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
