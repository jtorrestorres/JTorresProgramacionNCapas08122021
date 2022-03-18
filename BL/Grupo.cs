using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BL
{
    public class Grupo
    {

        public static ML.Result GetByIdPlantel(int IdPlantel)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "GrupoGetByIdPlantel";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdPlantel", SqlDbType.Int);
                        collection[0].Value = IdPlantel;

                        cmd.Parameters.AddRange(collection);


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableGrupo = new DataTable();

                            da.Fill(tableGrupo);

                            cmd.Connection.Open();

                            if (tableGrupo.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tableGrupo.Rows) //
                                {
                                    ML.Grupo grupo = new ML.Grupo(); 
                                    grupo.IdGrupo = int.Parse(row[0].ToString());
                                    grupo.Nombre = row[1].ToString();
                                    result.Objects.Add(grupo);  
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
