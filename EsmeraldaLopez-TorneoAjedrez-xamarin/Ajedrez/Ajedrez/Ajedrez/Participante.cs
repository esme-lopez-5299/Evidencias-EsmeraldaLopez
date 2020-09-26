using System;
using System.Collections.Generic;
using System.Text;

namespace Ajedrez
{
    [Serializable]
    public class Participante
    {
        
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }

        public string NumTel { get; set; }

        public string Edad { get; set; }
    }
}
