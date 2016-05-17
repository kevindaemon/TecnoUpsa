using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaltationSistemas.Areas.Estudiante.Controllers
{
    public class EstudianteController : Controller
    {
        private Services.EstudianteList EstudianteList;
        public EstudianteController()
        {
            EstudianteList = Services.EstudianteList.GetInstance();
        }
        // GET: Estudiante/Estudiante
        public ActionResult Index()
        {
            var estudiantes = EstudianteList;
            var estudiantesModel = new List<Models.Estudiante>();
            foreach (var estudiante in estudiantes)
            {
                var item = new Models.Estudiante();

                item.Registro = estudiante.Registro;

                item.Nombre = estudiante.Nombre;

                item.Apellido = estudiante.Apellido;

                item.Telefono = estudiante.Telefono;

                item.Correo = estudiante.Correo;

                estudiantesModel.Add(item);
            }
            return View(estudiantesModel);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Estudiante model)
        {
            var EstudianteDomain = new Domain.Estudiante();
            EstudianteDomain.Registro = model.Registro;
            EstudianteDomain.Nombre = model.Nombre;
            EstudianteDomain.Apellido = model.Apellido;
            EstudianteDomain.Telefono = model.Telefono;
            EstudianteDomain.Correo = model.Correo;
            EstudianteList.Add(EstudianteDomain);
            return Redirect("/Estudiante/estudiante");
        }
        public ActionResult Update(Int32 Id)
        {
            var estudianteDomain = EstudianteList.GetByRegistro(Id);

            var model = new Models.Estudiante();

            model.Registro = estudianteDomain.Registro;
            model.Nombre = estudianteDomain.Nombre;
            model.Apellido = estudianteDomain.Apellido;
            model.Telefono = estudianteDomain.Telefono;
            model.Correo = estudianteDomain.Correo;

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Models.Estudiante model)
        {
            var EstudianteDomain = EstudianteList.GetByRegistro(model.Registro);
            EstudianteDomain.Registro = model.Registro;
            EstudianteDomain.Nombre = model.Nombre;
            EstudianteDomain.Apellido = model.Apellido;
            EstudianteDomain.Telefono = model.Telefono;
            EstudianteDomain.Correo = model.Correo;
            EstudianteList.Update(EstudianteDomain);
            return Redirect("/Estudiante/estudiante");
        }
        public ActionResult Delete(Int32 Id)
        {
            var estudianteDomain = EstudianteList.GetByRegistro(Id);

            var model = new Models.Estudiante();

            model.Registro = estudianteDomain.Registro;
            model.Nombre = estudianteDomain.Nombre;
            model.Apellido = estudianteDomain.Apellido;
            model.Telefono = estudianteDomain.Telefono;
            model.Correo = estudianteDomain.Correo;

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Models.Estudiante model)
        {
            var EstudianteDomain = EstudianteList.GetByRegistro(model.Registro);

            EstudianteList.Delete(EstudianteDomain);
            return Redirect("/Estudiante/estudiante");
        }
        public ActionResult Detail(Int32 Id)
        {
            var estudianteDomain = EstudianteList.GetByRegistro(Id);

            var model = new Models.Estudiante();

            model.Registro = estudianteDomain.Registro;
            model.Nombre = estudianteDomain.Nombre;
            model.Apellido = estudianteDomain.Apellido;
            model.Telefono = estudianteDomain.Telefono;
            model.Correo = estudianteDomain.Correo;

            return View(model);
        }
    }
}