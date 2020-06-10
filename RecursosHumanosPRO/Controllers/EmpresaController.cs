using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecursosHumanosPRO.Models;
using RecursosHumanosPRO.Models.ViewModels;

namespace RecursosHumanosPRO.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Empresa()
        {
            List<ListaEmpresa> lst;
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2() )
            {

                 lst = (from d in db.Empresa
                           select
                         new ListaEmpresa
                         {
                             IdEmpresa = d.IdEmpresa,
                             Nombre = d.Nombre,
                             Telefono = d.Telefono,
                             Direccion = d.Direccion
                         }).ToList();

            }
                return View(lst);
        }

        public ActionResult InsertarEmpresa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarEmpresaT(TablaEmpresa model)
        {
            try {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oEmpresa = new Empresa();
                        oEmpresa.Nombre = model.Nombre;
                        oEmpresa.Telefono = model.Telefono;
                        oEmpresa.Direccion = model.Direccion;

                        db.Empresa.Add(oEmpresa);
                        db.SaveChanges();
                    }
                    return Redirect("~/Empresa/Empresa");
                }
                return View(model);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        //
        public ActionResult Editar(int id)
        {
            TablaEmpresa model = new TablaEmpresa();
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {
                var oEmpresa = db.Empresa.Find(id);
                model.Nombre = oEmpresa.Nombre;
                model.Telefono = oEmpresa.Telefono;
                model.Direccion = oEmpresa.Direccion;
                model.IdEmpresa = oEmpresa.IdEmpresa;
            }
                return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TablaEmpresa model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oEmpresa = db.Empresa.Find(model.IdEmpresa);
                        oEmpresa.Nombre = model.Nombre;
                        oEmpresa.Telefono = model.Telefono;
                        oEmpresa.Direccion = model.Direccion;

                        db.Entry(oEmpresa).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Empresa/Empresa");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
             using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {
                     var oEmpresa = db.Empresa.Find(id);
                     db.Empresa.Remove(oEmpresa);
                    db.SaveChanges();
                    }
         return Redirect("~/Empresa/Empresa");

        }
    }
}