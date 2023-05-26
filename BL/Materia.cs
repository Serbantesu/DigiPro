using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result MateriaAdd(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    int query = context.MateriaAdd(materia.Nombre, materia.Costo);
                    if(query > 0)
                    {
                        result.Correct = true; 
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el resgistro" + ex;
            }
            return result; 
        }

        public static ML.Result MateriaUpdate(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    int query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al actualizar el registro seleccionado" + ex;
            }
            return result; 
        }

        public static ML.Result MateriaDelete(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    int query = context.MateriaDelete(materia.IdMateria);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al intentar eliminar el registro seleccionado" + ex;
            }

            return result; 
        }

        public static ML.Result MateriaGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    var materias = context.MateriaGetAll();
                    result.Objects = new List<object>();

                    if(materias != null)
                    {
                        foreach(var user in materias)
                        {

                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = user.IdMateria;
                            materia.Nombre = user.Nombre;
                            materia.Costo = (decimal)user.Costo;

                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al mostrar los registros de la tabla" + ex;
            }
            return result;
        }

        public static ML.Result MateriaGetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JCervantesDigiProEntities1 context = new DL.JCervantesDigiProEntities1())
                {
                    var query =  context.MateriaGetById(idMateria).FirstOrDefault();
                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = (decimal)query.Costo;

                        result.Object = materia;
                        result.Correct = true; 
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al Obtener el registro de la Materia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al mostrar el registro seleccionado" + ex;
            }

            return result;
        }
    }
}
