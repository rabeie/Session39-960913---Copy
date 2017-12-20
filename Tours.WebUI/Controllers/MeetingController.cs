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
using System.IO;

namespace Session.WebUI.Controllers
{
    public class MeetingController : Controller
    {
        private SessionDB ctx = new SessionDB();

        // GET: Meeting
        public ActionResult Index()
        {
            return View(ctx.Meetings.ToList());
        }

        // GET: Meeting/Details/5
        public ActionResult Details(int? id)
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

        // GET: Meeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meeting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TItle,Date,StartTime,EndTime,Place,Explain")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                ctx.Meetings.Add(meeting);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meeting);
        }

        // GET: Meeting/Edit/5
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

        // POST: Meeting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TItle,Date,StartTime,EndTime,Place,Explain")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(meeting).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meeting);
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
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = ctx.Meetings.Find(id);
            ctx.Meetings.Remove(meeting);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ManageAttachments(int meetingId)
        {
            var Meeting = ctx.Meetings.Find(meetingId);
            ViewBag.MeetingId = meetingId;
            ViewBag.MeetingTitle = Meeting.TItle;
            return View(Meeting.Attachments.ToList());
        }
        public ActionResult CreateAttachment(int meetingId)
        {
            ViewBag.MeetingId = meetingId;
            return View();
        }

        [HttpPost]
        public ActionResult CreateAttachment(int meetingId, HttpPostedFileBase attachment)
        {
            var fileName = attachment.FileName;
            var extention = Path.GetExtension(fileName).ToLower();
            var fileSize = (attachment.ContentLength / 1024);
            if (fileSize > 1024)
            {
                ModelState.AddModelError("Attachment", "فایل ارسالی بزرگتر از سایز مجاز است(۱مگابایت)");
            }
            if (extention == ".exe")
            {
                ModelState.AddModelError("Attachment", "فایل اجرایی غیر مجاز است");
            }

            if (ModelState.IsValid)
            {
                Attachment att = new Attachment()
                {
                    OriginalFileName = fileName,
                    FileSize = fileSize,
                    MimeType = attachment.ContentType,
                    MeetingId = meetingId
                };
                //Convert Stream to Byte[]
                using (var inputStream = attachment.InputStream)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                    att.FileData = memoryStream.ToArray();
                }

                ctx.Attachments.Add(att);
                ctx.SaveChanges();
                return RedirectToAction("ManageAttachments", new { meetingId = meetingId });
            }
            return View();
        }

        public ActionResult DownloadAttachment(int id)
        {
            var attachment = ctx.Attachments.Find(id);


            return File(attachment.FileData, attachment.MimeType,
                attachment.OriginalFileName);
            //return File("~/Photos/MVC.docx", "application/octet-stream");
        }
        public ActionResult ManageGuest(int meetingId)
        {

            var Meeting = ctx.Meetings.Find(meetingId);
            ViewBag.MeetingId = meetingId;
            ViewBag.MeetingTitle = Meeting.TItle;
            return View(Meeting.Guests.ToList());
           // return View(ctx.Guests.Find(meetingId).Meetings.ToList());
        }
        //public ActionResult ShowGuest(int? meetingId)
        //{

        //    var Meeting = ctx.Meetings.Find(meetingId);
        //    ViewBag.MeetingId = meetingId;
        //    ViewBag.MeetingTitle = Meeting.TItle;
        //   // ctx.Guests.Find(meetingId).Meetings.ToList()
        //    return View(ctx.Guests.Find(meetingId).Meetings.ToList());
        //}
        public ActionResult CreateGuest(int? MeetingId)
        {
            ViewBag.MeetingId = MeetingId;
            return View();
        }
        [HttpPost]
        public ActionResult CreateGuest(Guest guest)
        {
            

            if (ModelState.IsValid)
            {
                ctx.Guests.Add(guest);
                ctx.SaveChanges();
                return RedirectToAction("ManageGuest", new { meetingId = guest.MeetingId });
            }
            return View();
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
