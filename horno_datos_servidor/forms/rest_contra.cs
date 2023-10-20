using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using horno_datos_servidor.clases;
//
namespace horno_datos_servidor.forms
{
    public partial class rest_contra : Form
    {
        Consultas bd = new Consultas();
        string usuario = "";
        public rest_contra(string usuariop)
        {
            InitializeComponent();
            usuario = usuariop;
        }

        private void Btn_rest_contra_Click(object sender, EventArgs e)
        {
            if ( txt_contra.Text.Trim().Equals("") || txt_contra_ver.Text.Trim().Equals("") )
            {
                MessageBox.Show("Rellene todos los campos ");
            }
            else
            {
                if (txt_contra.Text.Trim().Equals(txt_contra_ver.Text.Trim()))
                {
                    var contra_hash = ComputeSha256Hash(txt_contra.Text);
                    if (bd.restablecer_contra(usuario, contra_hash))
                    {
                        MessageBox.Show("Contraseña restablecida. ");
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña no coincide ");
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
