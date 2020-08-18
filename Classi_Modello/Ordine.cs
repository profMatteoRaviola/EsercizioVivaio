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
        public Ordine()
        {
            // Inizializzo una collection vuota.
            Dettaglio_Ordini = new List<Dettaglio_Ordine>();
        }

        [Key][Required] public int Id { get; set; } //key primaria dell'ordine
        
        [Required] public int ClienteId { get; set; } //foreign key verso il cliente

        [Required] public DateTime Data { get; set; }

        private string mod_pagamento;
        [Required]
        public string Mod_pagamento
        {
            get { return mod_pagamento; }
            set
            {
                mod_pagamento = value switch //switch con sintassi funzionale... tutto autogenerato
                {
                    "Contrassegno" => value,
                    "PayPal" => value,
                    _ => throw new PagamentoException(value) //default
                };

            }
        }

        public Cliente Cliente { get; set; }
        public ICollection<Dettaglio_Ordine> Dettaglio_Ordini { get; }


    }
}
