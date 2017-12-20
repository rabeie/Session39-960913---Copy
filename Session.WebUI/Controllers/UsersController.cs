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
    public class UsersController : Controller
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
                ctx.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
                if (string.IsNullOrEmpty(user.PasswordHash))
                    ctx.Entry<User>(user).Property(nameof(user.PasswordHash)).IsModified = false;
                ctx.SaveChanges();
                TempData["Message"] = "کارمند مورد نظر با موفقیت ویرایش شد";
                return RedirectToAction("Index");
          
        }

        //// GET: Users/Delete/5
        //public ActionResult Delete(int? id)
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

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var user = ctx.People.Find(id);
        //    ctx.People.Remove(user);
        //    ctx.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
