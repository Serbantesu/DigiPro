using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Alumno" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Alumno.svc o Alumno.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Alumno : IAlumno
    { 
        public SLWCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            result = BL.Alumno.AlumnoAdd(alumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SLWCF.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            result = BL.Alumno.AlumnoUpdate(alumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SLWCF.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            result = BL.Alumno.AlumnoDelete(alumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SLWCF.Result GetAll()
        {
            ML.Result result = BL.Alumno.AlumnoGetAll();
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SLWCF.Result GetById(int idAlumno)
        {
            ML.Result result = BL.Alumno.AlumnoGetById(idAlumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
