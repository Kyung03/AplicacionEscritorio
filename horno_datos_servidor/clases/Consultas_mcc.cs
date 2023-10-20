using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//
namespace horno_datos_servidor.clases
{
    class Consultas_mcc
    {
        private conexion conn = new conexion();


        public bool insertar_mcc(colada_mcc col, TextBox consola)
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());

            try
            {
                string columnas_cadena = "";
                string valores_cadena = "";
                List<string> columnas = new List<string>();
                List<string> valores = new List<string>();
                if (col.NumeroColada_val != "" )
                {
                    columnas.Add(col.NumeroColada);
                    valores.Add(col.NumeroColada_val);
                    //
                    if (col.Fecha_val == "")
                    {
                        col.Fecha_val = "null";
                    }
                    else
                    {
                        columnas.Add(col.Fecha);
                        valores.Add(col.Fecha_val);
                    }
                    if (col.Hora_val == "")
                    {
                        col.Hora_val = "null";
                    }
                    else
                    {
                        columnas.Add(col.Hora);
                        valores.Add(col.Hora_val);
                    }
                    if (col.Peso_val == "")
                    {
                        col.Peso_val = "null";
                    }
                    else
                    {
                        columnas.Add(col.Peso);
                        valores.Add(col.Peso_val);
                    }
                    if (col.Cantidad_lingotes_val == "")
                    {
                        col.Cantidad_lingotes_val = "null";
                    }
                    else
                    {
                        columnas.Add(col.Cantidad_lingotes);
                        valores.Add(col.Cantidad_lingotes_val);
                    }
                    if (col.Peso_acero_val == "")
                    {
                        col.Peso_acero_val = "null";
                    }
                    else
                    {
                        columnas.Add(col.Peso_acero);
                        valores.Add(col.Peso_acero_val);
                    }
                    if (columnas.Count == valores.Count)
                    {
                        columnas.ForEach(delegate (string dato)
                        {
                            columnas_cadena += dato;
                        });
                        valores.ForEach(delegate (string dato)
                        {
                            valores_cadena += "@" + dato;
                        });

                        string sql = " INSERT INTO mcc_col( horat, fechat, cantlingote, pesoacero, peso1, numero_col )  " +
                        "VALUES ( @horat, @fechat, @cantlingote, @pesoacero, @peso1, @numero_col ) ";
                        //
                        DateTime fecha_dt = Convert.ToDateTime(col.Fecha_val);
                        
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@horat", col.Hora_val);
                        cmd.Parameters.AddWithValue("@fechat", fecha_dt.ToString("yyyy/MM/dd"));
                        cmd.Parameters.AddWithValue("@cantlingote", col.Cantidad_lingotes_val);
                        cmd.Parameters.AddWithValue("@pesoacero", col.Peso_acero_val.Replace(',', '.'));
                        cmd.Parameters.AddWithValue("@peso1", col.Peso_val.Replace(',', '.'));
                        cmd.Parameters.AddWithValue("@numero_col", col.NumeroColada_val);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                        validacion = true;
                    }
                    else
                    {
                        consola.AppendText(" Los valores y las columnas no coinciden " + " " + " \n");
                    }
                }
                else
                {
                    consola.AppendText(" Error en el numero de colada " + " " + " \n");
                }
                
            }
            catch (Exception ex)
            {
                consola.AppendText( "Error en la base de datos " + ex.Message.ToString() + " " + " \n");
                validacion = false;
            }
            con.Close();
            return validacion;
        }
    }
}
