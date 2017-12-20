using RabieiMoeini;
using SessionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Session.WebUI.Library
{
    public class SecurityHelper
    {
        public static User GetCurrentEmployee()
        {
            if (HttpContext.Current.Request.Cookies["UserId"] != null)
            {
                var userId = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
                HttpContext.Current.Session["UserId"] = userId;
            }

            if (HttpContext.Current.Session["UserId"] != null)
            {
                var userId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                SessionDB ctx = new SessionDB();
                var currentEmployee = ctx.Users.Find(userId);
                return currentEmployee;
            }
            else
            {
                return null;
            }
        }

        public static void Logout()
        {
            HttpContext.Current.Session["UserId"] = null;
            var cookie = HttpContext.Current.Request.Cookies["UserId"];
            if (cookie != null)
            {
                //HttpContext.Current.Request.Cookies.Remove("UserId");
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Set(cookie);
            }
        }
    }
}