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
    class Consultas_gra
    {
        private conexion conn = new conexion();
        public bool insertar_grado(string codigop, string colorp, string diametrop, string barrap )
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = " INSERT INTO grado(cod_grado, color_grado, diametro_grado, barra_grado)  VALUES (@codigo, @color, @diametro, @barra) ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", codigop);
                cmd.Parameters.AddWithValue("@color", colorp);
                cmd.Parameters.AddWithValue("@diametro", diametrop);
                cmd.Parameters.AddWithValue("@barra", barrap);
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

        public bool actualizar_grado(string codigop, string colorp, string diametrop, string barrap, TextBox consola)
        {
            bool validacion = false;
            string columnas = "";
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                columnas = "color_grado = @color, diametro_grado = @diametro, barra_grado = @barra";
                string sql = " UPDATE grado SET " + columnas + " WHERE cod_grado = @codigo  ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", codigop);
                cmd.Parameters.AddWithValue("@color", colorp);
                cmd.Parameters.AddWithValue("@diametro", diametrop);
                cmd.Parameters.AddWithValue("@barra", barrap);
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

        public int eliminar_grado(string codigo, TextBox consola)
        {
            int validacion = 0;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = "CALL elim_dato(3, @codigo);";
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
