using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Usuario
    {

        //LINQ

        //Sintaxis que nos permite utilizar consultas
        //SQL en C#

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            //using
            try
            {
                using (DL_EF.JTorresProgramacionNCapas08122021Entities context = new DL_EF.JTorresProgramacionNCapas08122021Entities())
                {

                    var UsuariosList = (from usuario in context.Usuarios //select * from usuario 
                                        select new
                                        {
                                            usuario.IdUsuario,
                                            usuario.Nombre,
                                            usuario.ApellidoPaterno,
                                            usuario.ApellidoMaterno
                                        }
                                        ).ToList();


                    if (UsuariosList.Count > 1)
                    {
                        result.Objects = new List<object>();
                        foreach (var usuario in UsuariosList)
                        {
                            ML.Usuario usuarioItem = new ML.Usuario();

                            usuarioItem.IdUsuario = usuario.IdUsuario;
                            usuarioItem.Nombre = usuario.Nombre;
                            usuarioItem.ApellidoPaterno = usuario.ApellidoPaterno;
                            usuarioItem.ApellidoMaterno = usuario.ApellidoMaterno;

                            result.Objects.Add(usuarioItem);
                        }


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros en la tabla de Usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }


        public static ML.Result UpdateLINQ(ML.Usuario usuarioItem)
        {
            ML.Result result = new ML.Result();
            //using
            try
            {
                using (DL_EF.JTorresProgramacionNCapas08122021Entities context = new DL_EF.JTorresProgramacionNCapas08122021Entities())
                {

                    //comprobar si existe el registro
                    var UsuarioUpdate = (from usuario in context.Usuarios //select * from usuario 
                                        where usuario.IdUsuario == usuarioItem.IdUsuario
                                        select usuario
                                        ).FirstOrDefault();


                    if (UsuarioUpdate != null)
                    {
                        UsuarioUpdate.Nombre = usuarioItem.Nombre;
                        UsuarioUpdate.ApellidoPaterno = usuarioItem.ApellidoPaterno;
                        UsuarioUpdate.ApellidoMaterno = usuarioItem.ApellidoMaterno;

                        int RowsAffected = context.SaveChanges();

                        if (RowsAffected >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el registro en la tabla de Usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            //using
            try
            {
                using (DL_EF.JTorresProgramacionNCapas08122021Entities context = new DL_EF.JTorresProgramacionNCapas08122021Entities())
                {

                    DL_EF.Usuario usuarioLinq = new DL_EF.Usuario();
                    usuarioLinq.Nombre = usuario.Nombre;
                    usuarioLinq.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLinq.ApellidoMaterno = usuario.ApellidoMaterno;

                    context.Usuarios.Add(usuarioLinq);
                    context.SaveChanges();


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            //using
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "UsuarioAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Calle", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("NumeroExterior", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("NumeroInterior", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("IdColonia", SqlDbType.Int);
                        collection[3].Value = usuario.Direccion.IdDireccion;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();



                        int RowsAffected = cmd.ExecuteNonQuery();

                        //direccion.IdDireccion==//Van investigar

                        if (RowsAffected > 0)
                        {
                            result.Object = usuario.Direccion.IdDireccion;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al momento de insertar la materia";
                        }
                        cmd.Connection.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }
    }
}
