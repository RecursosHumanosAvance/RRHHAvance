using RecursosHumanosPRO.Models;
using RecursosHumanosPRO.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RecursosHumanosPRO.Controllers
{
    public class HorasExtrasController : Controller
    {
        // GET: HorasExtras
        RecursosHumanosEntities2 db2 = new RecursosHumanosEntities2();
        public ActionResult HorasExtras()
        {
            List<ListaHorasExtras> lst;
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {

                lst = (from d in db.HorasExtras
                       select
                     new ListaHorasExtras
                     {
                         IdHorasExtras=d.IdHorasExtras,
                         IdEmpleado = d.IdEmpleado,
                         TablaHora = d.TablaHora,
                         PrecioHora = d.PrecioHora
                     }).ToList();

            }
            return View(lst);
        }

        public ActionResult InsertarHorasExtras()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarHorasExtras(TablaHorasExtras model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oEmpresa = new HorasExtras();
                        oEmpresa.IdEmpleado = model.IdEmpleado;
                        oEmpresa.TablaHora = model.TablaHora;
                        oEmpresa.PrecioHora = model.PrecioHora;

                        db.HorasExtras.Add(oEmpresa);
                        db.SaveChanges();
                    }
                    return Redirect("~/HorasExtras/HorasExtras");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        //
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var departamento = db2.HorasExtras.Find(id);
            TablaHorasExtras departamento1 = new TablaHorasExtras()
            {
                IdHorasExtras = departamento.IdHorasExtras,
                IdEmpleado = departamento.Empleados.IdEmpleado,
                TablaHora = departamento.TablaHora,
                PrecioHora = departamento.PrecioHora
            };
            if (departamento == null)
            {
                return HttpNotFound();
            }
            // ViewBag.IdEmpresa = new SelectList(db2.Empresa, "IdEmpresa", "Nombre", departamento1.Idempresa);
            return View(departamento1);
        }
        [HttpPost]
        public ActionResult Editar(TablaHorasExtras model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oDepa = db.HorasExtras.Find(model.IdHorasExtras);
                        oDepa.IdEmpleado = model.IdEmpleado;
                        oDepa.TablaHora = model.TablaHora;
                        oDepa.PrecioHora = model.PrecioHora;
                        db.Entry(oDepa).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/HorasExtras/HorasExtras");
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
                var oEmpresa = db.HorasExtras.Find(id);
                db.HorasExtras.Remove(oEmpresa);
                db.SaveChanges();
            }
            return Redirect("~/HorasExtras/HorasExtras");

        }
    }
}