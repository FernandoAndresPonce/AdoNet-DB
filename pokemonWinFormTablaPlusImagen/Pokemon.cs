using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonWinForm
{
    class Pokemon
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string UrlImagen { get; set; } // para obtener la imagen, lo hago a traves de un text.

    }
}
