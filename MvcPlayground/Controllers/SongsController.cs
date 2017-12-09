using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcPlayground.Models;
using MvcPlayground.Helpers;

namespace MvcPlayground.Controllers
{
    public class SongsController : Controller
    {
        private SongsDbContext db = new SongsDbContext();

        // GET: Songs
        public ActionResult Index()
        {
            var songs = db.Songs.Include(s => s.Album).Include(s => s.File).Include(s => s.Genre);
            return View(songs.ToList());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title");
            ViewBag.FileId = new SelectList(db.Files, "Id", "Filename");
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlbumId,GenreId,Title,ReleaseDate,TrackNr,DiscNr,Rating,Comments,Lyrics,Cover")] Song song)
        {
            var file = Request.Files["FileId"];
            var cover = Request.Files["Cover"];
            bool fileErrors = false;

            // Note: Find a better way for validation
            if (file.ContentType.IndexOf("audio/") == -1 || cover.ContentType.IndexOf("image/") == -1)
            {
                fileErrors = true;
            }
            if (ModelState.IsValid && !fileErrors)
            {
                string filePath = FileHelper.SaveFile(file, "~/Content/Music");
                File dbFile = new File
                {
                    Filename = HttpUtility.UrlEncode(file.FileName),
                    Path = "/Content/Music",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    MimeType = file.ContentType,
                    Size = file.ContentLength
                };
                db.Files.Add(dbFile);
                db.SaveChanges();

                string path = FileHelper.SaveFile(cover, "~/Uploads/Covers");

                song.Cover = path;
                song.FileId = dbFile.Id;

                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title", song.AlbumId);
            ViewBag.FileId = new SelectList(db.Files, "Id", "Filename", song.FileId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", song.GenreId);
            return View(song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title", song.AlbumId);
            ViewBag.FileId = new SelectList(db.Files, "Id", "Filename", song.FileId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", song.GenreId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlbumId,GenreId,FileId,Title,ReleaseDate,Length,TrackNr,DiscNr,Rating,Comments,Lyrics,Cover,Downloads")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "Id", "Title", song.AlbumId);
            ViewBag.FileId = new SelectList(db.Files, "Id", "Filename", song.FileId);
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", song.GenreId);
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
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
