using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avilesa.Model
{
    public class Municipio
    {

        public int codigoMunicipio { get; set; }
        public string nombre { get; set; }

        public Municipio() { }
        public Municipio(int codigoMunicipio, string nombre)
        {
            this.nombre = nombre;
            this.codigoMunicipio = codigoMunicipio;
        }

    }
}