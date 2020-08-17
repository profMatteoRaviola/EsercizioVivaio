using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsercizioVivaio.Classi_Modello
{
    class Dettaglio_Ordine
    {
        [Key] public int Id { get; set; }

        [Required] public int Quantita { get; set; }

        [Required] public int PiantaID { get; set; }
        [Required] public int OrdineID { get; set; }

        public Ordine Ordine { get; set; }
        public Pianta Pianta{ get; set; }
    }
}
