using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    //STORED PROCEDURES
                    string query = "PlantelGetAll";
                    using (SqlCommand cmd = new SqlCommand()) //query
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        //SqlDataReader
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) //
                        {
                            DataTable tablePlantel = new DataTable();
                            da.Fill(tablePlantel);

                            cmd.Connection.Open();

                            if (tablePlantel.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablePlantel.Rows) //
                                {
                                    ML.Plantel plantel = new ML.Plantel();
                                    plantel.IdPlantel = int.Parse(row[0].ToString());
                                    plantel.Nombre = row[1].ToString();
                                    result.Objects.Add(plantel);

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

            result.Correct = true;
            return result;

        }
    }
}
