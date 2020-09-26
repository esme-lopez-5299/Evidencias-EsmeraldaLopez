using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2ZapateriaIxchel
{
   public class Inventario
    {
        public int idInventario { get; set; }
        public string Talla { get; set; }
        public short Unidades { get; set; }
        public string AnchoPierna { get; set; }
        public int idZapato { get; set; }
        public List<Zapato> ListaZapato { get; set; }
    }
}
