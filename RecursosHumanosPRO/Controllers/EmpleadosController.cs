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
    public class EmpleadosController : Controller
    {

        // GET: Departamento
        RecursosHumanosEntities2 db2 = new RecursosHumanosEntities2();
        public ActionResult Empleados()
        {
            List<ListaEmpleados> lst;
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {
                
                lst = (from d in db.Empleados
                       select
                     new ListaEmpleados
                     {
                         IdEmpleado = d.IdEmpleado,
                         Nombre = d.Nombre,
                         Apellido = d.Apellidos,
                         Direccion = d.Direccion,
                         Sexo = d.Sexo,
                         Telefono = d.Telefono,
                         Nit = d.Nit,
                         Estado = d.Estado,
                         Tipo = d.Tipo,
                         NombrePuesto = d.Puestos.NombrePuesto,
                        
                     }).ToList(); 

            }
            return View(lst);
        }

        public ActionResult InsertarEmpleados()
        {

            ViewBag.IdPuesto = new SelectList(db2.Puestos, "IdPuesto", "NombrePuesto");

            return View();
        }
        [HttpPost]
        public ActionResult InsertarEmpleados(TablaEmpleados model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oEmpl = new Empleados();
                        oEmpl.IdEmpleado = model.IdEmpleado;
                        oEmpl.Nombre = model.Nombre;
                        oEmpl.Apellidos = model.Apellido;
                        oEmpl.Direccion = model.Direccion;
                        oEmpl.Sexo = model.Sexo;
                        oEmpl.Telefono = model.Telefono;
                        oEmpl.Nit = model.Nit;
                        oEmpl.Estado = model.Estado;
                        oEmpl.Tipo = model.Tipo;
                        oEmpl.IdPuesto = model.IdPuesto;
                        db.Empleados.Add(oEmpl);
                        db.SaveChanges();
                        TempData["idempleado"] = oEmpl.IdEmpleado;

                    }
                    //return Redirect("~/Contrato/InsertarContrato");
                    return RedirectToAction("recibirEmpleado", new { Controller = "Contrato", Action = "recibirEmpleado" });

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
            var departamento = db2.Empleados.Find(id);
            TablaEmpleados departamento1 = new TablaEmpleados()
            {
                IdEmpleado = departamento.IdEmpleado,
            Nombre = departamento.Nombre,
            Apellido = departamento.Apellidos,
            Direccion = departamento.Direccion,
            Sexo = departamento.Sexo,
            Telefono = departamento.Telefono,
            Nit = departamento.Nit,
            Estado = departamento.Estado,
            Tipo = departamento.Tipo,
            IdPuesto = departamento.Puestos.IdPuesto
        };

            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPuesto = new SelectList(db2.Puestos, "IdPuesto", "NombrePuesto", departamento1.IdPuesto);
            return View(departamento1);
        }
        [HttpPost]
        public ActionResult Editar(TablaEmpleados model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {
           
                        var oDepa = db.Empleados.Find(model.IdEmpleado);
                        oDepa.Nombre= model.Nombre;
                        oDepa.Apellidos = model.Apellido;
                        oDepa.Direccion = model.Direccion;
                        oDepa.Sexo = model.Sexo;
                        oDepa.Telefono = model.Telefono;
                        oDepa.Nit = model.Nit;
                        oDepa.Estado = model.Estado;
                        oDepa.Tipo = model.Tipo;
                        oDepa.IdPuesto = model.IdPuesto;

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


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {
                var oEmpleado = db.Empleados.Find(id);
                db.Empleados.Remove(oEmpleado);
                db.SaveChanges();
            }
            return Redirect("~/Empleados/Empleados");

        }

        [HttpGet]
        public ActionResult GestionarContrato(int id)
        {
            var empleadoViewModel = new ListaGestionContrato();
            empleadoViewModel.Empleado = db2.Empleados.Find(id);
            empleadoViewModel.Contrato = db2.Contratos.SingleOrDefault(x => x.IdEmpleado == empleadoViewModel.Empleado.IdEmpleado);
            if (empleadoViewModel.Contrato != null)
            {
                empleadoViewModel.Vacaciones = db2.Vacaciones.Where(x => x.IdContrato == empleadoViewModel.Contrato.IdContrato).ToList();
            }

            return View(empleadoViewModel);

        }
    }

}