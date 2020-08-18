using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsercizioVivaio.Classi_Modello
{
    class Pianta
    {
        public Pianta()
        {
            // Inizializzo una collection vuota.
            Dettaglio_Ordini = new List<Dettaglio_Ordine>();
        }
        [Key] [Required] public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public float Prezzo { get; set; }

        //associazione N:M
        public ICollection<Dettaglio_Ordine> Dettaglio_Ordini{ get; }

        //associazioni 1:1
        public Fiore Fiore { get; set; }
        public Frutta Frutta { get; set; }
        public Giardino Giardino { get; set; }
    }
}
