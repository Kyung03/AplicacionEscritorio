using System;
using System.Windows.Forms;
using horno_datos_servidor.clases;
//
namespace horno_datos_servidor.forms
{
    public partial class fun_agr : Form
    {
        DateTime fecha = DateTime.Now;
        private Consultas_fun query = new Consultas_fun();
        string nombre = "";
        string apellido = "";
        string codigo = "";
        public fun_agr( )
        {
            InitializeComponent();
            label4.Text = fecha.ToString("dd/MM/yyyy");
        }

        private void Fun_agr_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (btn_comprobacion())
                {
                    MessageBox.Show("Rellene todos los campos");
                    Console.WriteLine(codigo);
                }
                else
                {
                    nombre = txt_nom_fun.Text.Trim();
                    apellido = txt_ape_fun.Text.Trim();
                    codigo = txt_cod_fun.Text.Trim();
                    Console.WriteLine(nombre);
                    Console.WriteLine(apellido);
                    Console.WriteLine(codigo);
                    if (query.insertar_fundidor(codigo, nombre + " " + apellido, fecha.ToString("yyyy/MM/dd")))
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private bool btn_comprobacion()
        { 
            try
            {
                if (txt_nom_fun.Text.Trim() == ""
                    || txt_ape_fun.Text.Trim().Equals("")
                    || txt_cod_fun.Text.Trim().Equals(""))
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
            //Console.WriteLine(txt_nom_fun.Text);
            if (txt_nom_fun.Text.Trim() == ""
                || txt_ape_fun.Text.Trim().Equals("") )
            {

            }
            else
            {
                codigo = txt_nom_fun.Text.ToCharArray()[0].ToString() + ". " + txt_ape_fun.Text;
                txt_cod_fun.Text = codigo;
            }
        }

        private void Txt_ape_fun_TextChanged(object sender, EventArgs e)
        {
            if (
                txt_nom_fun.Text.Trim() == ""
                || txt_ape_fun.Text.Trim().Equals("") 
                )
            {

            }
            else
            {
                codigo = txt_nom_fun.Text.ToCharArray()[0].ToString() + ". " + txt_ape_fun.Text;
                txt_cod_fun.Text = codigo; 
            }
        }

        private void Fun_agr_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
