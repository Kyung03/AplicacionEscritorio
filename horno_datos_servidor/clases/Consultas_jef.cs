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
    class Consultas_jef
    {
        private conexion conn = new conexion();
        public bool insertar_jefe(string codigop, string nombrep, string fechap)
        {
            
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = " INSERT INTO jefe_turno(cod_jefe, nombre_jefe, fecha_creacion)  VALUES (@codigo, @nombre, @fecha) ";
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

        public bool actualizar_jefe(string codigof, string nombrem, string codigom, TextBox consola)
        {
            bool validacion = false;
            string columnas = "";
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                columnas = "nombre_jefe = @nombre";
                string sql = " UPDATE jefe_turno SET " + columnas + " WHERE cod_jefe = @codigo  ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", nombrem);
                cmd.Parameters.AddWithValue("@codigo_jefe", codigof);
                cmd.Parameters.AddWithValue("@codigo", codigom);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                validacion = true;
            }
            catch (Exception ex)
            {
                consola.AppendText("Error en la base de datos en actualizacion: " + ex.Message + " " + "\n");
                validacion = false;
            }
            con.Close();
            return validacion;
        }

        public int eliminar_jefe(string codigom, TextBox consola)
        {
            int validacion = 0;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = "CALL elim_dato(2, @codigo);";
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
                consola.AppendText("Error en la base de datos en eliminacion: " + ex.Message + " " + "\n");
                validacion = 0;
            }
            con.Close();
            return validacion;
        }

    }
}
