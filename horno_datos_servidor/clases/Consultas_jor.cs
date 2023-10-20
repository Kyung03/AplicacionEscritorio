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
    class Consultas_jor
    {
        private conexion conn = new conexion();

        public bool insertar_jornada(string codigop, string tipop, string descripcionp)
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = " INSERT INTO jornada(cod_jornada, tipo_jornada, desc_jornada)  VALUES (@codigo, @tipo, @descripcion) ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", codigop);
                cmd.Parameters.AddWithValue("@tipo", tipop);
                cmd.Parameters.AddWithValue("@descripcion", descripcionp);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                validacion = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos " + " " + ex.Message.ToString() + "\n");
                validacion = false;
            }
            con.Close();
            return validacion;
        }

        public bool actualizar_jornada(string codigop, string tipop, string descripcionp, TextBox consola)
        {
            bool validacion = false;
            string columnas = "";
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                columnas = "tipo_jornada = @tipo, desc_jornada = @descripcion";
                string sql = " UPDATE jornada SET " + columnas + " WHERE cod_jornada = @codigo  ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", codigop);
                cmd.Parameters.AddWithValue("@tipo", tipop);  
                cmd.Parameters.AddWithValue("@descripcion", descripcionp);
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

        public int eliminar_jornada(string codigo, TextBox consola)
        {
            int validacion = 0;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = "CALL elim_dato(4, @codigo);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", codigo);
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
