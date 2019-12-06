using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            List<PersonaViewModel> lst;
            using (CrudDBEntities db= new CrudDBEntities() )
            {
                 lst = (from d in db.Personas
                           select new PersonaViewModel
                           {
                               Id = d.Id,
                               Nombre = d.Nombre,
                               Correo = d.Correo
                           }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Nuevo( NuevoPersonaViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (CrudDBEntities db = new CrudDBEntities())
                    {
                        var oPersona = new Personas();
                        oPersona.Nombre = model.Nombre;
                        oPersona.Correo = model.Correo;

                        db.Personas.Add(oPersona);
                        db.SaveChanges();
                    }
                return Redirect("~/Personas/");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(long Id)
        {
            PersonaViewModel model = new PersonaViewModel();

            using (CrudDBEntities db = new CrudDBEntities())
            {
                var oPersona = db.Personas.Find(Id);
                model.Nombre = oPersona.Nombre;
                model.Correo = oPersona.Correo;
                model.Id = oPersona.Id;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(NuevoPersonaViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (CrudDBEntities db = new CrudDBEntities())
                    {
                        var oPersona = db.Personas.Find(model.Id);
                        oPersona.Nombre = model.Nombre;
                        oPersona.Correo = model.Correo;

                        db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Personas/");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(long Id)
        {
            PersonaViewModel model = new PersonaViewModel();

            using (CrudDBEntities db = new CrudDBEntities())
            {
                var oPersona = db.Personas.Find(Id);
                db.Personas.Remove(oPersona);
                db.SaveChanges();
            }

            return Redirect("~/Personas/");
        }
    }
}