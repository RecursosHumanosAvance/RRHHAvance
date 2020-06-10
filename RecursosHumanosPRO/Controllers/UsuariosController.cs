using RecursosHumanosPRO.Models;
using RecursosHumanosPRO.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecursosHumanosPRO.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Usuarios()
        {
            List<ListaUsuarios> lst;
            using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
            {

                lst = (from d in db.Usaurios
                       select
                     new ListaUsuarios
                     {
                         Idusuario = d.Idusuario,
                         Nombre = d.Nombre,
                         Apellidos = d.Apellidos,
                         Direccion = d.Direccion,
                         Sexo=d.Sexo,
                         Telefono = d.Telefono,
                         Estado=d.Estado,
                         Usuario=d.usuario,
                         Pass=d.pass
                         
                     }).ToList();

            }
            return View(lst);
        }

        public ActionResult InsertarUsuarios()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarUsuarios(TablaUsuarios model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (RecursosHumanosEntities2 db = new RecursosHumanosEntities2())
                    {

                        var oUS = new Usaurios();
                        oUS.Nombre = model.Nombre;
                        oUS.Apellidos = model.Apellidos;
                        oUS.Direccion = model.Direccion;
                        oUS.Sexo = model.Sexo;
                        oUS.Telefono = model.Telefono;
                        oUS.Estado = model.Estado;
                        oUS.usuario= model.Usuario;
                        oUS.pass = model.Pass;

                        db.Usaurios.Add(oUS);
                        db.SaveChanges();
                    }
                    return Redirect("~/Usuarios/Usuarios");
                }
                return View(model);

            }
            catch (Exception ex)
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