using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
namespace horno_datos_servidor.forms
{
    public partial class config_variables : Form
    {
        private int indice = 0;
        public config_variables()
        {
            InitializeComponent();
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
            indice = listBox1.SelectedIndex;
        }

        private void Config_variables_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals("") || indice == 0)
            {
                MessageBox.Show("Seleccione una variable");
            }
            else
            {
                switch (indice)
                {
                    case 0:
                        Properties.Settings.Default["fecha_colada"] = textBox1.Text;
                        break;
                    case 1:
                        Properties.Settings.Default["hora_colada"] = textBox1.Text;
                        break;
                    case 2:
                        Properties.Settings.Default["num_colada"] = textBox1.Text;
                        break;
                    case 3:
                        Properties.Settings.Default["dia_colada"] = textBox1.Text;
                        break;
                    case 4:
                        Properties.Settings.Default["recargue_col"] = textBox1.Text;
                        break;
                    case 5:
                        Properties.Settings.Default["oxlan_col"] = textBox1.Text;
                        break;
                    case 6:
                        Properties.Settings.Default["pesot_col"] = textBox1.Text;
                        break;
                    case 7:
                        Properties.Settings.Default["antracita_col"] = textBox1.Text;
                        break;
                    case 8:
                        Properties.Settings.Default["grafito_col"] = textBox1.Text;
                        break;
                    case 9:
                        Properties.Settings.Default["tcarbon_col"] = textBox1.Text;
                        break;
                    case 10:
                        Properties.Settings.Default["gasoleo_col"] = textBox1.Text;
                        break;
                    case 11:
                        Properties.Settings.Default["glp_col"] = textBox1.Text;
                        break;
                    case 12:
                        Properties.Settings.Default["ox_col"] = textBox1.Text;
                        break;
                    case 13:
                        Properties.Settings.Default["espuma_col"] = textBox1.Text;
                        break;
                    case 14:
                        Properties.Settings.Default["fusion_col"] = textBox1.Text;
                        break;
                    case 15:
                        Properties.Settings.Default["tfusion_col"] = textBox1.Text;
                        break;
                    case 16:
                        Properties.Settings.Default["afino_col"] = textBox1.Text;
                        break;
                    case 17:
                        Properties.Settings.Default["tafino_col"] = textBox1.Text;
                        break;
                    case 18:
                        Properties.Settings.Default["kwtotal_col"] = textBox1.Text;
                        break;
                    case 19:
                        Properties.Settings.Default["pon_col"] = textBox1.Text;
                        break;
                    case 20:
                        Properties.Settings.Default["poff_col"] = textBox1.Text;
                        break;
                    case 21:
                        Properties.Settings.Default["carbon_col"] = textBox1.Text;
                        break;
                    case 22:
                        Properties.Settings.Default["tempfinal_col"] = textBox1.Text;
                        break;
                    case 23:
                        Properties.Settings.Default["ttotal_col"] = textBox1.Text;
                        break;
                    case 24:
                        Properties.Settings.Default["endbrick_col"] = textBox1.Text;
                        break;
                    case 25:
                        Properties.Settings.Default["grado_col"] = textBox1.Text;
                        break;
                    case 26:
                        Properties.Settings.Default["fun_col"] = textBox1.Text;
                        break;
                    case 27:
                        Properties.Settings.Default["jefe_col"] = textBox1.Text;
                        break;
                    case 28:
                        Properties.Settings.Default["hinicio_col"] = textBox1.Text;
                        break;
                    case 29:
                        Properties.Settings.Default["tvaciado_col"] = textBox1.Text;
                        break;
                    case 30:
                        Properties.Settings.Default["jor_col"] = textBox1.Text;
                        break;
                    case 31:
                        Properties.Settings.Default["psmart_col"] = textBox1.Text;
                        break;
                    case 32:
                        Properties.Settings.Default["pdigit_col"] = textBox1.Text;
                        break;
                    case 33:
                        Properties.Settings.Default["pcesta1_col"] = textBox1.Text;
                        break;
                    case 34:
                        Properties.Settings.Default["pcesta2_col"] = textBox1.Text;
                        break;
                    case 35:
                        Properties.Settings.Default["pcesta3_col"] = textBox1.Text;
                        break;
                    case 36:
                        Properties.Settings.Default["pcesta4_col"] = textBox1.Text;
                        break;
                    case 37:
                        Properties.Settings.Default["pcesta5_col"] = textBox1.Text;
                        break;
                    case 38:
                        Properties.Settings.Default["horno_col"] = textBox1.Text;
                        break;
                    case 39:
                        Properties.Settings.Default["delta_col"] = textBox1.Text;
                        break;
                    case 40:
                        Properties.Settings.Default["celec1"] = textBox1.Text;
                        break;
                    case 41:
                        Properties.Settings.Default["celec2"] = textBox1.Text;
                        break;
                    case 42:
                        Properties.Settings.Default["celec3"] = textBox1.Text;
                        break;
                    case 43:
                        Properties.Settings.Default["caldol_col"] = textBox1.Text;
                        break;
                    case 44:
                        Properties.Settings.Default["calcal_col"] = textBox1.Text;
                        break;
                    case 45:
                        Properties.Settings.Default["kalister_col"] = textBox1.Text;
                        break;
                    case 46:
                        Properties.Settings.Default["torta_col"] = textBox1.Text;
                        break;
                    case 47:
                        Properties.Settings.Default["tempcen_col"] = textBox1.Text;
                        break;
                    case 48:
                        Properties.Settings.Default["tempevt_col"] = textBox1.Text;
                        break;
                    case 49:
                        Properties.Settings.Default["temppuer_col"] = textBox1.Text;
                        break;
                    case 50:
                        Properties.Settings.Default["temp12_col"] = textBox1.Text;
                        break;
                    case 51:
                        Properties.Settings.Default["temp23_col"] = textBox1.Text;
                        break;
                    case 52:
                        Properties.Settings.Default["temp31_col"] = textBox1.Text;
                        break;
                    case 53:
                        Properties.Settings.Default["tsellado_col"] = textBox1.Text;
                        break;
                    case 54:
                        Properties.Settings.Default["tarmado_col"] = textBox1.Text;
                        break;
                    case 55:
                        Properties.Settings.Default["t1recar_col"] = textBox1.Text;
                        break;
                    case 56:
                        Properties.Settings.Default["tabierta1_col"] = textBox1.Text;
                        break;
                    case 57:
                        Properties.Settings.Default["t2recar_col"] = textBox1.Text;
                        break;
                    case 58:
                        Properties.Settings.Default["tabierta2_col"] = textBox1.Text;
                        break;
                    case 59:
                        Properties.Settings.Default["t3recar_col"] = textBox1.Text;
                        break;
                    case 60:
                        Properties.Settings.Default["tabierta3_col"] = textBox1.Text;
                        break;
                    case 61:
                        Properties.Settings.Default["t4recar_col"] = textBox1.Text;
                        break;
                    case 62:
                        Properties.Settings.Default["tabierta4_col"] = textBox1.Text;
                        break;
                    case 63:
                        Properties.Settings.Default["tvaciado1_col"] = textBox1.Text;
                        break;
                    case 64:
                        Properties.Settings.Default["espc1_col"] = textBox1.Text;
                        break;
                    case 65:
                        Properties.Settings.Default["espc2_col"] = textBox1.Text;
                        break;
                    case 66:
                        Properties.Settings.Default["espc3_col"] = textBox1.Text;
                        break;
                    case 67:
                        Properties.Settings.Default["espc4_col"] = textBox1.Text;
                        break;
                }
                Properties.Settings.Default.Save();
                MessageBox.Show("Configuracion guardada");
                indice = 0;
                textBox1.Text = "";
                cargar();
            }
        }
        private void cargar()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(Properties.Settings.Default.fecha_colada.ToString());
            listBox1.Items.Add(Properties.Settings.Default.hora_colada.ToString());
            listBox1.Items.Add(Properties.Settings.Default.num_colada.ToString());
            listBox1.Items.Add(Properties.Settings.Default.dia_colada.ToString());
            listBox1.Items.Add(Properties.Settings.Default.recargue_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.oxlan_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pesot_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.antracita_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.grafito_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tcarbon_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.gasoleo_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.glp_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.ox_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.espuma_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.fusion_col.ToString()); 
            listBox1.Items.Add(Properties.Settings.Default.tfusion_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.afino_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tafino_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.kwtotal_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pon_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.poff_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.carbon_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tempfinal_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.ttotal_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.endbrick_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.grado_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.fun_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.jefe_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.hinicio_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tvaciado_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.jor_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.psmart_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pdigit_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pcesta1_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pcesta2_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pcesta3_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pcesta4_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.pcesta5_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.horno_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.delta_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.celec1.ToString());
            listBox1.Items.Add(Properties.Settings.Default.celec2.ToString());
            listBox1.Items.Add(Properties.Settings.Default.celec3.ToString());
            listBox1.Items.Add(Properties.Settings.Default.caldol_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.calcal_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.kalister_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.torta_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tempcen_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tempevt_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.temppuer_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.temp12_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.temp23_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.temp31_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tsellado_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tarmado_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.t1recar_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tabierta1_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.t2recar_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tabierta2_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.t3recar_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tabierta3_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.t4recar_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tabierta4_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.tvaciado1_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.espc1_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.espc2_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.espc3_col.ToString());
            listBox1.Items.Add(Properties.Settings.Default.espc4_col.ToString());
        }
    } //
} //
