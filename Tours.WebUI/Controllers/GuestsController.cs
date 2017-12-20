using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabieiMoeini;
using SessionModel;

namespace Session.WebUI.Controllers
{
    public class GuestsController : Controller
    {
        private SessionDB ctx = new SessionDB();

        // GET: Guests
        public ActionResult Index(int? Id, string MeetingName)
        {
            //ViewModels.GuestwithCheck Guests = new ViewModels.GuestwithCheck();
            TempData["meetingId"] = Id;
            
            TempData["MeetingName"] = MeetingName;
            return View(ctx.Guests.ToList().Distinct());
        }

        // GET: Guests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = ctx.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // GET: Guests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                ctx.People.Add(guest);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guest);
        }
        public ActionResult Create2(int Meeting_Id,Guest g)
        {
            g.MeetingId = Meeting_Id;
            ctx.Meetings.Find(Meeting_Id).Guests.Add(g);
            ctx.SaveChanges();
           
            return RedirectToAction("ManageGuest", "Meeting",new { meetingId = Meeting_Id });
        }

        // GET: Guests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = ctx.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(guest).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        // GET: Guests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = ctx.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest guest = ctx.Guests.Find(id);
            ctx.People.Remove(guest);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
