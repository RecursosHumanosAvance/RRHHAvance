using RecursosHumanosPRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecursosHumanosPRO.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                {
                    var lst = from d in db.Usaurios
                              where d.usuario == user && d.pass == password
                              select d;
                    if (lst.Count() > 0)
                    {

                        Session["User"] = lst.First();
                        return Redirect("~/Home/IndeXadmin");
                    }
                    else
                    {
                        return Redirect("~/Access/Index");
                    }
                }



            }
            catch (Exception ex)
            {
                return Content("Error " + ex.Message);

            }
        }
    }
}