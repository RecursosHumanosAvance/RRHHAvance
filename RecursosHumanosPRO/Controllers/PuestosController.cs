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
    public class PuestosController : Controller
    {
        RecursosHumanosEntities2 db2 = new RecursosHumanosEntities2();
        public ActionResult Puestos()
        {
            List<ListaPuestos> lst;
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {

                lst = (from d in db.Puestos
                       select
                     new ListaPuestos
                     {
                         IdPuesto = d.IdPuesto,
                         NombrePuesto=d.NombrePuesto,
                         Descripcion=d.Descripcion,
                         NombreDepartamento = d.Departamentos.NombreDepartamento,
                     }).ToList();

            }
            return View(lst);
        }

        public ActionResult InsertarPuestos()
        {

            ViewBag.IdDepartamentos= new SelectList(db2.Departamentos, "IdDepartamentos", "NombreDepartamento");

            return View();
        }
        [HttpPost]
        public ActionResult InsertarPuestos(TablaPuestos model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oPuesto = new Puestos();
                        oPuesto.NombrePuesto = model.NombrePuesto;
                        oPuesto.IdDepartamentos = model.IdDepartamentos;
                        oPuesto.Descripcion = model.Descripcion;
                        db.Puestos.Add(oPuesto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Puestos/Puestos");
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
            var departamento = db2.Puestos.Find(id);
            TablaPuestos departamento1 = new TablaPuestos()
            {

                
                NombrePuesto = departamento.NombrePuesto,
                IdPuesto= departamento.IdPuesto,
                Descripcion=departamento.Descripcion,
                IdDepartamentos= departamento.Departamentos.IdDepartamentos
            };
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamentos = new SelectList(db2.Departamentos, "IdDepartamentos", "NombreDepartamento", departamento1.IdDepartamentos);
            return View(departamento1);
        }
        [HttpPost]
        public ActionResult Editar(TablaPuestos model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oDepa = db.Puestos.Find(model.IdPuesto);
                        oDepa.NombrePuesto = model.NombrePuesto;
                        oDepa.IdDepartamentos = model.IdDepartamentos;
                        oDepa.Descripcion= model.Descripcion;

                        db.Entry(oDepa).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Puestos/Puestos");
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
                var oPues = db.Puestos.Find(id);
                db.Puestos.Remove(oPues);
                db.SaveChanges();
            }
            return Redirect("~/Puestos/Puestos");

        }
    }
}