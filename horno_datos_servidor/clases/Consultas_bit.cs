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
    class Consultas_bit
    {
        private conexion conn = new conexion();
        public DataTable tabla_colada(TextBox consola, string fechap)
        {
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            DataTable tabla = new DataTable();
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                string consulta = "SELECT e.numero_col, e.dia_col, e.fecha_col, e.hora_col, e.recargues, "+
                "e.ox_lanceado, e.peso_tl, e.antracita, e.grafito, e.tl_carbon, e.gasoleo,"+
                "e.glp, e.oxigeno, e.espumante, e.fusion, e.tmp_fusion, e.afino, "+
                "e.tmp_afino, e.kw_total, e.power_on, e.power_off, e.carbon, e.temp_final, "+
                "e.tmp_total, e.endbrick, e.m3_lan, e.ton_fusion, e.ton_afino,m.cantlingote, m.pesoacero "+
                "FROM `eaf_col` e left JOIN mcc_col m ON  e.numero_col = m.numero_col "+
                "WHERE concat(`fecha_col`,' ',`hora_col`) "+
                "BETWEEN(SELECT DATE_FORMAT(DATE_SUB( '"+ fechap + "' , INTERVAL 1 DAY), '%Y-%m-%d 22:00:00'))"+
                "AND(SELECT DATE_FORMAT( '" + fechap + "', '%Y-%m-%d 18:00:00')); ";
                command.CommandText = consulta;
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
        }   //  FIN tabla_colada
        public DataTable tabla_modificacion(TextBox consola)
        {
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            DataTable tabla = new DataTable();
            try
            {
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT numero_col AS COLADA, fecha_mod as FECHA, colm_mod as COLUMNA, dato_ant DATO_ANTERIOR, dato_nue as DATO_NUEVO, desc_mod as DESCRIPCION, u.nombre_usuario as USUARIO FROM bitacora_modificacion b, usuario u WHERE u.cod_usuario = b.cod_usuario";
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
        }   //  FIN tabla_modificacion

        public int ajustar_col_dia(string fechap, TextBox consola)
        {
            int validacion = 0;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = "CALL colada_dia(@fecha);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@fecha", fechap);
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
