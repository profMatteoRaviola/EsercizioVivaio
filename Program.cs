using EsercizioVivaio.Classi_Modello;
using System;
using static System.Console;
/*
 Si vuole gestire un vivaio... di seguito lo schema relazionale del DB da creare con approccio code-first
 
 CLIENTE(id, nome, cognome, via, civico, città, cellulare)
 PIANTE(id, nome, prezzo)
 ORDINI(id, data, tipo_pagamento, clienteID)

 FIORI(piantaID, colore)
 GIARDINO(piantaID, stagione)
 FRUTTA(piantaID, produttività)

 DETTAGLIO_ORDINE(id, OrdineID, PiantaID, qta)

 */
namespace EsercizioVivaio
{
    class Program
    {
        static readonly Context context = new Context();
        static void Main()
        {
            Popolazione(); //popolazione del DB
            WriteLine("Popolazione terminata !!");
            context.Clienti.Dump();
            context.Piante.Dump();
            context.Ordini.Dump();
        }
        static void Popolazione()
        { 
            //popolazione utenti
            context.Clienti.Add(new Cliente { Nome = "Matteo", Cognome = "Raviola"});
            context.Clienti.Add(new Cliente { Nome = "Pippo", Cognome = "Pluto" });
            context.Clienti.Add(new Cliente { Nome = "Luigi", Cognome = "Rossi" });
            context.SaveChanges();

            //popolazione piante... posso farlo anche tramite ilo metodo AddRange sapedno che sono gestiti come una pila
            context.Piante.AddRange(new[] {
                new Pianta{ Nome="Pesco", Prezzo=80.2F }, //Id=3
                new Pianta{ Nome="Pino", Prezzo=10.50F }, //Id=2
                new Pianta{ Nome="Orchidea", Prezzo=5.12F } //Id=1
                
            });
            context.SaveChanges();

            //popolazione di fiori, giardino, frutta 1:1
            context.Piante.Find(1).Fiore = new Fiore { Colore = "Rosa" };
            context.Piante.Find(2).Giardino = new Giardino { Stagione = "Primavera" };
            context.Piante.Find(3).Frutta = new Frutta { Produttivita = 100.50F };
            context.SaveChanges();

            //tutto ok -------------------------------------------------------
            //le eccezzioni sollevate qui non vengono catturate dal try/catch
            try
            {
                //popolazione ordini 1:N
                context.Ordini.AddRange(new[]
                {
                    new Ordine { Data = new DateTime(2020, 8, 6), Mod_pagamento = "Contrassegno", ClienteId=1 }, //Id=3
                    new Ordine { Data = new DateTime(2020, 10, 12), Mod_pagamento = "PayPal", ClienteId=2 }, //Id=2
                    new Ordine { Data = new DateTime(2019, 12, 9), Mod_pagamento = "Contrassegno", ClienteId=2 } //Id=1
                });
                context.SaveChanges();
                //popolazione dei dettagli, posso partire sia da Piante che da Ordini
                context.Ordini.Find(1).Dettaglio_Ordini.Add(new Dettaglio_Ordine { PiantaID = 1, Quantita = 2 });
                context.Ordini.Find(1).Dettaglio_Ordini.Add(new Dettaglio_Ordine { PiantaID = 2, Quantita = 1 });
                context.Ordini.Find(2).Dettaglio_Ordini.Add(new Dettaglio_Ordine { PiantaID = 1, Quantita = 10 });
                context.Ordini.Find(3).Dettaglio_Ordini.Add(new Dettaglio_Ordine { PiantaID = 2, Quantita = 4 });
                context.Ordini.Find(3).Dettaglio_Ordini.Add(new Dettaglio_Ordine { PiantaID = 3, Quantita = 2 });
                context.SaveChanges();

                context.Ordini.Add(new Ordine { Data = new DateTime(2015, 4, 4), Mod_pagamento = "A mano", ClienteId = 1 }); 

            }
            catch(PagamentoException e)
            {
                WriteLine(e.Message);
            }
            
        }
    }
}
