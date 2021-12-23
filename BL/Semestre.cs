using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "SemestreGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableSemestre = new DataTable();

                            da.Fill(tableSemestre);

                            cmd.Connection.Open();

                            if (tableSemestre.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tableSemestre.Rows) //
                                {
                                    ML.Semestre semestre = new ML.Semestre();
                                    semestre.IdSemestre = int.Parse(row[0].ToString());
                                    semestre.Nombre = row[1].ToString();
                                    result.Objects.Add(semestre);

                                }

                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros en la tabla Materia";
                            }

                            //inicializador condición incremento


                        }


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
