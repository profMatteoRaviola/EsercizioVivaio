using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsercizioVivaio.Classi_Modello
{
    class Giardino
    {
        [Key]
        [Required]
        public int PiantaID { get; set; } //chiave esterna della pianta che diventa primaria per una pianta da giardino

        [Required]
        public string Stagione { get; set; }

        public Pianta Pianta { get; set; }
    }
}
