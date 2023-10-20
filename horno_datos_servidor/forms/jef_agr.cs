using System;
using System.Windows.Forms;
using horno_datos_servidor.clases;
//
namespace horno_datos_servidor.forms
{
    public partial class jef_agr : Form
    {
        DateTime fecha = DateTime.Now;
        private Consultas_jef jefe_con = new Consultas_jef();
        string nombre = "";
        string apellido = "";
        string codigo = "";
        public jef_agr()
        {
            InitializeComponent();
            label4.Text = fecha.ToString("dd/MM/yyyy");
        }

        private void Jef_agr_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_comprobacion())
                {
                    MessageBox.Show("Rellene todos los campos");
                }
                else
                {
                    nombre = txt_nom_jef.Text.Trim();
                    apellido = txt_ape_jef.Text.Trim();
                    codigo = txt_cod_jef.Text.Trim();
                    if (jefe_con.insertar_jefe(codigo, nombre + " " + apellido, fecha.ToString("yyyy/MM/dd")))
                    {
                        MessageBox.Show("Dato ingresado");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private bool btn_comprobacion()
        {
            try
            {
                if (txt_nom_jef.Text.Trim() == ""
                    || txt_ape_jef.Text.Trim().Equals("")
                    || txt_cod_jef.Text.Trim().Equals(""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { return false; }
        }

        private void Txt_nom_fun_TextChanged(object sender, EventArgs e)
        {
            if (txt_nom_jef.Text.Trim() == ""
                || txt_ape_jef.Text.Trim().Equals(""))
            {

            }
            else
            {
                codigo = txt_nom_jef.Text.ToCharArray()[0].ToString() + ". " + txt_ape_jef.Text;
                txt_cod_jef.Text = codigo;
            }
        }

        private void Txt_ape_fun_TextChanged(object sender, EventArgs e)
        {
            if (
                txt_nom_jef.Text.Trim() == ""
                || txt_ape_jef.Text.Trim().Equals("")
                )
            {

            }
            else
            {
                codigo = txt_nom_jef.Text.ToCharArray()[0].ToString() + ". " + txt_ape_jef.Text;
                txt_cod_jef.Text = codigo;
            }
        }

    }
}
