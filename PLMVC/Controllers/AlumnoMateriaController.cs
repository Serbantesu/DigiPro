using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.AlumnoGetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de los Alumnos";
            }
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Materias(int idAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Result result = BL.AlumnoMateria.MateriaGetByAlumno(idAlumno);

            ML.Result resultAlumno = BL.Alumno.AlumnoGetById(idAlumno);
            alumnoMateria.Alumno = new ML.Alumno();

            if (result.Correct)
            {
                alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;
                alumnoMateria.AlumnoMaterias = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al consultas las materias asignadas del alumno";
            }
            return View(alumnoMateria);
        }

        [HttpGet]
        public ActionResult MateriasSinasignar(int idAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Result result = BL.AlumnoMateria.MateriasSinAsignar(idAlumno);

            ML.Result resultAlumno = BL.Alumno.AlumnoGetById(idAlumno);
            alumnoMateria.Alumno = new ML.Alumno();

            if (result.Correct)
            {
                alumnoMateria.Alumno = (ML.Alumno)resultAlumno.Object;
                alumnoMateria.AlumnoMaterias = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al consultas las materias";
            }
            return View(alumnoMateria);
        }

        [HttpPost]
        public ActionResult MateriaSinAsignar(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();

            if (alumnoMateria.AlumnoMaterias != null)
            {
                foreach (string idMateria in alumnoMateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnoItems = new ML.AlumnoMateria();

                    alumnoItems.Alumno = new ML.Alumno();
                    alumnoItems.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnoItems.Materia = new ML.Materia();
                    alumnoItems.Materia.IdMateria = int.Parse(idMateria);

                    ML.Result res = BL.AlumnoMateria.Add(alumnoItems);
                }
                result.Correct = true;
                ViewBag.Message = "Se an agregado correctamente las materias seleccionadas";                
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al agregar las materias";
            }
            ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            return PartialView("Modal");
        }

        public ActionResult Delete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnoMaterias != null)
            {
                foreach (string IdAlumnoMateria in alumnoMateria.AlumnoMaterias)
                {
                    alumnoMateria.IdAlumnoMateria = int.Parse(IdAlumnoMateria);
                    ML.Result res = BL.AlumnoMateria.Delete(alumnoMateria);
                }
                result.Correct = true;
                ViewBag.Message = "Se han eliminado correctamente las materias";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }
    }
}

