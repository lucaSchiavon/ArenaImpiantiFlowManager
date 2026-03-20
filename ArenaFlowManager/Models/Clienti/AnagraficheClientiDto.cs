using System;
//.Models.Clienti
//namespace ArenaFlowManager.Data
namespace ArenaFlowManager.Models.Clienti
{
    public class AnagraficheClientiDto
    {
        public int idAnagraficaCliente { get; set; }
        public string RagioneSociale { get; set; }
        public string CategoriaCliente { get; set; }
        public string StatoAnagrafica { get; set; }
        public string Indirizzo { get; set; }
        public string CAP { get; set; }
        public string Comune { get; set; }
        public string Prov { get; set; }
        public string Paese { get; set; }
        public string PIVA { get; set; }
        public string CodiceFiscale { get; set; }
        public string Contatto { get; set; }
        public string NotaFattura1 { get; set; }
        public string NotaFattura2 { get; set; }
        public string DescrEsenzioneIVA { get; set; }
        public string SitoWeb { get; set; }
        public bool PubblicaAmministrazione { get; set; }
        public bool FatturaElettronica { get; set; }
        public bool InvioFTMail { get; set; }
        public string MailInvioFT { get; set; }
        public bool? InvioDDTMail { get; set; }
        public string MailInvioDDT { get; set; }
        public decimal? Fido { get; set; }
        public string Pagamento { get; set; }
        public string Banca { get; set; }
        public string BancaResi { get; set; }
        public string IBAN { get; set; }
        public bool? PrezzoInDDT { get; set; }
        public int? idRegimeIVA { get; set; }
        public string DescrizioneRegimeIVA { get; set; }
        public int? idStatoAnagrafica { get; set; }
        public int? idCategoriaCliente { get; set; }
        public string CodicePaese { get; set; }
        public int? IdPagamento { get; set; }
        public int? idBancaAppoggioCliente { get; set; }
        public bool? FatturaPerDestinazione { get; set; }
        public bool? SoloCigCup { get; set; }
        public bool? AddebitoSpeseIncasso { get; set; }
        public decimal? ImportoPerScadenza { get; set; }
        public bool Privato { get; set; }
        public int? idBancaAppoggioAzienda { get; set; }
        public bool? BancaPreferenziale { get; set; }
        public bool? ValidazioneAutomaticaDDT { get; set; }
        public bool? Pubblicita { get; set; }
        public string CodiceCliente { get; set; }
        public string CodiceDestinatario { get; set; }
        public string PECFatturaElettronica { get; set; }
        public string MailInvioPreventivo { get; set; }
        public bool ScissionePagamenti { get; set; }
    }
}
