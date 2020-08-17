using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsercizioVivaio.Classi_Modello
{
    class Frutta
    {
        [Key]
        [Required]
        public int PiantaID { get; set; } //chiave esterna della pianta che è primaria di  una pianta da Frutta

        [Required]
        public float Produttivita { get; set; } //kg di frutta media prodotta all'anno

        public Pianta Pianta { get; set; }
    }
}
