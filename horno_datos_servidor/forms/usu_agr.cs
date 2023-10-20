using System;
using System.Windows.Forms;
using horno_datos_servidor.clases;
using System.Security.Cryptography;
using System.Text;
//
namespace horno_datos_servidor.forms
{
    public partial class usu_agr : Form
    {
        Consultas bd = new Consultas();
        DateTime fecha = DateTime.Now;
        string valores = "";
        string columnas = "";

        public usu_agr(TextBox consola)
        {
            InitializeComponent();
            listar_tipo_usu(consola);
        }

        private void Usu_agr_Load(object sender, EventArgs e)
        {
            //listar_tipo_usu();
            label6.Text = fecha.ToString("yyyy/MM/dd");
            columnas = "nombre_usuario, contraseña_usuario, fecha_creacion, codigo_estado, codigo_clasificacion";
        }

        public void listar_tipo_usu(TextBox consola)
        {
            txt_tip_usu.DataSource = bd.listar_tpu(consola);
            txt_tip_usu.DisplayMember = "Tipo_usuario";
            txt_tip_usu.ValueMember = "Codigo_tipo";
        }
        private bool btn_comprobacion()
        {
            try
            {
                if (txt_tip_usu.SelectedItem == null
                    || txt_nom_usu.Text.Trim() == ""
                    || txt_con_usu.Text.Trim() == "")
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
        private void Btn_usu_agr_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ComputeSha256Hash("password"));
            if (btn_comprobacion())
            {
                MessageBox.Show("Rellene todos los campos ");
            }
            else
            {
                var contra_hash = ComputeSha256Hash(txt_con_usu.Text);

                if (bd.insertar_usuario(txt_nom_usu.Text, contra_hash, fecha.ToString("yyyy/MM/dd"), txt_tip_usu.SelectedValue  ) )
                {
                    MessageBox.Show("Dato ingresado");
                    this.Dispose();
                }
            }
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }


}
