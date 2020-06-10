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
    public class ContratoController : Controller
    {
        // GET: Contrato

        RecursosHumanosEntities2 db2 = new RecursosHumanosEntities2();

        public ActionResult recibirEmpleado()
        {
            ViewBag.iempleado = TempData["idempleado"];
            return View();
        }
        public ActionResult Contrato()
        {
            List<ListaContrato> lst;
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {

                lst = (from d in db.Contratos
                       select
                     new ListaContrato
                     {
                         IdContrato= d.IdContrato,
                         Nombre = d.Empleados.Nombre,
                         Salario= d.Salario,
                         JornadaLAboral = d.JornadaLAboral,
                         DiasdeDescanso = d.DiasdeDescanso,
                         

                     }).ToList();

            }
            return View(lst);
        }

        public ActionResult InsertarContrato()
        {

            return View();
        }
        [HttpPost]

    
        public ActionResult InsertarContrato(TablaContrato model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oPuesto = new Contratos();
                        oPuesto.IdEmpleado = model.IdEmpleado;
                        oPuesto.Salario = model.Salario;
                        oPuesto.JornadaLAboral = model.JornadaLAboral;
                        oPuesto.DiasdeDescanso = model.DiasdeDescanso;
                        oPuesto.Fecha_de_contrato = model.Fecha_de_contrato;
                        
                        db.Contratos.Add(oPuesto);
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
            var departamento = db2.Contratos.Find(id);
            TablaContrato departamento1 = new TablaContrato()
            {
                IdContrato = departamento.IdContrato,
                IdEmpleado = departamento.Empleados.IdEmpleado,
                Salario = departamento.Salario,
                JornadaLAboral = departamento.JornadaLAboral,
                DiasdeDescanso = departamento.DiasdeDescanso,
                Fecha_de_contrato = Convert.ToDateTime(departamento.Fecha_de_contrato)

            };
            if (departamento == null)
            {
                return HttpNotFound();
            }
            // ViewBag.IdEmpresa = new SelectList(db2.Empresa, "IdEmpresa", "Nombre", departamento1.Idempresa);
            return View(departamento1);

        }
      
           

        [HttpPost]
        public ActionResult Editar(TablaContrato model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oDepa = db.Contratos.Find(model.IdContrato);
                        oDepa.IdEmpleado = model.IdEmpleado;
                        oDepa.Salario = model.Salario;
                        oDepa.JornadaLAboral = model.JornadaLAboral;
                        oDepa.DiasdeDescanso = model.DiasdeDescanso;
                        oDepa.Fecha_de_contrato = model.Fecha_de_contrato;
                
                        db.Entry(oDepa).State = System.Data.Entity.EntityState.Modified;
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


      /*  [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {
                var oPues = db.Contratos.Find(id);
                db.Contratos.Remove(oPues);
                db.SaveChanges();
            }
            return Redirect("~/Empleados/GestionarContrato");

        }*/
    }
}