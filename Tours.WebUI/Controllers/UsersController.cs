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
using Session.WebUI.Library;

namespace Session.WebUI.Controllers
{
    public class UsersController : Controller
    {
        private SessionDB ctx = new SessionDB();

        // GET: Users
        [AuthorizeEmployee]
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
        //    User user = ctx.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Users/Create
        [AuthorizeEmployee]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        [AuthorizeEmployee]
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

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = ctx.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            var dbuser = ctx.Users.Find(user.Id);
            dbuser.Name = user.Name;
            dbuser.Family = user.Family;
            //dbuser.Post = user.Post;
            //dbuser.NationalCode = user.NationalCode;
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
           
            User user = ctx.Users.Find(id);
            
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
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
