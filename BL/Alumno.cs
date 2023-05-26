using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result AlumnoAdd(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno",SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el Alumno" + ex;
            }
            return result;
        }

        public static ML.Result AlumnoUpdate(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;
                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;
                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;
                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al actualizar al Alumno" + ex;
            }

            return result;
        }

        public static ML.Result AlumnoDelete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = query;

                        SqlParameter collection = new SqlParameter();

                        collection = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection.Value = alumno.IdAlumno;

                        cmd.Parameters.Add(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;                
                result.ErrorMessage = "Error al eliminar el Usuario: " + ex;
            }
            return result;
        }

        public static ML.Result AlumnoGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable tableAlumno = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(tableAlumno);

                        if(tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();

                                result.Objects.Add( alumno );   
                            }
                            result.Correct = true; 
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }                    
                } 
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al mostrar los registros" + ex;
            }

            return result;
        }

        public static ML.Result AlumnoGetById(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "AlumnoGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = idAlumno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                        dataAdapter.Fill(tableUsuario);

                        if(tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();

                            result.Object = alumno;
                            result.Correct = true; 
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al mostarr el registro seleccionado";
                        }
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
