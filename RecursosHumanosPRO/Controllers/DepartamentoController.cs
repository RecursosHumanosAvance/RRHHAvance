using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecursosHumanosPRO.Models;
using RecursosHumanosPRO.Models.ViewModels;

namespace RecursosHumanosPRO.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        RecursosHumanosEntities2 db2 = new RecursosHumanosEntities2();
        public ActionResult Departamento()
        {
            List<ListaDepartamento> lst;
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {

                lst = (from d in db.Departamentos
                       select
                     new ListaDepartamento
                     {
                         IdDepartamento = d.IdDepartamentos,
                         NombreDepartamento=d.NombreDepartamento,
                         NombreEmpresa = d.Empresa.Nombre,

                     }).ToList();

            }
            return View(lst);
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult InsertarDepartamento()
        {

         ViewBag.IdEmpresa = new SelectList(db2.Empresa, "Idempresa", "Nombre");

          return View();
        }
        [HttpPost]
        public ActionResult InsertarDepartamento(TablaDepartamento model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oDepartamento = new Departamentos();
                        oDepartamento.NombreDepartamento = model.NombreDepa;
                        oDepartamento.IdEmpresa= model.Idempresa;

                        db.Departamentos.Add(oDepartamento);
                        db.SaveChanges();
                    }
                    return Redirect("~/Departamento/Departamento");
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
            ViewBag.IdEmpresa = new SelectList(db2.Empresa, "IdEmpresa", "Nombre", departamento1.Idempresa);
            return View(departamento1);
        }
        [HttpPost]
        public ActionResult Editar(TablaDepartamento model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oDepa= db.Departamentos.Find(model.IdDepartamento);
                        oDepa.NombreDepartamento = model.NombreDepa;
                        oDepa.IdEmpresa= model.Idempresa;

                        db.Entry(oDepa).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Departamento/Departamento");
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
                var oDepa = db.Departamentos.Find(id);
                db.Departamentos.Remove(oDepa);
                db.SaveChanges();
            }
            return Redirect("~/Departamento/Departamento");

        }

    }
}