using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result MateriaGetByAlumno(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    var materiasList = context.MateriaGetByAlumno(idAlumno).ToList();
                    result.Objects = new List<object>();

                    foreach(var row in materiasList)
                    {
                        ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                        alumnoMateria.IdAlumnoMateria = row.IdAlumnoMateria.Value;

                        alumnoMateria.Alumno = new ML.Alumno();
                        alumnoMateria.Alumno.IdAlumno = row.IdAlumno;

                        alumnoMateria.Materia = new ML.Materia();
                        alumnoMateria.Materia.IdMateria = row.IdMateria;
                        alumnoMateria.Materia.Nombre = row.Nombre;

                        result.Objects.Add(alumnoMateria);
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un erro al mostrar las materias del alumno seleccionado" + ex;
            }
            return result;
        }

        public static ML.Result MateriasSinAsignar(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    var materiaList = context.MateriasSinAsignar(idAlumno).ToList();
                    result.Objects = new List<object>();

                    foreach(var row in materiaList)
                    {
                        ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();                        

                        alumnoMateria.Materia = new ML.Materia();
                        alumnoMateria.Materia.IdMateria = row.IdMateria;
                        alumnoMateria.Materia.Nombre = row.Nombre;
                        alumnoMateria.Materia.Costo = (decimal)row.Costo;

                        result.Objects.Add(alumnoMateria);
                    }
                    result.Correct = true;
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "No se pudieron obtener los registros solicitados" + ex;
            }
            return result; 
        }

        public static ML.Result Delete(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    int query = context.AlumnoMateriaDelete(alumnoMateria.IdAlumnoMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al eliminar el registro seleccionado" + ex;
            }

            return result;
        }

        public static ML.Result Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    int query = context.AlumnoMateriaAdd(alumnoMateria.Materia.IdMateria, alumnoMateria.Alumno.IdAlumno);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al agregar las materias al alumn@ seleccionado" + ex;
            }
            return result;
        }
    }
}
