using System;
using System.Collections.Generic;
using System.Text;

namespace EsercizioVivaio
{
    class PagamentoException : Exception
    {
        public PagamentoException(string s): base($"Modalità di pagamento '{s}' non consentita!!") { }
    }
}
