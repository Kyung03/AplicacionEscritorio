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
    public partial class config_var_mcc : Form
    {
        private int indice;
        public config_var_mcc()
        {
            InitializeComponent();
        }

        private void Box_var_mcc_Click(object sender, EventArgs e)
        {
            txt_var_mcc.Text = box_var_mcc.Text;
            indice = box_var_mcc.SelectedIndex+1;
        }

        private void cargar()
        {
            box_var_mcc.Items.Clear();
            box_var_mcc.Items.Add(Properties.Settings.Default.num_col_mcc.ToString());
            box_var_mcc.Items.Add(Properties.Settings.Default.fecha_mcc.ToString());
            box_var_mcc.Items.Add(Properties.Settings.Default.hora_mcc.ToString());
            box_var_mcc.Items.Add(Properties.Settings.Default.peso_mcc.ToString());
            box_var_mcc.Items.Add(Properties.Settings.Default.lingotes_mcc.ToString());
            box_var_mcc.Items.Add(Properties.Settings.Default.pacero_mcc.ToString());
        }

        private void Btn_gua_mcc_Click(object sender, EventArgs e)
        {
            if (txt_var_mcc.Text.Trim().Equals("")
                || indice == 0)
            {
                MessageBox.Show("Seleccione una variable");
            }
            else
            {
                switch (indice)
                {
                    case 1:
                        Properties.Settings.Default["num_col_mcc"] = txt_var_mcc.Text;
                        break;
                    case 2:
                        Properties.Settings.Default["fecha_mcc"] = txt_var_mcc.Text;
                        break;
                    case 3:
                        Properties.Settings.Default["hora_mcc"] = txt_var_mcc.Text;
                        break;
                    case 4:
                        Properties.Settings.Default["peso_mcc"] = txt_var_mcc.Text;
                        break;
                    case 5:
                        Properties.Settings.Default["lingotes_mcc"] = txt_var_mcc.Text;
                        break;
                    case 6:
                        Properties.Settings.Default["pacero_mcc"] = txt_var_mcc.Text;
                        break;
                }
            }
            Properties.Settings.Default.Save();
            MessageBox.Show("Configuracion guardada");
            indice = 0;
            txt_var_mcc.Text = "";
            cargar();
        }

        private void Config_var_mcc_Load(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
