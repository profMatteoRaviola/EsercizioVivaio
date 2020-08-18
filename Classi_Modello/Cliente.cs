using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EsercizioVivaio.Classi_Modello
{
    class Cliente
    {
        public Cliente()
        {
            // Inizializzo una collection vuota.
            Ordini = new List<Ordine>();
        }
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        //navigatio property per associazione N:M
        public ICollection<Ordine> Ordini { get; }
        
    }
}
