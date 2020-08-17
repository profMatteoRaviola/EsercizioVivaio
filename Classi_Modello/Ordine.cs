using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;
using System.Text;

namespace EsercizioVivaio.Classi_Modello
{
    class Ordine
    {
        [Key][Required] public int Id { get; set; } //key primaria dell'ordine
        
        [Required] public int ClienteId { get; set; } //foreign key verso il cliente

        [Required] public DateTime Data { get; set; }

        [Required] public string Mod_pagamento { 
            get {return Mod_pagamento; } 
            set
            {
                Mod_pagamento = value switch //switch con sintassi funzionale... tutto autogenerato
                {
                    "Contrassegno" => value,
                    "PayPal" => value,
                    _ => throw new PagamentoException(nameof(value))
                };
            } }

        public Cliente Cliente { get; set; }
        public ICollection<Dettaglio_Ordine> Dettaglio_Ordini { get; set; }


    }
}
