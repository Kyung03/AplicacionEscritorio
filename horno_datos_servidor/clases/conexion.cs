using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace horno_datos_servidor.clases
{
    class conexion
    {
        private string Data
        {
            get;
            set;
        }

        private string Puerto
        {
            get;
            set;
        }

        private string Usuario
        {
            get;
            set;
        }

        private string Contraseña
        {
            get;
            set;
        }

        private string Nombre_db
        {
            get;
            set;
        }

        public conexion()
        {
            Data = Properties.Settings.Default.d_source.ToString(); ;
            Puerto = Properties.Settings.Default.puerto.ToString(); ;
            Usuario = Properties.Settings.Default.db_usuario.ToString(); ;
            Contraseña = Properties.Settings.Default.db_contra.ToString(); ;
            Nombre_db = Properties.Settings.Default.db_nombre.ToString(); ;
        }

        public string cadenaconn()
        {
            string conn = "";
            conn += "datasource=" + Data + ";";
            conn += "port=" + Puerto + ";";
            conn += "username=" + Usuario + ";";
            conn += "password=" + Contraseña + ";";
            conn += "database=" + Nombre_db + ";";
            return conn;
        }
    }
}
