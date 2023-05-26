using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PLMVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            ServiceReferenceAlumno.AlumnoClient alumnoClient = new ServiceReferenceAlumno.AlumnoClient();
            var result = alumnoClient.GetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de los registros";
                return View();
            }

            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            ServiceReferenceAlumno.AlumnoClient alumnoClient = new ServiceReferenceAlumno.AlumnoClient();
            if (idAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                var result = alumnoClient.GetById(idAlumno.Value);
                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    //aseguradora.Usuario.Usuarios = resultUsuario.Objects;
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer consulta del Alumn@" + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ServiceReferenceAlumno.AlumnoClient alumnoClient = new ServiceReferenceAlumno.AlumnoClient();
            if (alumno.IdAlumno == 0)
            {
                var result = alumnoClient.Add(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente al Alumn@";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar al Alumn@" + result.ErrorMessage;
                }
            }
            else
            {
                var result1 = alumnoClient.Update(alumno);
                if (result1.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente al Alumn@";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar al Alumn@" + result1.ErrorMessage;
                }
            }
            return View("Modal");
        }
    }
}