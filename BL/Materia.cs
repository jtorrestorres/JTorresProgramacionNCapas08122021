using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Materia
    {
        public static int Prueba()
        {
            return 1;
        }

        public static string Prueba2()
        {
            return "";
        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "SELECT IdMateria,Nombre,[Creditos],[Costo] FROM Materia";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableMateria = new DataTable();

                            da.Fill(tableMateria);

                            cmd.Connection.Open();

                            if (tableMateria.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tableMateria.Rows) //
                                {
                                    ML.Materia materia = new ML.Materia();
                                    materia.IdMateria = int.Parse(row[0].ToString());
                                    materia.Nombre = row[1].ToString();
                                    materia.Creditos = byte.Parse(row[2].ToString());
                                    materia.Costo = decimal.Parse(row[3].ToString());

                                    result.Objects.Add(materia);

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

        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "MateriaGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[0].Value = IdMateria;                   

                        cmd.Parameters.AddRange(collection);


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tableMateria = new DataTable();

                            da.Fill(tableMateria);

                            cmd.Connection.Open();

                            if (tableMateria.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();

                                DataRow row = tableMateria.Rows[0];

                                ML.Materia materia = new ML.Materia();
                                materia.IdMateria = int.Parse(row[0].ToString());
                                materia.Nombre = row[1].ToString();
                                materia.Creditos = byte.Parse(row[2].ToString());
                                materia.Costo = decimal.Parse(row[3].ToString());
                                                                                          
                                result.Object = materia;  //boxing    --unboxing

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

        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            //using
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INSERT INTO [Materia] ([Nombre],[Creditos],[Costo]) VALUES (@Nombre, @Creditos, @Costo)";
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Credito", SqlDbType.TinyInt);
                        collection[1].Value = materia.Creditos;

                        collection[2] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[2].Value = materia.Costo;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
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


        public static ML.Result AddSP(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            //using
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "MateriaAdd";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Credito", SqlDbType.TinyInt);
                        collection[1].Value = materia.Creditos;

                        collection[2] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[2].Value = materia.Costo;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
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
        public static void Update()
        {

        }

        public static void Delete()
        {

        }
    }
}
