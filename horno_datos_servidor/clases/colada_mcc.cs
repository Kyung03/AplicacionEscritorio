using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;
//
namespace horno_datos_servidor.clases
{
    class colada_mcc
    {
        public string NumeroColada_val
        {
            get;
            set;
        }
        public string Fecha_val
        {
            get;
            set;
        }
        public string Hora_val
        {
            get;
            set;
        }
        public string Peso_val
        {
            get;
            set;
        }
        public string Cantidad_lingotes_val
        {
            get;
            set;
        }
        public string Peso_acero_val
        {
            get;
            set;
        }
        public string NumeroColada
        {
            get;
            set;
        }
        public string Fecha
        {
            get;
            set;
        }
        public string Hora
        {
            get;
            set;
        }
        public string Peso
        {
            get;
            set;
        }
        public string Cantidad_lingotes
        {
            get;
            set;
        }
        public string Peso_acero
        {
            get;
            set;
        }

        public colada_mcc()
        {
            NumeroColada = Properties.Settings.Default.num_col_mcc.ToString();
            Fecha = Properties.Settings.Default.fecha_mcc.ToString();
            Hora = Properties.Settings.Default.hora_mcc.ToString();
            Cantidad_lingotes = Properties.Settings.Default.lingotes_mcc.ToString();
            Peso = Properties.Settings.Default.peso_mcc.ToString();
            Peso_acero = Properties.Settings.Default.pacero_mcc.ToString();
        }
    }
}
