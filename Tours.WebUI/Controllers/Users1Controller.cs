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
    public class Users1Controller : Controller
    {
        private SessionDB ctx = new SessionDB();

        // GET: Users
        public ActionResult Index()
        {
            var users = ctx.Users.ToList();
            return View(users);
        }

        // GET: Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var user = ctx.People.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
                TempData["Message"] = "کارمند مورد نظر با موفقیت افزوده شد";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //// GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = ctx.Users.Find(id);
            return View(user);
        }

       
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            var dbuser = ctx.Users.Find(user.Id);
            dbuser.Name = user.Name;
            dbuser.Family = user.Family;
            dbuser.Post = user.Post;
            dbuser.NationalCode = user.NationalCode;
            dbuser.Username = user.Username;
            if (!string.IsNullOrEmpty(user.PasswordHash))
                dbuser.PasswordHash = user.PasswordHash;
            if (string.IsNullOrEmpty(user.PasswordHash))
                ctx.Entry<User>(dbuser).Property(nameof(dbuser.PasswordHash)).IsModified = false;
            //ctx.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();
                TempData["Message"] = "کارمند مورد نظر با موفقیت ویرایش شد";
                return RedirectToAction("Index");
          
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            //ToursDb ctx = new ToursDb();
            return View(ctx.Users.Find(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            //ToursDb ctx = new ToursDb();
            ctx.Users.Remove(ctx.Users.Find(id));
            ctx.SaveChanges();
            TempData["Message"] = "کارمند مورد نظر با موفقیت حذف شد";
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
