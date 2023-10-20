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
    public partial class config_bdatos : Form
    {
        public config_bdatos()
        {
            InitializeComponent();
        }

        private void Config_bdatos_Load(object sender, EventArgs e)
        {
            txt_con.Text = Properties.Settings.Default.d_source.ToString();
            txt_port.Text = Properties.Settings.Default.puerto.ToString();
            txt_usu.Text = Properties.Settings.Default.db_usuario.ToString();
            txt_pas.Text = Properties.Settings.Default.db_contra.ToString();
            txt_data.Text = Properties.Settings.Default.db_nombre.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_con.Text.Trim().Equals("")
                || txt_port.Text.Trim().Equals("")
                || txt_port.Text.Trim().Equals("")
                || txt_usu.Text.Trim().Equals("")
                //|| txt_pas.Text.Trim().Equals("")
                || txt_data.Text.Trim().Equals("")
                )
            {
                MessageBox.Show("Rellene todos los espacios");
            }
            else
            {
                if (!txt_con.Text.Equals(Properties.Settings.Default.d_source.ToString())) Properties.Settings.Default["d_source"] = txt_con.Text;
                if (!txt_port.Text.Equals(Properties.Settings.Default.puerto.ToString())) Properties.Settings.Default["puerto"] = txt_port.Text;
                if (!txt_usu.Text.Equals(Properties.Settings.Default.db_usuario.ToString())) Properties.Settings.Default["db_usuario"] = txt_usu.Text;
                if (!txt_pas.Text.Equals(Properties.Settings.Default.db_contra.ToString())) Properties.Settings.Default["db_contra"] = txt_pas.Text;
                if (!txt_data.Text.Equals(Properties.Settings.Default.db_nombre.ToString())) Properties.Settings.Default["db_nombre"] = txt_data.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Configuracion guardada");
            }
            
        }
    }
}
