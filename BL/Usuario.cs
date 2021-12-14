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
