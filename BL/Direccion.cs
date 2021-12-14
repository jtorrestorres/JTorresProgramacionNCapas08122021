using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Direccion
    {
        public static ML.Result Add(ML.Direccion direccion)
        {
            ML.Result result = new ML.Result();

            //using
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DireccionAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Calle", SqlDbType.VarChar);
                        collection[0].Value = direccion.Calle;

                        collection[1] = new SqlParameter("NumeroExterior", SqlDbType.VarChar);
                        collection[1].Value = direccion.NumeroExterior;

                        collection[2] = new SqlParameter("NumeroInterior", SqlDbType.VarChar);
                        collection[2].Value = direccion.NumeroInterior;

                        collection[3] = new SqlParameter("IdColonia", SqlDbType.Int);
                        collection[3].Value = direccion.Colonia.IdColonia;

                        collection[4] = new SqlParameter("IdDireccion", SqlDbType.Int);
                        collection[4].Direction = ParameterDirection.Output;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();



                        int RowsAffected = cmd.ExecuteNonQuery();

                        //direccion.IdDireccion==//Van investigar

                        if (RowsAffected > 0)
                        {
                            result.Object = direccion.IdDireccion;
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
