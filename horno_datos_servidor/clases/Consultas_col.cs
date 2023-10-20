using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//
namespace horno_datos_servidor.clases
{
    class Consultas_col
    {
        private conexion conn = new conexion();

        public bool insertar(colada col, TextBox consola)
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            
            try
            {
                List<string> columnas = new List<string>();
                List<string> valores = new List<string>();
                if (col.NumeroColada_val != "" )
                {
                    if (col.NumeroDia_val == "" ) col.NumeroDia_val = "null";
                    if (col.Fecha_val == "" ) col.Fecha_val = "null";
                    if (col.Hora_val == "" ) col.Hora_val = "null";
                    if (col.Recargue_val == "" ) col.Recargue_val = "null";
                    if (col.OxigenoLanceado_val == "" ) col.OxigenoLanceado_val = "null";
                    if (col.PesoTotal_val == "" ) col.PesoTotal_val = "null";
                    if (col.Antracita_val == "" ) col.Antracita_val = "null";
                    if (col.Grafito_val == "" ) col.Grafito_val = "null";
                    if (col.TotalCarbon_val == "" ) col.TotalCarbon_val = "null";
                    if (col.Gasoleo_val == "" ) col.Gasoleo_val = "null";
                    if (col.GLP_val == "" ) col.GLP_val = "null";
                    if (col.Oxigeno_val == "" ) col.Oxigeno_val = "null";
                    if (col.Espumante_val == "" ) col.Espumante_val = "null";
                    if (col.Fusion_val == "" ) col.Fusion_val = "null";
                    if (col.TiempoFusion_val == "" ) col.TiempoFusion_val = "null";
                    if (col.Afino_val == "" ) col.Afino_val = "null";
                    if (col.TiempoAfino_val == "" ) col.TiempoAfino_val = "null";
                    if (col.KwhTotal_val == "" ) col.KwhTotal_val = "null";
                    if (col.PowerOn_val == "" ) col.PowerOn_val = "null";
                    if (col.PowerOff_val == "" ) col.PowerOff_val = "null";
                    if (col.Carbon_val == "" ) col.Carbon_val = "null";
                    if (col.TempFinal_val == "" ) col.TempFinal_val = "null";
                    if (col.TiempoTotal_val == "" ) col.TiempoTotal_val = "null";
                    if (col.Endbrick_val == "" ) col.Endbrick_val = "null";
                    if (col.Grado_val == "" ) col.Grado_val = "null";
                    if (col.Fundidor_val == "" ) col.Fundidor_val = "null";
                    if (col.Jefe_val == "" ) col.Jefe_val = "null";
                    if (col.HoraInicio_val == "" ) col.HoraInicio_val = "null";
                    if (col.TiempoVaciado_val == "" ) col.TiempoVaciado_val = "null";
                    if (col.Jornada_val == "" ) col.Jornada_val = "null";
                    if (col.Prograsmart_val == "" ) col.Prograsmart_val = "null";
                    if (col.Progradigit_val == "" ) col.Progradigit_val = "null";
                    if (col.PesoCesta1_val == "" ) col.PesoCesta1_val = "null";
                    if (col.PesoCesta2_val == "" ) col.PesoCesta2_val = "null";
                    if (col.PesoCesta3_val == "" ) col.PesoCesta3_val = "null";
                    if (col.PesoCesta4_val == "" ) col.PesoCesta4_val = "null";
                    if (col.PesoCesta5_val == "" ) col.PesoCesta5_val = "null";
                    if (col.ColadasHorno_val == "" ) col.ColadasHorno_val = "null";
                    if (col.ColadasDelta_val == "" ) col.ColadasDelta_val = "null";
                    if (col.ColadasElect1_val == "" ) col.ColadasElect1_val = "null";
                    if (col.ColadasElect2_val == "" ) col.ColadasElect2_val = "null";
                    if (col.ColadasElect3_val == "" ) col.ColadasElect3_val = "null";
                    if (col.Caldolomitica_val == "" ) col.Caldolomitica_val = "null";
                    if (col.Calcalcitica_val == "" ) col.Calcalcitica_val = "null";
                    if (col.Kalister_val == "" ) col.Kalister_val = "null";
                    if (col.Torta_val == "" ) col.Torta_val = "null";
                    if (col.TempCentro_val == "" ) col.TempCentro_val = "null";
                    if (col.TempEvt_val == "" ) col.TempEvt_val = "null";
                    if (col.TempPuerta_val == "" ) col.TempPuerta_val = "null";
                    if (col.Temp12_val == "" ) col.Temp12_val = "null";
                    if (col.Temp23_val == "" ) col.Temp23_val = "null";
                    if (col.Temp31_val == "" ) col.Temp31_val = "null";
                    if (col.TiempoSellado_val == "" ) col.TiempoSellado_val = "null";
                    if (col.TiempoArmado_val == "" ) col.TiempoArmado_val = "null";
                    if (col.Tiempo1Recargue_val == "" ) col.Tiempo1Recargue_val = "null";
                    if (col.TiempoBovedaAbierta1rCarga_val == "" ) col.TiempoBovedaAbierta1rCarga_val = "null";
                    if (col.Tiempo2Recargue_val == "" ) col.Tiempo2Recargue_val = "null";
                    if (col.TiempoBovedaAbierta2aCarga_val == "" ) col.TiempoBovedaAbierta2aCarga_val = "null";
                    if (col.Tiempo3Recargue_val == "" ) col.Tiempo3Recargue_val = "null";
                    if (col.TiempoBovedaAbierta3rCarga_val == "" ) col.TiempoBovedaAbierta3rCarga_val = "null";
                    if (col.Tiempo4Recargue_val == "" ) col.Tiempo4Recargue_val = "null";
                    if (col.TiempoBovedaAbierta4aCarga_val == "" ) col.TiempoBovedaAbierta4aCarga_val = "null";
                    if (col.EspecificaC1_val == "" ) col.EspecificaC1_val = "null";
                    if (col.EspecificaC2_val == "" ) col.EspecificaC2_val = "null";
                    if (col.EspecificaC3_val == "" ) col.EspecificaC3_val = "null";
                    if (col.EspecificaC4_val == "" ) col.EspecificaC4_val = "null";
                    string query = " INSERT INTO eaf_col( numero_col, dia_col, fecha_col, hora_col, recargues, ox_lanceado, peso_tl, antracita, grafito, tl_carbon, gasoleo, " +
                        "glp, oxigeno, espumante, fusion, tmp_fusion, afino, tmp_afino, kw_total, power_on, power_off, carbon, temp_final, tmp_total, endbrick, cod_grado, cod_fundidor, " +
                        "cod_jefe, hr_inicio, temp_vaciado, cod_jornada, pgr_smart, pgr_digit, peso_cesta1, peso_cesta2, peso_cesta3, peso_cesta4, peso_cesta5, col_horno, col_delta, " +
                        "col_elect1, col_elect2, col_elect3, caldolomitica, calcalcitica, kalister, torta, temp_centro, temp_evt, temp_puerta, temp12, temp23, temp31, tmp_sellado, tmp_armado, " +
                        "tmp_recargue_1, tmp_bov_1r_carga, tmp_recargue_2, tmp_bov_2a_carga, tmp_recargue_3, tmp_bov_3r_carga, tmp_recargue_4, tmp_bov_4a_carga, especifica_c1, especifica_c2, especifica_c3, especifica_c4 )  " +
                    "VALUES ( @numero_col, @dia_col, @fecha_col, @hora_col, @recargues, @ox_lanceado, @peso_tl, @antracita, @grafito, @tl_carbon, @gasoleo, @glp, @oxigeno, @espumante, @fusion, @tmp_fusion, @afino, @tmp_afino, " +
                    "@kw_total, @power_on, @power_off, @carbon, @temp_final, @tmp_total, @endbrick, @cod_grado, @cod_fundidor, @cod_jefe, @hr_inicio, @temp_vaciado, @cod_jornada, @pgr_smart, @pgr_digit, @peso_cesta1, " +
                    "@peso_cesta2, @peso_cesta3, @peso_cesta4, @peso_cesta5, @col_horno, @col_delta, @col_elect1, @col_elect2, @col_elect3, @caldolomitica, @calcalcitica, @kalister, @torta, @temp_centro, @temp_evt, " +
                    "@temp_puerta, @temp12, @temp23, @temp31, @tmp_sellado, @tmp_armado, @tmp_recargue_1, @tmp_bov_1r_carga, @tmp_recargue_2, @tmp_bov_2a_carga, @tmp_recargue_3, @tmp_bov_3r_carga, @tmp_recargue_4, " +
                    "@tmp_bov_4a_carga, @especifica_c1, @especifica_c2, @especifica_c3, @especifica_c4 ) ";
                    //
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@numero_col", col.NumeroColada_val);
                    cmd.Parameters.AddWithValue("@dia_col", col.NumeroDia_val);
                    cmd.Parameters.AddWithValue("@fecha_col", col.Fecha_val);
                    cmd.Parameters.AddWithValue("@hora_col", col.Hora_val);
                    cmd.Parameters.AddWithValue("@recargues", col.Recargue_val);
                    cmd.Parameters.AddWithValue("@ox_lanceado", col.OxigenoLanceado_val);
                    cmd.Parameters.AddWithValue("@peso_tl", col.PesoTotal_val);
                    cmd.Parameters.AddWithValue("@antracita", col.Antracita_val);
                    cmd.Parameters.AddWithValue("@grafito", col.Grafito_val);
                    cmd.Parameters.AddWithValue("@tl_carbon", col.TotalCarbon_val);
                    cmd.Parameters.AddWithValue("@gasoleo", col.Gasoleo_val);
                    cmd.Parameters.AddWithValue("@glp", col.GLP_val);
                    cmd.Parameters.AddWithValue("@oxigeno", col.Oxigeno_val);
                    cmd.Parameters.AddWithValue("@espumante", col.Espumante_val);
                    cmd.Parameters.AddWithValue("@fusion", col.Fusion_val);
                    cmd.Parameters.AddWithValue("@tmp_fusion", col.TiempoFusion_val);
                    cmd.Parameters.AddWithValue("@afino", col.Afino_val);
                    cmd.Parameters.AddWithValue("@tmp_afino", col.TiempoAfino_val);
                    cmd.Parameters.AddWithValue("@kw_total", col.KwhTotal_val);
                    cmd.Parameters.AddWithValue("@power_on", col.PowerOn_val);
                    cmd.Parameters.AddWithValue("@power_off", col.PowerOff_val);
                    cmd.Parameters.AddWithValue("@carbon", col.Carbon_val);
                    cmd.Parameters.AddWithValue("@temp_final", col.TempFinal_val);
                    cmd.Parameters.AddWithValue("@tmp_total", col.TiempoTotal_val);
                    cmd.Parameters.AddWithValue("@endbrick", col.Endbrick_val);
                    cmd.Parameters.AddWithValue("@cod_grado", col.Grado_val);
                    cmd.Parameters.AddWithValue("@cod_fundidor", col.Fundidor_val);
                    cmd.Parameters.AddWithValue("@cod_jefe", col.Jefe_val);
                    cmd.Parameters.AddWithValue("@hr_inicio", col.HoraInicio_val);
                    cmd.Parameters.AddWithValue("@temp_vaciado", col.TiempoVaciado_val);
                    cmd.Parameters.AddWithValue("@cod_jornada", col.Jornada_val);
                    cmd.Parameters.AddWithValue("@pgr_smart", col.Prograsmart_val);
                    cmd.Parameters.AddWithValue("@pgr_digit", col.Progradigit_val);
                    cmd.Parameters.AddWithValue("@peso_cesta1", col.PesoCesta1_val);
                    cmd.Parameters.AddWithValue("@peso_cesta2", col.PesoCesta2_val);
                    cmd.Parameters.AddWithValue("@peso_cesta3", col.PesoCesta3_val);
                    cmd.Parameters.AddWithValue("@peso_cesta4", col.PesoCesta4_val);
                    cmd.Parameters.AddWithValue("@peso_cesta5", col.PesoCesta5_val);
                    cmd.Parameters.AddWithValue("@col_horno", col.ColadasHorno_val);
                    cmd.Parameters.AddWithValue("@col_delta", col.ColadasDelta_val);
                    cmd.Parameters.AddWithValue("@col_elect1", col.ColadasElect1_val);
                    cmd.Parameters.AddWithValue("@col_elect2", col.ColadasElect2_val);
                    cmd.Parameters.AddWithValue("@col_elect3", col.ColadasElect3_val);
                    cmd.Parameters.AddWithValue("@caldolomitica", col.Caldolomitica_val);
                    cmd.Parameters.AddWithValue("@calcalcitica", col.Calcalcitica_val);
                    cmd.Parameters.AddWithValue("@kalister", col.Kalister_val);
                    cmd.Parameters.AddWithValue("@torta", col.Torta_val);
                    cmd.Parameters.AddWithValue("@temp_centro", col.TempCentro_val);
                    cmd.Parameters.AddWithValue("@temp_evt", col.TempEvt_val);
                    cmd.Parameters.AddWithValue("@temp_puerta", col.TempPuerta_val);
                    cmd.Parameters.AddWithValue("@temp12", col.Temp12_val);
                    cmd.Parameters.AddWithValue("@temp23", col.Temp23_val);
                    cmd.Parameters.AddWithValue("@temp31", col.Temp31_val);
                    cmd.Parameters.AddWithValue("@tmp_sellado", col.TiempoSellado_val);
                    cmd.Parameters.AddWithValue("@tmp_armado", col.TiempoArmado_val);
                    cmd.Parameters.AddWithValue("@tmp_recargue_1", col.Tiempo1Recargue_val);
                    cmd.Parameters.AddWithValue("@tmp_bov_1r_carga", col.TiempoBovedaAbierta1rCarga_val);
                    cmd.Parameters.AddWithValue("@tmp_recargue_2", col.Tiempo2Recargue_val);
                    cmd.Parameters.AddWithValue("@tmp_bov_2a_carga", col.TiempoBovedaAbierta2aCarga_val);
                    cmd.Parameters.AddWithValue("@tmp_recargue_3", col.Tiempo3Recargue_val);
                    cmd.Parameters.AddWithValue("@tmp_bov_3r_carga", col.TiempoBovedaAbierta3rCarga_val);
                    cmd.Parameters.AddWithValue("@tmp_recargue_4", col.Tiempo4Recargue_val);
                    cmd.Parameters.AddWithValue("@tmp_bov_4a_carga", col.TiempoBovedaAbierta4aCarga_val);
                    cmd.Parameters.AddWithValue("@especifica_c1", col.EspecificaC1_val);
                    cmd.Parameters.AddWithValue("@especifica_c2", col.EspecificaC2_val);
                    cmd.Parameters.AddWithValue("@especifica_c3", col.EspecificaC3_val);
                    cmd.Parameters.AddWithValue("@especifica_c4", col.EspecificaC4_val);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    validacion = true;
                }
                else
                {
                    consola.AppendText("Error en el numero de colada" + " " + "\n");
                }
                
            }
            catch (Exception ex)
            {
                consola.AppendText("Error en la base de datos: " + ex.Message.ToString() + " " + "\n");
                validacion = false;
            }
            return validacion;
        }

        public bool corregir_dia(string fecha, TextBox consola)
        {
            bool validacion = false;
            MySqlConnection con = new MySqlConnection(conn.cadenaconn());
            try
            {
                con.Open();
                string sql = "CALL colada_dia(@fecha);";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@codigo", fecha);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                validacion = true;
            }
            catch (Exception ex)
            {
                consola.AppendText("Error en la base de datos: " + ex.Message.ToString() + " " + "\n");
                validacion = false;
            }
            return validacion;
        }
    } // fin clase
} // fin namespace
