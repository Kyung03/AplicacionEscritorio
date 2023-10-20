using System;
using System.Windows.Forms;
using horno_datos_servidor.clases;
//
namespace horno_datos_servidor.forms
{
    public partial class jor_agr : Form
    {
        string codigo = "";
        string tipo = "";
        string descripcion = "";
        private Consultas_jor query = new Consultas_jor();
        public jor_agr()
        {
            InitializeComponent();
        }

        private void Jor_agr_Load(object sender, EventArgs e)
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
                    codigo = txt_cod_jor.Text;
                    tipo = txt_tip_jor.Text;
                    descripcion = txt_des_jor.Text;
                    if (query.insertar_jornada(codigo, tipo, descripcion))
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
                if (txt_cod_jor.Text.Trim() == "" || txt_tip_jor.Text.Trim() == "" || txt_des_jor.Text.Trim() == "")
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


    }
}
