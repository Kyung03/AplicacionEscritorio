using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace horno_datos_servidor.clases
{
    class fundidor
    {
        public int Codigo
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public fundidor(int codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}
