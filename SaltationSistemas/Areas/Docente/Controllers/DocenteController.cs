using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaltationSistemas.Areas.Docente.Controllers
{
    public class DocenteController : Controller
    {
        
        /*crear lista*/
        private Services.DocenteList DocenteList;
        /*defino constructor*/
        public DocenteController()
        {
            DocenteList = Services.DocenteList.GetInstance();
        }
        // GET: Docente/Docente
        public ActionResult Index()
        {

            var Docentes = DocenteList;
            var DocentesModel = new List<Models.Docente>();
            foreach (var Docente in Docentes)
            {
                var item = new Models.Docente();

                item.Registro = Docente.Registro;

                item.Nombre = Docente.Nombre;

                item.Apellido = Docente.Apellido;

                item.Telefono = Docente.Telefono;

                item.Correo = Docente.Correo;

                DocentesModel.Add(item);
            }
            return View(DocentesModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Docente model)
        {
            var DocenteDomain = new Domain.Docente();
            DocenteDomain.Registro = model.Registro;
            DocenteDomain.Nombre = model.Nombre;
            DocenteDomain.Apellido = model.Apellido;
            DocenteDomain.Telefono = model.Telefono;
            DocenteDomain.Correo = model.Correo;
            DocenteList.Add(DocenteDomain);
            return Redirect("/Docente/Docente");
        }
        public ActionResult Update(Int32 Id)
        {
            var DocenteDomain = DocenteList.GetByRegistro(Id);

            var model = new Models.Docente();

            model.Registro = DocenteDomain.Registro;
            model.Nombre = DocenteDomain.Nombre;
            model.Apellido = DocenteDomain.Apellido;
            model.Telefono = DocenteDomain.Telefono;
            model.Correo = DocenteDomain.Correo;

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Models.Docente model)
        {
            var DocenteDomain = DocenteList.GetByRegistro(model.Registro);
            DocenteDomain.Registro = model.Registro;
            DocenteDomain.Nombre = model.Nombre;
            DocenteDomain.Apellido = model.Apellido;
            DocenteDomain.Telefono = model.Telefono;
            DocenteDomain.Correo = model.Correo;
            DocenteList.Update(DocenteDomain);
            return Redirect("/Docente/Docente");
        }
        public ActionResult Delete(Int32 Id)
        {
            var DocenteDomain = DocenteList.GetByRegistro(Id);

            var model = new Models.Docente();

            model.Registro = DocenteDomain.Registro;
            model.Nombre = DocenteDomain.Nombre;
            model.Apellido = DocenteDomain.Apellido;
            model.Telefono = DocenteDomain.Telefono;
            model.Correo = DocenteDomain.Correo;

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Models.Docente model)
        {
            var DocenteDomain = DocenteList.GetByRegistro(model.Registro);

            DocenteList.Delete(DocenteDomain);
            return Redirect("/Docente/Docente");
        }
        public ActionResult Detail(Int32 Id)
        {
            var DocenteDomain = DocenteList.GetByRegistro(Id);

            var model = new Models.Docente();

            model.Registro = DocenteDomain.Registro;
            model.Nombre = DocenteDomain.Nombre;
            model.Apellido = DocenteDomain.Apellido;
            model.Telefono = DocenteDomain.Telefono;
            model.Correo = DocenteDomain.Correo;

            return View(model);
        }
    }
}