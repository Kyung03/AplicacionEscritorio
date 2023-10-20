using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Windows.Forms;
using horno_datos_servidor.clases;
//
namespace horno_datos_servidor
{
    class CSV
    {
        public void mover(string dir_1, string dir_2)
        {
            try
            {
                if (!File.Exists(dir_1))
                {
                    using (FileStream fs = File.Create(dir_1)) { }
                }
                if (File.Exists(dir_2))
                {
                    File.Delete(dir_2);
                }
                File.Move(dir_1, dir_2);
            }
            catch (Exception e) { }
        }   // FIN METODO mover

        public void escribir(string dir_1, string linea)
        {
            try
            {

                if (File.Exists(dir_1))
                {
                    using (StreamWriter file = new StreamWriter(dir_1, true))
                    {
                        file.WriteLine(linea); //se agrega información al documento
                        file.Close();
                    }
                }
                else
                {
                    //se crea el archivo
                    using (StreamWriter logs = File.AppendText(dir_1))         
                    {
                        //se adiciona alguna información
                        logs.WriteLine(linea);
                        logs.Close();
                    }
                }
            }
            catch (Exception e) { }
        }   // FIN METODO escribir

        public void eliminar(string dir_1)
        {
            try
            {
                if (!File.Exists(dir_1))
                {

                }
                if (File.Exists(dir_1))
                {
                    File.Delete(dir_1);
                }
            }
            catch (Exception e) { }
        }   // FIN METODO eliminar

        public List<string> leer(string directorio, string respaldo)
        {
           
            int i = 0;
            string ln;
            List<string> lista = new List<string>();
            string query = "";
            string datos_con = "";
            string datos_con_val = "";
            var path = @directorio;
            string msj = "";
            try
            {
                if (File.Exists(path))
                {

                    using (TextFieldParser csvReader = new TextFieldParser(path))
                    {
                        csvReader.CommentTokens = new string[] { "#" };
                        csvReader.SetDelimiters(new string[] { ";" });
                        csvReader.HasFieldsEnclosedInQuotes = true;

                        while ((ln = csvReader.ReadLine()) != null)
                        {
                            string[] fila = ln.Split(';');
                            // GUARDA LOS DATOS LEIDOS EN UN ARCHIVO CSV DE RESPALDO
                            escribir(respaldo, ln);
                            if ((i % 2) == 0)
                            {
                                for (int a = 0; a < fila.Length; a++)
                                {
                                    if ( a == fila.Length-1 ) { datos_con += fila[a] + " "; }
                                    else
                                    {
                                        switch (fila[a])
                                        {
                                            case "Grado":
                                                datos_con += "codigo_grado" + ", ";
                                                break;
                                            case "Fundidor":
                                                datos_con += "codigo_fundidor" + ", ";
                                                break;
                                            case "JefeTurno":
                                                datos_con += "codigo_jefe" + ", ";
                                                break;
                                            case "Jornada":
                                                datos_con += "codigo_jornada" + ", ";
                                                break;
                                            default:
                                                datos_con += eliminar_espacios(fila[a]) + ", ";
                                                break;
                                        }

                                    }
                                }
                            }
                            else
                            {
                                for (int a = 0; a < fila.Length; a++)
                                {
                                    if (a == fila.Length-1 ) { datos_con_val += fila[a] + " "; }
                                    else
                                    {
                                        if (a.Equals(2))
                                        {

                                        }

                                        if (a.Equals(0) || a.Equals(1) || a.Equals(24) || a.Equals(25)
                                            || a.Equals(26) || a.Equals(27) || a.Equals(29))
                                        {
                                            switch (a)
                                            {
                                                case 25:
                                                    datos_con_val += fundidor_lista(fila[a]);
                                                    break;
                                                case 26:
                                                    datos_con_val += jefe_lista(fila[a]);
                                                    break;
                                                default:
                                                    datos_con_val += " '" + fila[a] + "', ";
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            datos_con_val += fila[a] + ", ";
                                        }
                                    }
                                }
                            }
                            if (datos_con != "" && datos_con_val != "")
                            {
                                query = "INSERT INTO datos_horno (" + datos_con + ")" + "VALUES (" + datos_con_val + ")";
                                lista.Add(query);
                                datos_con = "";
                                datos_con_val = "";

                            }
                            i++;
                        }
                    }
                    return lista;
                }
                else
                {
                    return lista;
                }
            }
            catch (Exception ex){ return lista; }
        }   // FIN METODO leer

        private string eliminar_espacios(string cadena)
        {
            string[] cadena_nuevo = cadena.Split(' ');
            string resultado = "";
            for (int i = 0; i < cadena_nuevo.Length ; i++ )
            {
                resultado += cadena_nuevo[i];
            }
            return resultado;
        }

        private string fundidor_lista(string codigo)
        {
            string dato = "";
            switch (codigo)
            {
                case "J. Castro":
                    dato = "3" + ", ";
                    break;
                case "M. Linar":
                    dato = "4" + ", ";
                    break;
                case "F. Vargas":
                    dato = "1" + ", ";
                    break;
                case "S. Lima":
                    dato = "2" + ", ";
                    break;
                default:
                    dato = "10" + ", ";
                    break;
            }
            return dato;
        }
        private string fundidores(string codigo)
        {
            string dato = "";
            Consultas_fun lista = new Consultas_fun();
            foreach ( fundidor fun in lista.listar() )
            {
                if ( eliminar_espacios(codigo.ToUpper()).Equals(eliminar_espacios(fun.Nombre.ToUpper() ) ) )
                {
                    dato = fun.Codigo + ", ";
                }
                else
                {
                    dato = "10" + ", ";
                }
            }
            return dato;
        }
        private string jefe_lista(string codigo)
        {
            string dato = "";
            switch (codigo)
            {
                case "P. Godin":
                    dato = "1" + ", ";
                    break;
                case "L. Bran":
                    dato = "2" + ", ";
                    break;
                default:
                    dato = "10" + ", ";
                    break;
            }
            return dato;
        }

        public List<colada> leer_colada(string directorio, string respaldo)
        {

            int i = 0;
            string ln;
            List<colada> lista = new List<colada>();
            bool cond1 = false;
            bool cond2 = false;
            string[] linea1 = { };
            string[] linea2 = { };
            var path = @directorio;
            try
            {
                if (File.Exists(path))
                {
                    using (TextFieldParser csvReader = new TextFieldParser(path))
                    {
                        csvReader.CommentTokens = new string[] { "#" };
                        csvReader.SetDelimiters(new string[] { ";" });
                        csvReader.HasFieldsEnclosedInQuotes = true;

                        while ((ln = csvReader.ReadLine()) != null)
                        {
                            string[] fila = ln.Split(';');
                            // GUARDA LOS DATOS LEIDOS EN UN ARCHIVO CSV DE RESPALDO
                            escribir(respaldo, ln);
                            if ((i % 2) == 0)
                            {
                                cond1 = true;
                                linea1 = fila;
                            }
                            else
                            {
                                cond2 = true;
                                linea2 = fila;
                            }
                            if (cond1 && cond2)
                            {
                                colada col = new colada();
                                for (int a = 0; a < fila.Length; a++)
                                {
                                    switch ( eliminar_espacios(linea1[a]).ToUpper() )
                                    {
                                        case var value when value == eliminar_espacios(col.NumeroColada).ToUpper():
                                            col.NumeroColada_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Fecha).ToUpper():
                                            col.Fecha_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Hora).ToUpper():
                                            col.Hora_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.NumeroDia).ToUpper():
                                            col.NumeroDia_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Recargue).ToUpper():
                                            col.Recargue_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.OxigenoLanceado).ToUpper():
                                            col.OxigenoLanceado_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PesoTotal).ToUpper():
                                            col.PesoTotal_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Antracita).ToUpper():
                                            col.Antracita_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Grafito).ToUpper():
                                            col.Grafito_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TotalCarbon).ToUpper():
                                            col.TotalCarbon_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Gasoleo).ToUpper():
                                            col.Gasoleo_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.GLP).ToUpper():
                                            col.GLP_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Oxigeno).ToUpper():
                                            col.Oxigeno_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Espumante).ToUpper():
                                            col.Espumante_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Fusion).ToUpper():
                                            col.Fusion_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoFusion).ToUpper():
                                            col.TiempoFusion_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Afino).ToUpper():
                                            col.Afino_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoAfino).ToUpper():
                                            col.TiempoAfino_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.KwhTotal).ToUpper():
                                            col.KwhTotal_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PowerOn).ToUpper():
                                            col.PowerOn_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PowerOff).ToUpper():
                                            col.PowerOff_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Carbon).ToUpper():
                                            col.Carbon_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TempFinal).ToUpper():
                                            col.TempFinal_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoTotal).ToUpper():
                                            col.TiempoTotal_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Endbrick).ToUpper():
                                            col.Endbrick_val = linea2[a];
                                            break;
                                        case var value when value == eliminar_espacios(col.Grado).ToUpper():
                                            col.Grado_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Fundidor).ToUpper():
                                            col.Fundidor_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Jefe).ToUpper():
                                            col.Jefe_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.HoraInicio).ToUpper():
                                            col.HoraInicio_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoVaciado).ToUpper():
                                            col.TiempoVaciado_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Jornada).ToUpper():
                                            col.Jornada_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Prograsmart).ToUpper():
                                            col.Prograsmart_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Progradigit).ToUpper():
                                            col.Progradigit_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PesoCesta1).ToUpper():
                                            col.PesoCesta1_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PesoCesta2).ToUpper():
                                            col.PesoCesta2_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PesoCesta3).ToUpper():
                                            col.PesoCesta3_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PesoCesta4).ToUpper():
                                            col.PesoCesta4_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.PesoCesta5).ToUpper():
                                            col.PesoCesta5_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.ColadasHorno).ToUpper():
                                            col.ColadasHorno_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.ColadasDelta).ToUpper():
                                            col.ColadasDelta_val = linea2[a];
                                            break;
                                        case var value when value == eliminar_espacios(col.ColadasElect1).ToUpper():
                                            col.ColadasElect1_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.ColadasElect2).ToUpper():
                                            col.ColadasElect2_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.ColadasElect3).ToUpper():
                                            col.ColadasElect3_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Caldolomitica).ToUpper():
                                            col.Caldolomitica_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Calcalcitica).ToUpper():
                                            col.Calcalcitica_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Kalister).ToUpper():
                                            col.Kalister_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Torta).ToUpper():
                                            col.Torta_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TempCentro).ToUpper():
                                            col.TempCentro_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TempEvt).ToUpper():
                                            col.TempEvt_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TempPuerta).ToUpper():
                                            col.TempPuerta_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Temp12).ToUpper():
                                            col.Temp12_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Temp23).ToUpper():
                                            col.Temp23_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Temp31).ToUpper():
                                            col.Temp31_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoSellado).ToUpper():
                                            col.TiempoSellado_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoArmado).ToUpper():
                                            col.TiempoArmado_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Tiempo1Recargue).ToUpper():
                                            col.Tiempo1Recargue_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoBovedaAbierta1rCarga).ToUpper():
                                            col.TiempoBovedaAbierta1rCarga_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Tiempo2Recargue).ToUpper():
                                            col.Tiempo2Recargue_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoBovedaAbierta2aCarga).ToUpper():
                                            col.TiempoBovedaAbierta2aCarga_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Tiempo3Recargue).ToUpper():
                                            col.Tiempo3Recargue_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoBovedaAbierta3rCarga).ToUpper():
                                            col.TiempoBovedaAbierta3rCarga_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.Tiempo4Recargue).ToUpper():
                                            col.Tiempo4Recargue_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoBovedaAbierta4aCarga).ToUpper():
                                            col.TiempoBovedaAbierta4aCarga_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.TiempoVaciado1).ToUpper():
                                            col.TiempoVaciado1_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.EspecificaC1).ToUpper():
                                            col.EspecificaC1_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.EspecificaC2).ToUpper():
                                            col.EspecificaC2_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.EspecificaC3).ToUpper():
                                            col.EspecificaC3_val = linea2[a];
                                            break;
                                        case var value when value ==eliminar_espacios(col.EspecificaC4).ToUpper():
                                            col.EspecificaC4_val = linea2[a];
                                            break;
                                    }
                                }
                                cond1 = false;
                                cond2 = false;
                                lista.Add(col);
                            }
                            i++;
                        }
                    }
                    return lista;
                }
                else
                {
                    return lista;
                }
            }
            catch (Exception ex) { return lista; }
        }   // FIN METODO leer

        public List<colada_mcc> leer_acero(string directorio, string respaldo)
        {
            int i = 0;
            string ln;
            List<colada_mcc> lista = new List<colada_mcc>();
            bool cond1 = false;
            bool cond2 = false;
            string[] linea1 = { };
            string[] linea2 = { };
            var path = @directorio;
            try
            {
                if (File.Exists(path))
                {
                    using (TextFieldParser csvReader = new TextFieldParser(path))
                    {
                        csvReader.CommentTokens = new string[] { "#" };
                        csvReader.SetDelimiters(new string[] { ";" });
                        csvReader.HasFieldsEnclosedInQuotes = true;

                        while ((ln = csvReader.ReadLine()) != null)
                        {
                            string[] fila = ln.Split(';');
                            // GUARDA LOS DATOS LEIDOS EN UN ARCHIVO CSV DE RESPALDO
                            escribir(respaldo, ln);
                            if ((i % 2) == 0)
                            {
                                cond1 = true;
                                linea1 = fila;
                            }
                            else
                            {
                                cond2 = true;
                                linea2 = fila;
                            }
                            if (cond1 && cond2)
                            {
                                colada_mcc col_mcc = new colada_mcc();
                                for (int a = 0; a < fila.Length; a++)
                                {
                                    switch (eliminar_espacios(linea1[a]).ToUpper())
                                    {
                                        case var value when value == eliminar_espacios(col_mcc.NumeroColada).ToUpper():
                                            col_mcc.NumeroColada_val = linea2[a];
                                            break;
                                        case var value when value == eliminar_espacios(col_mcc.Fecha).ToUpper():
                                            col_mcc.Fecha_val = linea2[a];
                                            break;
                                        case var value when value == eliminar_espacios(col_mcc.Hora).ToUpper():
                                            col_mcc.Hora_val = linea2[a];
                                            break;
                                        case var value when value == eliminar_espacios(col_mcc.Peso).ToUpper():
                                            col_mcc.Peso_val = linea2[a];
                                            break;
                                        case var value when value == eliminar_espacios(col_mcc.Cantidad_lingotes).ToUpper():
                                            col_mcc.Cantidad_lingotes_val = linea2[a];
                                            break;
                                        case var value when value == eliminar_espacios(col_mcc.Peso_acero).ToUpper():
                                            col_mcc.Peso_acero_val = linea2[a];
                                            break;
                                    }
                                }
                                cond1 = false;
                                cond2 = false;
                                lista.Add(col_mcc);
                            }
                            i++;
                        }
                    }
                    return lista;
                }
                else
                {
                    return lista;
                }
            }
            catch (Exception ex) { return lista; }
        }   // FIN METODO leer


    }   // FIN CLASE CSV
}   // FIN NAMESAPCE 
