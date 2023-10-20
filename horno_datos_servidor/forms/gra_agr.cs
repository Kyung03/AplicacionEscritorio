using System;
using System.Windows.Forms;
using horno_datos_servidor.clases;
//
namespace horno_datos_servidor.forms
{
    public partial class gra_agr : Form
    {
        string codigo = "";
        string color = "";
        string barra = "";
        string diametro = "";
        string descripcion = "";
        private Consultas_gra grado_con = new Consultas_gra();
        public gra_agr()
        {
            InitializeComponent();
        }

        private void Gra_agr_Load(object sender, EventArgs e)
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
                    codigo = txt_cod_gra.Text ;
                    color = txt_col_gra.Text;
                    barra = txt_bar_gra.Text;
                    diametro = txt_dia_gra.Text;
                    if (grado_con.insertar_grado(codigo, color, diametro, barra ))
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
                if (txt_cod_gra.Text.Trim() == "" 
                    || txt_col_gra.Text.Trim() == "" 
                    || txt_dia_gra.Text.Trim() == ""
                    || txt_bar_gra.Text.Trim() == ""  )
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
