using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 
namespace horno_datos_servidor.clases
{
    class t_usuario
    {
        public int Codigo_tipo
        {
            get;
            set;
        }

        public string Tipo_usuario
        {
            get;
            set;
        }

        public string Descripcion_tipo
        {
            get;
            set;
        }

        public t_usuario(int codigo, string tipo, string descripcion)
        {
            Codigo_tipo = codigo;
            Tipo_usuario = tipo;
            Descripcion_tipo = descripcion;
        }

}
}
