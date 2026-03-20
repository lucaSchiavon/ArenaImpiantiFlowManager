using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFlowManager.Models.Clienti
{
    public class AnagraficaClienti_Contatto
    {
        
            public int IdContattoCliente { get; set; }
            public int IdAnagraficaCliente { get; set; }
            public int IdTipoContatto { get; set; }
            public string Contatto { get; set; }
            public string NotaContatto { get; set; }     
            public DateTime DataRecord { get; set; }
       

    }
}
