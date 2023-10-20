using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace horno_datos_servidor.clases
{
    class estados
    {
        public int Codigo
        {
            get;
            set;
        }

        public string Estado
        {
            get;
            set;
        }

        public estados(int codigo, string tipo)
        {
            Codigo = codigo;
            Estado = tipo;
        }

    }
}
