using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsercizioVivaio.Classi_Modello
{
    class Fiore
    {
        [Key][Required]
        public int PiantaID { get; set; }

        [Required]
        public string Colore { get; set; }

        public Pianta Pianta { get; set; }
    }
}
