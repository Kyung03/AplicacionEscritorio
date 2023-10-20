using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//

namespace horno_datos_servidor.clases
{
    class Consultas_fun
    {
        private conexion conn = new conexion();
        public List<fundidor> listar()
        {
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            List<fundidor> lista = new List<fundidor>();
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = " SELECT * FROM `fundidor`   ";

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        fundidor fun = new fundidor(dr.GetInt32(0), dr.GetString(1));
                        lista.Add(fun);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return lista;
        }

        public bool insertar_fundidor(string codigop, string nombrep, string fechap)
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = " INSERT INTO fundidor(cod_fundidor, nombre_fundidor, fecha_creacion)  VALUES (@codigo, @nombre, @fecha) ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", codigop);
                cmd.Parameters.AddWithValue("@nombre", nombrep);
                cmd.Parameters.AddWithValue("@fecha", fechap);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                validacion = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos" + " " + ex.Message.ToString() + "\n");
                validacion = false;
            }
            con.Close(); 
            return validacion;
        }

        public bool actualizar_fundidor( string nombrem, string codigom, TextBox consola)
        {
            bool validacion = false;
            string columnas = "";
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                columnas = "nombre_fundidor = @nombre ";
                string sql = " UPDATE fundidor SET " + columnas + " WHERE cod_fundidor = @codigo  ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", nombrem);
                cmd.Parameters.AddWithValue("@codigo", codigom);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                validacion = true;
            }
            catch (Exception ex)
            {
                consola.AppendText("Error en la base de datos en la actualizacion: " + ex.Message.ToString() + " " + "\n");
                validacion = false;
            }
            con.Close();
            return validacion;
        }

        public int eliminar_fundidor(string codigom, TextBox consola)
        {
            int validacion = 0;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = "CALL elim_dato(1, @codigo);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", codigom);
                cmd.Prepare();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    validacion = 1;
                }
                else
                {
                    validacion = 2;
                }
            }
            catch (Exception ex)
            {
                consola.AppendText("Error en la base de datos en la eliminacion: " + ex.Message.ToString() + " " + "\n");
                validacion = 0;
            }
            con.Close();
            return validacion;
        }

    } // FIN CLASS
} // FON NAMESPACE
