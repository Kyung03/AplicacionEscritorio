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
    public partial class configuracion : Form
    {
        public configuracion()
        {
            InitializeComponent();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            txt_csv.Text = Properties.Settings.Default.archivo_csv.ToString();
            txt_dir.Text = Properties.Settings.Default.directorio_1.ToString();
            txt_res.Text = Properties.Settings.Default.directorio_res.ToString();
            txt_csv_mcc.Text = Properties.Settings.Default.archivo_csv_mcc.ToString();
            txt_min.Text = Properties.Settings.Default.minuto.ToString();
            txt_log.Text = Properties.Settings.Default.directorio_log.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_csv.Text.Trim().Equals("")
                || txt_dir.Text.Trim().Equals("")
                || txt_res.Text.Trim().Equals("")
                || txt_csv_mcc.Text.Trim().Equals("")
                || txt_min.Text.Trim().Equals("")
                || txt_log.Text.Trim().Equals("")
                )
            {
                MessageBox.Show("Llene todas las casillas");
            }
            else
            {
                if (!txt_csv.Text.Equals(Properties.Settings.Default.archivo_csv.ToString())) Properties.Settings.Default["archivo_csv"] = txt_csv.Text;
                if (!txt_dir.Text.Equals(Properties.Settings.Default.directorio_1.ToString())) Properties.Settings.Default["directorio_1"] = txt_dir.Text;
                if (!txt_res.Text.Equals(Properties.Settings.Default.directorio_res.ToString())) Properties.Settings.Default["directorio_res"] = txt_res.Text;
                if (!txt_csv_mcc.Text.Equals(Properties.Settings.Default.archivo_csv_mcc.ToString())) Properties.Settings.Default["archivo_csv_mcc"] = txt_csv_mcc.Text;
                if (!txt_min.Text.Equals(Properties.Settings.Default.minuto.ToString())) Properties.Settings.Default["minuto"] = txt_min.Text;
                if (!txt_log.Text.Equals(Properties.Settings.Default.directorio_log.ToString())) Properties.Settings.Default["directorio_log"] = txt_log.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Configuracion guardada");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            config_variables vconfig = new config_variables();
            vconfig.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            config_bdatos db_config = new config_bdatos();
            db_config.Visible = true;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            config_var_mcc mcc_config = new config_var_mcc();
            mcc_config.Visible = true;
        }

        private void Txt_min_TextChanged(object sender, EventArgs e)
        {
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se aceptan numeros");
                e.Handled = true;

            }
        }
    }
}
