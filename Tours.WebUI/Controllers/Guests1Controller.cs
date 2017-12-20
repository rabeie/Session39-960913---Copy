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
using Session.WebUI.ViewModels;

namespace Session.WebUI.Controllers
{
    public class Guests1Controller : Controller
    {
        private SessionDB ctx = new SessionDB();
       // private GuestwithCheck G = new GuestwithCheck();

        // GET: Guests
        public ActionResult Index(int? Id,string MeetingName)
        {
            //ViewModels.GuestwithCheck Guests = new ViewModels.GuestwithCheck();
            TempData["meetingId"] = Id;
            TempData["MeetingName"] = MeetingName;
            return View(ctx.Guests.ToList());
        }
        //[HttpPost]
        //public ActionResult Index(int? Id, string MeetingName)
        //{
        //    TempData["Title"] = MeetingName;
        //    TempData["meetingId"] = Id;
        //    if (!(ctx.Guests.Find(Id) is null))
        //    {
        //        return View(ctx.Guests.Find(Id));
        //    }
        //    return RedirectToAction("Create",Id);
        //}
        // GET: Guests/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Guest guest = ctx.Guests.Find(id);
        //    if (guest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(guest);
        //}

        // GET: Guests/Create
        public ActionResult Create()
        {
            //TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Guest guest)
        {
                ctx.Guests.Add(guest);
                ctx.SaveChanges();
                return RedirectToAction("Index");
        }

        public ActionResult Create2(int Id,IEnumerable<int> Guest)
        {
            
            // ctx.MeetingGuests.AddRange(GuestId);
            foreach (var item in Guest)
            {
                int guestid = item;
                //MeetingGuest mg = new MeetingGuest();
                //mg.MeetingId = Id;
                //mg.GuestId = item;
                //ctx.MeetingGuests.Add(mg);
            }
            //if (guest.Selected)
            //{ 
            //guest.MeetingId = Id;
            //ctx.Guests.Add(guest);
            //ctx.SaveChanges();
            //}
            return RedirectToAction("Index");
        }
        public ActionResult GuestChecked()
        {
            GuestwithCheck guest = new GuestwithCheck();
           
            return View();
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
        public ActionResult EditGuest(Guest guest)
        {
            var dbguest = ctx.Guests.Find(guest.Id);
           // dbguest.MeetingId =guest.MeetingId;
            ctx.SaveChanges();
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
