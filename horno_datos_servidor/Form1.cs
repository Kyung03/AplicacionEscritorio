using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Threading;
using System.IO;
using System.Timers;
using horno_datos_servidor.forms;
using horno_datos_servidor.clases;
using System.Security.Cryptography;
// Proyecto de graduacion
//
namespace horno_datos_servidor
{
    public partial class Form1 : Form
    {
        int tiempo = Int32.Parse(Properties.Settings.Default.minuto.ToString()); 
        string valor_celda = "";
        string usuario = "";
        string fundidor = "";
        string jefe = "";
        string jornada = "";
        string grado = "";
        int estado=0;
        string contraseña = "";
        DateTime fecha = DateTime.Now;
        private CSV archivo = new CSV();
        private Consultas bd = new Consultas();
        private Consultas_bit bitacoras = new Consultas_bit();
        private string dir = Properties.Settings.Default.directorio_1.ToString();
        string query_usu = "cod_usuario as CÓDIGO,nombre_usuario as USUARIO,fecha_creacion as FECHA, e.tipo_estado as ESTADO, c.tipo_usuario as TIPO";
        string query_usu_con = " WHERE e.cod_estado = u.cod_estado AND u.`cod_clasificacion`= c.`cod_clasificacion`";
        string query_fun = "cod_fundidor as CÓDIGO, nombre_fundidor as NOMBRE,  fecha_creacion as FECHA";
        string query_jef = "cod_jefe as CÓDIGO, nombre_jefe as NOMBRE,  fecha_creacion as FECHA";
        string query_gra = "cod_grado as CÓDIGO, color_grado as COLOR,  diametro_grado as DIAMETRO, barra_grado as BARRA";
        string query_jor = "cod_jornada as CÓDIGO, tipo_jornada as JORNADA,  desc_jornada as DESCRIPCIÓN";

        System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromMinutes(Int32.Parse(Properties.Settings.Default.minuto.ToString())).TotalMilliseconds);
        System.Timers.Timer timer_mcc = new System.Timers.Timer(TimeSpan.FromMinutes(Int32.Parse(Properties.Settings.Default.minuto.ToString())).TotalMilliseconds);

        public Form1()
        {
            InitializeComponent();
            // PRIMER MENSAJE DE LA CONSOLA
            consola.AppendText("Consola de mensajes \n");
            // LLENADO DE DATOS DE LAS TABLAS
            tabla_usu.DataSource = bd.tabla_datos(consola, query_usu, " usuario u, estado e, clasificacion_usuario c  " + query_usu_con);
            tabla_fun.DataSource = bd.tabla_datos(consola, query_fun, "fundidor");
            tabla_jef.DataSource = bd.tabla_datos(consola, query_jef, "jefe_turno");
            tabla_gra.DataSource = bd.tabla_datos(consola, query_gra, "grado");
            tabla_jor.DataSource = bd.tabla_datos(consola, query_jor, "jornada");
            // LLENADO DE DATOS DE LAS TABLAS BITACORAS
            tabla_modificacion.DataSource = bitacoras.tabla_modificacion(consola);
            tabla_coladas.DataSource = bitacoras.tabla_colada(consola, fecha_colada.Value.ToString("yyyy-MM-dd"));
            // LLENADO DE DATOS DE LAS LISTAS (COMBOBOX) DE LA PESTAñA USUARIO
            comboBox2.DataSource = bd.listar_tpu(consola);
            comboBox2.DisplayMember = "Tipo_usuario";
            comboBox2.ValueMember = "Codigo_tipo";
            // LLENADO DE DATOS DE LAS TABLAS
            label5.ForeColor = System.Drawing.Color.Red;
            label6.ForeColor = System.Drawing.Color.Red;
            label5.Text = "Lector "+ Properties.Settings.Default.archivo_csv.ToString(); ;
            label6.Text = "Lector "+ Properties.Settings.Default.archivo_csv_mcc.ToString(); ;
            button3.Text = "X";
            button3.BackColor = System.Drawing.Color.Red;
            button4.Text = "X";
            button4.BackColor = System.Drawing.Color.Red;
            btn_usu_e.Text = "-";
            
        }   // FIN CONSTRUCTOR

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            color();
            csv_eaf();
            csv_mcc();
        }   /* FIN METDO PARA CARGAR EL FORM */

        private void cambio_fecha(Object sender, EventArgs e)
        {
            tabla_coladas.DataSource = bitacoras.tabla_colada(consola, fecha_colada.Value.ToString("yyyy-MM-dd"));
        }

        private void csv_eaf()
        {
            string respaldo = Properties.Settings.Default.directorio_res.ToString();
            string nombre_archivo = Properties.Settings.Default.archivo_csv.ToString();
            timer.Elapsed += async (sender1, e1) =>
            {
                List<colada> list_col = new List<colada>();
                list_col = archivo.leer_colada(dir + "\\" + nombre_archivo, respaldo);
                Consultas_col con_col = new Consultas_col();
                try
                {
                    if (list_col.Any())
                    {
                        list_col.ForEach(delegate (colada item)
                        {
                            if (con_col.insertar(item, consola))
                            {
                                consola.AppendText("Archivo leido: " + nombre_archivo + " con Numero de colada: " + item.NumeroColada_val + ". " + "\n");
                                archivo.eliminar(dir + "\\" + nombre_archivo );
                            }
                            else
                            {
                                consola.AppendText("Ha ocurrido un problema en la insercion. " + nombre_archivo + "\n");
                            }
                        });
                    }
                }
                catch (Exception ex)
                {
                    consola.AppendText("Error con el archivo o sus datos: " + ex.Message.ToString() + " " + "\n");
                }
            };
            timer.Start();
            if (timer.Enabled)
            {
                consola.AppendText("temporizador del archivo " + nombre_archivo + " activado.  \n");
                button3.BackColor = System.Drawing.Color.Green;
                label5.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void csv_mcc()
        {
            string respaldo = Properties.Settings.Default.directorio_res.ToString();
            string nombre_archivo_mcc = Properties.Settings.Default.archivo_csv_mcc.ToString();
            timer_mcc.Elapsed += async (sender1, e1) =>
            {
                Consultas_mcc con_mcc = new Consultas_mcc();
                List<colada_mcc> mcc_lista = new List<colada_mcc>();
                mcc_lista = archivo.leer_acero(dir + "\\" + nombre_archivo_mcc, respaldo);
                try
                {
                    if (mcc_lista.Any())
                    {
                        mcc_lista.ForEach(delegate (colada_mcc item)
                        {
                            if (con_mcc.insertar_mcc(item, consola))
                            {
                                consola.AppendText("Archivo leido: " + nombre_archivo_mcc + " con Numero de colada: " + item.NumeroColada_val + ". " + "\n");
                                archivo.eliminar(dir + "\\" + nombre_archivo_mcc );
                            }
                            else
                            {
                                consola.AppendText("Ha ocurrido un problema en la insercion. " + nombre_archivo_mcc + "\n");
                            }

                        });
                    }
                }
                catch (Exception ex)
                {
                    consola.AppendText("Error " + ex.Message.ToString() + "  " + "\n");
                }
            };
            timer_mcc.Start();
            if (timer_mcc.Enabled)
            {
                consola.AppendText("temporizador del archivo " + nombre_archivo_mcc + " activado " + "\n");
                button4.BackColor = System.Drawing.Color.Green;
                label6.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void buscar_eaf(string directorio)
        {
            string respaldo = Properties.Settings.Default.directorio_res.ToString();
            string nombre_archivo = Properties.Settings.Default.archivo_csv.ToString();
            List<colada> list_col = new List<colada>();
            list_col = archivo.leer_colada(directorio , respaldo);
            Consultas_col con_col = new Consultas_col(); 
            try
            {
                if (list_col.Any())
                {
                    list_col.ForEach(delegate (colada item)
                    {
                        if (con_col.insertar(item, consola))
                        {
                            consola.AppendText("Datos insertados, " + item.NumeroColada_val + "  " + "\n");
                        }
                        else
                        {
                            consola.AppendText("Ha ocurrido un problema en la insercion. " + nombre_archivo + "  " + "\n");
                        }
                    });

                }
                else
                {
                    if (!File.Exists(dir + "\\" + nombre_archivo)) consola.AppendText("Archivo vacio..."+ nombre_archivo + " " + "\n");
                    else consola.AppendText("Error con el archivo o sus datos. " + "\n");
                }
            }
            catch (Exception ex) { }
        }

        private void buscar_mcc(string directorio)
        {
            string respaldo = Properties.Settings.Default.directorio_res.ToString();
            string nombre_archivo_mcc = Properties.Settings.Default.archivo_csv_mcc.ToString();
            Consultas_mcc con_mcc = new Consultas_mcc();
            List<colada_mcc> mcc_lista = new List<colada_mcc>();
            mcc_lista = archivo.leer_acero(directorio, respaldo);
            try
            {
                if (mcc_lista.Any())
                {
                    mcc_lista.ForEach(delegate (colada_mcc item)
                    {
                        if (con_mcc.insertar_mcc(item, consola))
                        {
                            consola.AppendText( "Datos insertador, " + item.NumeroColada_val + " " + "\n");
                        }
                        else
                        {
                            consola.AppendText("Ha ocurrido un problema en la insercion. " + nombre_archivo_mcc + "  " + "\n");
                        }

                    });
                }
                else
                {
                    if (!File.Exists(dir + "\\" + nombre_archivo_mcc)) consola.AppendText("Archivo vacio..."+ nombre_archivo_mcc + " " + "\n");
                    else consola.AppendText("Error con el archivo o sus datos. " + "\n");
                }
            }
            catch (Exception ex) {  } 
        }

        private void Check_mcc_CheckedChanged(object sender, EventArgs e)
        {
            if (check_mcc.Checked)
            {
                check_eaf.Checked = false;
            }
            if (!check_mcc.Checked)
            {
                check_eaf.Checked = true;
            }
        }

        private void Check_eaf_CheckedChanged(object sender, EventArgs e)
        {
            if (check_eaf.Checked)
            {
                check_mcc.Checked = false;
            }
            if (!check_eaf.Checked)
            {
                check_mcc.Checked = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (check_eaf.Checked)
            {
                openFileDialog1.ShowDialog();
                buscar_eaf(openFileDialog1.FileName);
            }
            else
            {
                if (check_mcc.Checked)
                {
                    openFileDialog1.ShowDialog();
                    buscar_mcc(openFileDialog1.FileName);
                }
            }
            openFileDialog1.FileName = "";
        }   /* FIN METODO DEL BOTON 1 */

        private void Config_Click(object sender, EventArgs e)
        {
            configuracion config = new configuracion();
            config.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            registro_consola();
            consola.Clear();
        }

        public void registro_consola()
        {
            DateTime hoy = DateTime.Now;
            string respaldo_log = Properties.Settings.Default.directorio_log.ToString();
            try
            {
                if (File.Exists(respaldo_log))
                {
                    using (StreamWriter file = new StreamWriter(respaldo_log, true))
                    {
                        file.WriteLine("Fecha: " + hoy); //se agrega información al documento
                        string[] temp = consola.Lines;
                        for (int con = 0; con < temp.Length; con ++)
                        {
                            file.WriteLine(temp[con]); //se agrega información al documento
                        }
                        file.Close();
                    }
                }
                else
                {
                    //se crea el archivo
                    using (StreamWriter logs = File.AppendText(respaldo_log))
                    {
                        //se adiciona alguna información
                        logs.WriteLine("Fecha: " + hoy); //se agrega información al documento
                        string[] temp = consola.Lines;
                        for (int con = 0; con < temp.Length; con++)
                        {
                            logs.WriteLine(temp[con]); //se agrega información al documento
                        }
                        logs.Close();
                    }
                }
            }
            catch (Exception e) { }
        }

        private void color()
        {
            foreach (DataGridViewRow dr in tabla_usu.Rows)
            {
                var id = dr.Cells[3].Value;
                if (id.Equals("deshabilitado")) dr.DefaultCellStyle.BackColor = Color.IndianRed;
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            usu_agr usuario = new usu_agr(consola);
            usuario.Visible = true;
        }

        private void Btn_fun_a_Click(object sender, EventArgs e)
        {
            fun_agr fundidor = new fun_agr();
            fundidor.Visible = true;
        }

        private void Btn_jef_a_Click(object sender, EventArgs e)
        {
            jef_agr jefe = new jef_agr();
            jefe.Visible = true;
        }

        private void Btn_gra_a_Click(object sender, EventArgs e)
        {
            gra_agr grado = new gra_agr();
            grado.Visible = true;
        }

        private void Btn_jor_a_Click(object sender, EventArgs e)
        {
            jor_agr jornada = new jor_agr();
            jornada.Visible = true;
        }

        private void Btn_restablecer_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim().Equals("")
                    || comboBox2.SelectedItem == null
                    || usuario.Equals(""))
                {
                    MessageBox.Show("Seleccione un usuario de la tabla");
                }
                else
                {
                    rest_contra rest_from = new rest_contra(usuario);
                    rest_from.Visible = true;
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }

        public void refrescar_tablas()
        {
            tabla_usu.DataSource = bd.tabla_datos(consola, query_usu, " usuario u, estado e, clasificacion_usuario c  " + query_usu_con);
            tabla_fun.DataSource = bd.tabla_datos(consola, query_fun, "fundidor");
            tabla_jef.DataSource = bd.tabla_datos(consola, query_jef, "jefe_turno");
            tabla_gra.DataSource = bd.tabla_datos(consola, query_gra, "grado");
            tabla_jor.DataSource = bd.tabla_datos(consola, query_jor, "jornada");
            tabla_modificacion.DataSource = bitacoras.tabla_modificacion(consola);
            tabla_coladas.DataSource = bitacoras.tabla_colada(consola, fecha_colada.Value.ToString("yyyy-MM-dd"));
            color();
            limpiar();
        }

        public void limpiar()
        {
            // usuario
            btn_usu_e.Text = "-";
            estado = 0;
            usuario = "";
            textBox1.Text = "";
            // fundidor
            fundidor = "";
            txt_cod_fun.Text = "";
            txt_nom_fun.Text = "";
            // jornada
            txt_tip_jor.Text = "";
            txt_des_jor.Text = "";
            jornada = "";
            // grado
            txt_col_gra.Text = "";
            txt_bar_gra.Text = "";
            txt_dia_gra.Text = "";
            grado = "";
            // jefe
            txt_nom_jef.Text = "";
            txt_cod_jefe.Text = "";
            jefe = "";
        }

        private void Ref_tablas_Click(object sender, EventArgs e)
        {
            refrescar_tablas();
        }
        /* USUARIO  */
        /*  SELECCIONAR USUARIO */
        private void Tabla_usu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                usuario = tabla_usu.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = tabla_usu.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (tabla_usu.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("habilitado"))
                {
                    btn_usu_e.Text = "Deshabilitar";
                    estado = 4;
                }
                else
                {
                    btn_usu_e.Text = "Habilitar";
                    estado = 3;
                }
                comboBox2.SelectedIndex = comboBox2.FindStringExact(tabla_usu.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception ex)
            {
                //consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  MODIFICAR USUARIO */
        private void Aeptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim().Equals("")
                    || comboBox2.SelectedItem == null
                    || usuario.Equals(""))
                {
                    MessageBox.Show("Seleccione un usuario de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Confirmacion de modificacion", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        bd.actualizar_usuario(textBox1.Text, comboBox2.SelectedValue.ToString(), usuario, consola);
                        limpiar();
                        refrescar_tablas();
                        MessageBox.Show("Dato modificado");
                    }
                    else
                    {
                        limpiar();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  DESHABILITAR USUARIO */
        private void Btn_usu_e_Click(object sender, EventArgs e)
        {
            if (usuario.Equals("")
                || estado.Equals(0))
            {
                MessageBox.Show("Seleccione un usuario de la tabla");
            }
            else
            {
                bd.deshabilitar_usuario(estado, usuario, consola);
                refrescar_tablas();
            }
        }
        /*  ELIMINAR USUARIO */
        private void Btn_eliminar_usu_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim().Equals("")
                    || comboBox2.SelectedItem == null
                    || usuario.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar el elemento seleccionado", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        switch (bd.eliminar_usuario(usuario, consola))
                        {
                            case 1:
                                MessageBox.Show("Dato eliminado");
                                break;
                            case 2:
                                MessageBox.Show("El dato no puede ser eliminado, ya que posee una referencia en otra tabla");
                                break;
                            case 0:
                                MessageBox.Show("Ha ocurrido un problema");
                                break;
                        }
                        limpiar();
                        refrescar_tablas();
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /* FUNDIDOR  */
        /*  SELECCIONAR FUNDIDOR */
        private void Tabla_fun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fundidor = tabla_fun.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_nom_fun.Text = tabla_fun.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_cod_fun.Text = tabla_fun.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  MODIFICAR FUNDIDOR */
        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txt_cod_fun.Text.Trim().Equals("")
                    || txt_nom_fun.Text.Trim().Equals("")
                    || fundidor.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Confirmacion de modificacion", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_fun bd_fun = new Consultas_fun();
                        bd_fun.actualizar_fundidor( txt_cod_fun.Text, fundidor, consola);
                        limpiar();
                        refrescar_tablas();
                        MessageBox.Show("Dato modificado");
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                //consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  ELIMINAR FUNDIDOR */
        private void Btn_fun_e_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cod_fun.Text.Trim().Equals("")
                    || txt_nom_fun.Text.Trim().Equals("")
                    || fundidor.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar el elemento seleccionado", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_fun bd_fun = new Consultas_fun();
                        switch (bd_fun.eliminar_fundidor(fundidor, consola))
                        {
                            case 1:
                                MessageBox.Show("Dato eliminado");
                                break;
                            case 2:
                                MessageBox.Show("El dato no puede ser eliminado, ya que posee una referencia en otra tabla");
                                break;
                            case 0:
                                MessageBox.Show("Ha ocurrido un problema");
                                break;
                        }
                        limpiar();
                        refrescar_tablas();
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /* JORNADA  */
        /*  SELECCIONAR JORNADA */
        private void Tabla_jor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                jornada = tabla_jor.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_tip_jor.Text = tabla_jor.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_des_jor.Text = tabla_jor.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                //consola.AppendText(ex.Message.ToString() + "  " + "\n");
            }
        }
        /*  MODIFICAR JORNADA */
        private void Btn_mod_jor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_tip_jor.Text.Trim().Equals("")
                    || txt_des_jor.Text.Trim().Equals("")
                    || jornada.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Confirmacion de modificacion", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_jor bd_jor = new Consultas_jor();
                        bd_jor.actualizar_jornada(jornada, txt_tip_jor.Text, txt_des_jor.Text, consola);
                        limpiar();
                        refrescar_tablas();
                        MessageBox.Show("Dato modificado");
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  ELIMINAR JORNADA*/
        private void Btn_eli_jor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_tip_jor.Text.Trim().Equals("")
                    || txt_des_jor.Text.Trim().Equals("")
                    || jornada.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar el elemento seleccionado", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_jor bd_jor = new Consultas_jor();
                        switch (bd_jor.eliminar_jornada(jornada, consola))
                        {
                            case 1:
                                MessageBox.Show("Dato eliminado");
                                break;
                            case 2:
                                MessageBox.Show("El dato no puede ser eliminado, ya que posee una referencia en otra tabla");
                                break;
                            case 0:
                                MessageBox.Show("Ha ocurrido un problema");
                                break;
                        }
                        limpiar();
                        refrescar_tablas();
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /* GRADO  */
        /*  SELECCIONAR GRADO */
        private void Tabla_gra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                grado = tabla_gra.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_col_gra.Text = tabla_gra.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_dia_gra.Text = tabla_gra.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt_bar_gra.Text = tabla_gra.Rows[e.RowIndex].Cells[3].Value.ToString();
                
            }
            catch (Exception ex)
            {
                //consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  MODIFICAR GRADO */
        private void Btn_mod_gra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_col_gra.Text.Trim().Equals("")
                    || txt_bar_gra.Text.Trim().Equals("")
                    || txt_dia_gra.Text.Trim().Equals("")
                    || grado.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Confirmacion de modificacion", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_gra bd_gra = new Consultas_gra();
                        bd_gra.actualizar_grado(grado, txt_col_gra.Text, txt_dia_gra.Text, txt_bar_gra.Text, consola);
                        limpiar();
                        refrescar_tablas();
                        MessageBox.Show("Dato modificado");
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  ELIMINAR GRADO */
        private void Btn_gra_e_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_col_gra.Text.Trim().Equals("")
                    || txt_bar_gra.Text.Trim().Equals("")
                    || txt_dia_gra.Text.Trim().Equals("")
                    || grado.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar el elemento seleccionado", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_gra bd_gra = new Consultas_gra();
                        switch (bd_gra.eliminar_grado(grado, consola))
                        {
                            case 1:
                                MessageBox.Show("Dato eliminado");
                                break;
                            case 2:
                                MessageBox.Show("El dato no puede ser eliminado, ya que posee una referencia en otra tabla");
                                break;
                            case 0:
                                MessageBox.Show("Ha ocurrido un problema");
                                break;
                        }
                        limpiar();
                        refrescar_tablas();
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /* JEFE  */
        /*  SELECCIONAR JEFE */
        private void Tabla_jef_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                jefe = tabla_jef.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_cod_jefe.Text = jefe;
                txt_nom_jef.Text = tabla_jef.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch (Exception ex)
            {
                //consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  MODIFICAR JEFE */
        private void Btn_mod_jef_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nom_jef.Text.Trim().Equals("") 
                    || jefe.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Confirmacion de modificacion", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_jef bd_jef = new Consultas_jef();
                        bd_jef.actualizar_jefe(jefe, txt_nom_jef.Text, jefe, consola);
                        limpiar();
                        refrescar_tablas();
                        MessageBox.Show("Dato modificado");
                    }
                    else
                    {
                        limpiar();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /*  ELIMINAR JEFE */
        private void Btn_jef_e_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nom_jef.Text.Trim().Equals("")
                    || jefe.Equals(""))
                {
                    MessageBox.Show("Seleccione un elemento de la tabla");
                }
                else
                {
                    if (MessageBox.Show("Desea eliminar el elemento seleccionado", "Mensaje", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        Consultas_jef bd_jef = new Consultas_jef();
                        //bd_jef.eliminar_jefe(jefe);
                        switch (bd_jef.eliminar_jefe(jefe, consola) )
                        {
                            case 1:
                                MessageBox.Show("Dato eliminado");
                                break;
                            case 2:
                                MessageBox.Show("El dato no puede ser eliminado, ya que posee una referencia en otra tabla");
                                break;
                            case 0:
                                MessageBox.Show("Ha ocurrido un problema");
                                break;
                        }
                        limpiar();
                        refrescar_tablas();
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                consola.AppendText(ex.Message.ToString() + " " + "\n");
            }
        }
        /* TEMPORIZADORES  */
        private void Button3_Click(object sender, EventArgs e)
        {
            string nombre_archivo = Properties.Settings.Default.archivo_csv.ToString();
            if (timer.Enabled)
            {
                timer.Close();
                consola.AppendText("Temporizador del archivo " + nombre_archivo + " DESACTIVADO \n");
                label5.ForeColor = System.Drawing.Color.Red;
                button3.Text = "O";
                button3.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                csv_eaf();
                label5.ForeColor = System.Drawing.Color.Green;
                button3.Text = "X";
                button3.BackColor = System.Drawing.Color.Green;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string nombre_archivo_mcc = Properties.Settings.Default.archivo_csv_mcc.ToString();
            if (timer_mcc.Enabled)
            {
                timer_mcc.Close();
                consola.AppendText("Temporizador del archivo " + nombre_archivo_mcc + " DESACTIVADO \n");
                label6.ForeColor = System.Drawing.Color.Red;
                button4.Text = "O";
                button4.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                csv_mcc();
                label6.ForeColor = System.Drawing.Color.Green;
                button4.Text = "X";
                button4.BackColor = System.Drawing.Color.Green;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            registro_consola();
        }
        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Btn_dia_col_Click(object sender, EventArgs e)
        {
            bitacoras.ajustar_col_dia(fecha_colada.Value.ToString("yyyy-MM-dd"), consola );
            tabla_coladas.DataSource = bitacoras.tabla_colada(consola, fecha_colada.Value.ToString("yyyy-MM-dd"));
        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }
    }   /* FIN CLASS FORM1 */
}   /* FIN NAMESPACE */
