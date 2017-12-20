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
    public class Meeting1Controller : Controller
    {
        private SessionDB ctx = new SessionDB();

        // GET: Meeting
        public ActionResult Index()
        {
            //نمایش لیست جلسات کاربر
            return View(ctx.Meetings.ToList());
        }

        // GET: Meeting/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Meeting meeting = ctx.Meetings.Find(id);
        //    if (meeting == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(meeting);
        //}

        // GET: Meeting/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
       
        public ActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                ctx.Meetings.Add(meeting);
                ctx.SaveChanges();
               
                return RedirectToAction("Index");
            }

            return View(meeting);
        }
        [HttpPost]
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = ctx.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

       
        [HttpPost]
        
        public ActionResult Edit(Meeting meeting)
        {
            
            ctx.Meetings.Attach(meeting);
            ctx.SaveChanges();
                
            TempData["Message"] = "جلسه مورد نظر با موفقیت ویرایش شد";
            return RedirectToAction("Index");
            
        }

        // GET: Meeting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = ctx.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meeting/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = ctx.Meetings.Find(id);
            ctx.Meetings.Remove(meeting);
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
