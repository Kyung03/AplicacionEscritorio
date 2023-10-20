using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
//
namespace horno_datos_servidor.clases
{
    class Consultas
    { 
        private conexion conn = new conexion();
        public DataTable tabla_datos(TextBox consola, string columnas, string tabladb)
        {
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            DataTable tabla = new DataTable();
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT " + columnas + " FROM " + tabladb;
                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                adaptador.SelectCommand = command;
                adaptador.Fill(tabla);
                con.Close();
            }
            catch (Exception ex)
            {
                consola.AppendText("Error en la base de datos en las tablas: " + ex.Message.ToString() + " " + "\n");
            }
            return tabla;
        }

        public bool insertar_usuario(string nombrep, string contrasenap, string fechap, object clasificacionp )
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            DataTable tabla = new DataTable();
            try
            {
                con.Open();
                string sql = " INSERT INTO usuario(nombre_usuario, contraseña_usuario, fecha_creacion, cod_estado, cod_clasificacion )  VALUES(@nombre, @contrasena, @fecha, 3, @clasificacion ) ";
                
                MySqlCommand cmd = new MySqlCommand(sql, con); 
                cmd.Parameters.AddWithValue("@nombre", nombrep);
                cmd.Parameters.AddWithValue("@contrasena", contrasenap);
                cmd.Parameters.AddWithValue("@fecha", fechap);
                cmd.Parameters.AddWithValue("@clasificacion", clasificacionp);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                validacion = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos en insercion: " + " "+ex.Message.ToString() + "\n");
                validacion = false;
            }
            con.Close();
            return validacion;
        }

        public bool actualizar_usuario(string nombrem, string clasificacionm, string codigom, TextBox consola)
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            DataTable tabla = new DataTable();
            try
            {
                con.Open();
                string sql = " UPDATE usuario SET nombre_usuario = @nombre, cod_clasificacion = @clasificacion  WHERE cod_usuario = @codigo  ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", nombrem);
                cmd.Parameters.AddWithValue("@clasificacion", clasificacionm); 
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

        public bool restablecer_contra(string codigom, string clavem )
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = " UPDATE usuario SET contraseña_usuario = @clave  WHERE cod_usuario = @codigo  ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@clave", clavem);
                cmd.Parameters.AddWithValue("@codigo", codigom);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                validacion = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos en actualizacion: " + ex.Message + " " + "\n");
                validacion = false;
            }
            con.Close();
            return validacion;
        }

        public bool deshabilitar_usuario(int estadom, string codigom, TextBox consola)
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            DataTable tabla = new DataTable();
            try
            {
                con.Open();
                string sql = " UPDATE usuario SET cod_estado = @estado  WHERE cod_usuario = @codigo  ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@estado", estadom);
                cmd.Parameters.AddWithValue("@codigo", codigom);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                
                validacion = true;
            }
            catch (Exception ex)
            {
                consola.AppendText("Error en la base de datos en desabilitacion: " + ex.Message + " " + "\n");
                validacion = false;
            }
            con.Close();
            return validacion;
        }

        public int eliminar_usuario(string codigo, TextBox consola)
        {
            int validacion = 0;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = "CALL elim_dato(5, @codigo);";
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

        public List<t_usuario> listar_tpu(TextBox consola)
        {
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            List<t_usuario> lista = new List<t_usuario>();
            string dato = "";
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = " SELECT * FROM `clasificacion_usuario`   ";

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    dato = "";
                    if (dr.HasRows == true)
                    {
                        t_usuario tipo = new t_usuario(dr.GetInt32(0), dr.GetString(1), "");
                        lista.Add(tipo);
                    }
                }
            }
            catch(Exception ex)
            {
                consola.AppendText("Error en la base de datos en listar tipos de usuario: " + ex.Message + " " + "\n");
            }
            return lista;
        }

        public List<estados> listar_est()
        {
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            List<estados> lista = new List<estados>();
            string dato = "";
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = " SELECT * FROM `estado`   ";

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    dato = "";
                    if (dr.HasRows == true)
                    {
                        dato += dr.GetString(0);
                        dato += ";";
                        dato += dr.GetString(1);
                        estados est = new estados(dr.GetInt32(0), dr.GetString(1));
                        lista.Add(est);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lista;
        }

    }
}
