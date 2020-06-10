using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecursosHumanosPRO.Models;

namespace RecursosHumanosPRO.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usuario, string pass)
        {
        //    try
        //    {
        //       // using (Models.Model1 data = new Models.Model1)
        //        {
        //          var objUsuario = (from info in data.Usaurio
        //                             where info.usuario == usuario.Trim()
        //                             && info.pass == pass.Trim()
        //                             select info).FirtsOrDefault();
        //            if (objUsuario== null)
        //            {
        //                ViewBag.Error = "usuario y pass incorrectos";
        //                return View();
        //            }
        //            Session["Usuario"]= objUsuario;
        //        }
        //            return RedirectToAction("IbdeXadmin,Home ");
        //    }
        //    catch(Exception ex)
        //    {
        //        ViewBag.Error = ex.Message;
           return View();
          
        }
    }
}