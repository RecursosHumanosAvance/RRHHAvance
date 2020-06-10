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
    public class VacacionesController : Controller
    {
        // GET: Vacaciones
        RecursosHumanosEntities2 db2 = new RecursosHumanosEntities2();
        //public ActionResult Vacaciones()
        //{
        //    List<ListaVaca> lst;
        //    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
        //    {

        //        lst = (from d in db.Vacaciones
        //               select
        //             new ListaVaca
        //             {
        //                 IdVacaciones = d.IdVacaciones,
        //                 desde = d.desde,
        //                 hasta = d.hasta,
        //                 IdContrato


        //             }).ToList();

        //    }
        //    return View(lst);
        //}

        public ActionResult InsertarVaca(int? id)
        {
            if(id == null)
            {
                return View();
            }
            else
            {
                TablaVaca model = new TablaVaca();
                var vacacion = db2.Contratos.Find(id);
                model.IdContrato = vacacion.IdContrato;
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult InsertarVaca(TablaVaca model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oPuesto = new Vacaciones();
                        oPuesto.IdVacaciones = model.IdVacaciones;
                        oPuesto.desde = model.desde;
                        oPuesto.hasta = model.hasta;
                        oPuesto.IdContrato = model.IdContrato;
                        db.Vacaciones.Add(oPuesto);
                        db.SaveChanges();
                    }
                    return Redirect("~/Empleados/Empleados");
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
            var departamento = db2.Departamentos.Find(id);
            TablaDepartamento departamento1 = new TablaDepartamento()
            {
                IdDepartamento = departamento.IdDepartamentos,
                NombreDepa = departamento.NombreDepartamento,
                Idempresa = departamento.Empresa.IdEmpresa
            };
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db2.Empresa, "Idempresa", "Nombre", departamento1.Idempresa);
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

                        var oPues = db.Puestos.Find(model.IdPuesto);
                        oPues.NombrePuesto = model.NombrePuesto;
                        oPues.IdDepartamentos = model.IdDepartamentos;
                        oPues.Descripcion = model.Descripcion;
                        db.Entry(oPues).State = System.Data.Entity.EntityState.Modified;
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
                var oPues = db.Vacaciones.Find(id);
                db.Vacaciones.Remove(oPues);
                db.SaveChanges();
            }
            return Redirect("~/Empleados/Empleados");

        }
    }
}