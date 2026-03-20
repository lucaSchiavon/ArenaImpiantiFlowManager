using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFlowManager.Models.Clienti
{
    public class AnagraficaClientiDto
    {
        
            public int IdAnagraficaCliente { get; set; }
            public int IdStatoAnagrafica { get; set; }
            public int IdCategoriaCliente { get; set; }
            public int Confermato { get; set; }
            public string CodiceCliente { get; set; }
            public string RagioneSociale { get; set; }
            public string Indirizzo { get; set; }
            public string CAP { get; set; }
            public string Comune { get; set; }
            public string Prov { get; set; }
            public string CodicePaese { get; set; }
            public string PIVA { get; set; }
            public string CodiceFiscale { get; set; }
            public string Contatto { get; set; }
            public string CodPaga { get; set; }
            public int? IdPagamento { get; set; }
            public int? IdBancaAppoggio { get; set; }
            public int? IdRegimeIVA { get; set; }
            public string NotaFattura1 { get; set; }
            public string NotaFattura2 { get; set; }
            public string DescrEsenzioneIVA { get; set; }
            public string SitoWeb { get; set; }
            public int PubblicaAmministrazione { get; set; }
            public int FatturaElettronica { get; set; }
            public int InvioFTMail { get; set; }
            public string MailInvioFT { get; set; }
            public int InvioDDTMail { get; set; }
            public string MailInvioDDT { get; set; }
            public double? Fido { get; set; }
            public int PrezzoInDDT { get; set; }
            public int? IdOperatore { get; set; }
            public int FatturaPerDestinazione { get; set; }
            public int? SoloCigCup { get; set; }
            public int AddebitoSpeseIncasso { get; set; }
            public double? ImportoPerScadenza { get; set; }
            public int Privato { get; set; }
            public int? IdBancaAppoggioAzienda { get; set; }
            public int ValidazioneAutomaticaDDT { get; set; }
            public int Pubblicita { get; set; }
            public string CodiceDestinatario { get; set; }
            public string PECFatturaElettronica { get; set; }
            public string MailInvioPreventivo { get; set; }
            public int ScissionePagamenti { get; set; }
            public DateTime DataRecord { get; set; }
       

    }
}
