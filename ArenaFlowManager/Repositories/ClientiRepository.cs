using ArenaFlowManager.Data;
using ArenaFlowManager.Models;
using ArenaFlowManager.Models.Clienti;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace ArenaFlowManager.Repositories
{
    public class ClientiRepository
    {
        private readonly string _connectionString;
        public ClientiRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool EliminaCliente(int idAnagraficaCliente)
        {
            string query = "DELETE FROM [AnagraficaClienti] WHERE [idAnagraficaCliente]=@idAnagraficaCliente";
            using (var dal = new AdoDataLayer(_connectionString))
            {
                dal.AddOrReplaceParameter("@idAnagraficaCliente", idAnagraficaCliente, System.Data.SqlDbType.Int);
                int rowsAffected = dal.ExecuteNonQuery(query);
                return rowsAffected > 0;
            }
        }

        public int InsertCliente(AnagraficaClientiDto cliente)
    {
        string query = @"INSERT INTO [AnagraficaClienti] ([idStatoAnagrafica],[idCategoriaCliente],[Confermato],[CodiceCliente],[RagioneSociale],[Indirizzo],[CAP],[Comune],[Prov],[CodicePaese],[PIVA],[CodiceFiscale],[Contatto],[COD_PAGA],[idPagamento],[idBancaAppoggio],[idRegimeIVA],[NotaFattura1],[NotaFattura2],[DescrEsenzioneIVA],[SitoWeb],[PubblicaAmministrazione],[FatturaElettronica],[InvioFTMail],[MailInvioFT],[InvioDDTMail],[MailInvioDDT],[Fido],[PrezzoInDDT],[idOperatore],[FatturaPerDestinazione],[SoloCigCup],[AddebitoSpeseIncasso],[ImportoPerScadenza],[Privato],[idBancaAppoggioAzienda],[ValidazioneAutomaticaDDT],[Pubblicita],[CodiceDestinatario],[PECFatturaElettronica],[MailInvioPreventivo],[ScissionePagamenti],[DataRecord])
        VALUES (@idStatoAnagrafica,@idCategoriaCliente,@Confermato,@CodiceCliente,@RagioneSociale,@Indirizzo,@CAP,@Comune,@Prov,@CodicePaese,@PIVA,@CodiceFiscale,@Contatto,@COD_PAGA,@idPagamento,@idBancaAppoggio,@idRegimeIVA,@NotaFattura1,@NotaFattura2,@DescrEsenzioneIVA,@SitoWeb,@PubblicaAmministrazione,@FatturaElettronica,@InvioFTMail,@MailInvioFT,@InvioDDTMail,@MailInvioDDT,@Fido,@PrezzoInDDT,@idOperatore,@FatturaPerDestinazione,@SoloCigCup,@AddebitoSpeseIncasso,@ImportoPerScadenza,@Privato,@idBancaAppoggioAzienda,@ValidazioneAutomaticaDDT,@Pubblicita,@CodiceDestinatario,@PECFatturaElettronica,@MailInvioPreventivo,@ScissionePagamenti,@DataRecord); SELECT SCOPE_IDENTITY();";
        using (var dal = new AdoDataLayer(_connectionString))
        {
            dal.AddOrReplaceParameter("@idStatoAnagrafica", cliente.IdStatoAnagrafica , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idCategoriaCliente", cliente.IdCategoriaCliente , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@Confermato", 1, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@CodiceCliente", cliente.CodiceCliente ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@RagioneSociale", cliente.RagioneSociale ?? "", System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Indirizzo", cliente.Indirizzo ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@CAP", cliente.CAP ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Comune", cliente.Comune ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Prov", cliente.Prov ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@CodicePaese", cliente.CodicePaese ?? "IT", System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@PIVA", cliente.PIVA ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@CodiceFiscale", cliente.CodiceFiscale ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Contatto", cliente.Contatto ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@COD_PAGA", cliente.CodPaga ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@idPagamento", cliente.IdPagamento ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idBancaAppoggio", cliente.IdBancaAppoggio ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idRegimeIVA", cliente.IdRegimeIVA ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@NotaFattura1", cliente.NotaFattura1 ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@NotaFattura2", cliente.NotaFattura2 ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@DescrEsenzioneIVA", cliente.DescrEsenzioneIVA ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@SitoWeb", cliente.SitoWeb ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@PubblicaAmministrazione", cliente.PubblicaAmministrazione , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@FatturaElettronica", cliente.FatturaElettronica , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@InvioFTMail", cliente.InvioFTMail , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@MailInvioFT", cliente.MailInvioFT ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@InvioDDTMail", cliente.InvioDDTMail , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@MailInvioDDT", cliente.MailInvioDDT ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Fido", cliente.Fido ?? (object)DBNull.Value, System.Data.SqlDbType.Float);
            dal.AddOrReplaceParameter("@PrezzoInDDT", cliente.PrezzoInDDT , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idOperatore", cliente.IdOperatore ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@FatturaPerDestinazione", cliente.FatturaPerDestinazione , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@SoloCigCup", cliente.SoloCigCup ?? 0, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@AddebitoSpeseIncasso", cliente.AddebitoSpeseIncasso , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@ImportoPerScadenza", cliente.ImportoPerScadenza ?? (object)DBNull.Value, System.Data.SqlDbType.Float);
            dal.AddOrReplaceParameter("@Privato", cliente.Privato , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idBancaAppoggioAzienda", cliente.IdBancaAppoggioAzienda ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@ValidazioneAutomaticaDDT", cliente.ValidazioneAutomaticaDDT, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@Pubblicita", cliente.Pubblicita , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@CodiceDestinatario", cliente.CodiceDestinatario ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@PECFatturaElettronica", cliente.PECFatturaElettronica ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@MailInvioPreventivo", cliente.MailInvioPreventivo ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@ScissionePagamenti", cliente.ScissionePagamenti , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@DataRecord", DateTime.Now, System.Data.SqlDbType.DateTime2);
            object id = dal.ExecuteScalar(query);
            return Convert.ToInt32(id);
        }
    }

    public void UpdateCliente(AnagraficaClientiDto cliente)
    {
        string query = @"UPDATE [AnagraficaClienti] SET [idStatoAnagrafica]=@idStatoAnagrafica,[idCategoriaCliente]=@idCategoriaCliente,[Confermato]=@Confermato,[CodiceCliente]=@CodiceCliente,[RagioneSociale]=@RagioneSociale,[Indirizzo]=@Indirizzo,[CAP]=@CAP,[Comune]=@Comune,[Prov]=@Prov,[CodicePaese]=@CodicePaese,[PIVA]=@PIVA,[CodiceFiscale]=@CodiceFiscale,[Contatto]=@Contatto,[COD_PAGA]=@COD_PAGA,[idPagamento]=@idPagamento,[idBancaAppoggio]=@idBancaAppoggio,[idRegimeIVA]=@idRegimeIVA,[NotaFattura1]=@NotaFattura1,[NotaFattura2]=@NotaFattura2,[DescrEsenzioneIVA]=@DescrEsenzioneIVA,[SitoWeb]=@SitoWeb,[PubblicaAmministrazione]=@PubblicaAmministrazione,[FatturaElettronica]=@FatturaElettronica,[InvioFTMail]=@InvioFTMail,[MailInvioFT]=@MailInvioFT,[InvioDDTMail]=@InvioDDTMail,[MailInvioDDT]=@MailInvioDDT,[Fido]=@Fido,[PrezzoInDDT]=@PrezzoInDDT,[idOperatore]=@idOperatore,[FatturaPerDestinazione]=@FatturaPerDestinazione,[SoloCigCup]=@SoloCigCup,[AddebitoSpeseIncasso]=@AddebitoSpeseIncasso,[ImportoPerScadenza]=@ImportoPerScadenza,[Privato]=@Privato,[idBancaAppoggioAzienda]=@idBancaAppoggioAzienda,[ValidazioneAutomaticaDDT]=@ValidazioneAutomaticaDDT,[Pubblicita]=@Pubblicita,[CodiceDestinatario]=@CodiceDestinatario,[PECFatturaElettronica]=@PECFatturaElettronica,[MailInvioPreventivo]=@MailInvioPreventivo,[ScissionePagamenti]=@ScissionePagamenti,[DataRecord]=@DataRecord WHERE [idAnagraficaCliente]=@idAnagraficaCliente";
        using (var dal = new AdoDataLayer(_connectionString))
        {
            dal.AddOrReplaceParameter("@idAnagraficaCliente", cliente.IdAnagraficaCliente, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idStatoAnagrafica", cliente.IdStatoAnagrafica , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idCategoriaCliente", cliente.IdCategoriaCliente , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@Confermato", 1, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@CodiceCliente", cliente.CodiceCliente ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@RagioneSociale", cliente.RagioneSociale ?? "", System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Indirizzo", cliente.Indirizzo ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@CAP", cliente.CAP ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Comune", cliente.Comune ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Prov", cliente.Prov ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@CodicePaese", cliente.CodicePaese ?? "IT", System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@PIVA", cliente.PIVA ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@CodiceFiscale", cliente.CodiceFiscale ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Contatto", cliente.Contatto ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@COD_PAGA", cliente.CodPaga ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@idPagamento", cliente.IdPagamento ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idBancaAppoggio", cliente.IdBancaAppoggio ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idRegimeIVA", cliente.IdRegimeIVA ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@NotaFattura1", cliente.NotaFattura1 ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@NotaFattura2", cliente.NotaFattura2 ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@DescrEsenzioneIVA", cliente.DescrEsenzioneIVA ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@SitoWeb", cliente.SitoWeb ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@PubblicaAmministrazione", cliente.PubblicaAmministrazione , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@FatturaElettronica", cliente.FatturaElettronica, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@InvioFTMail", cliente.InvioFTMail , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@MailInvioFT", cliente.MailInvioFT ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@InvioDDTMail", cliente.InvioDDTMail , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@MailInvioDDT", cliente.MailInvioDDT ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@Fido", cliente.Fido ?? (object)DBNull.Value, System.Data.SqlDbType.Float);
            dal.AddOrReplaceParameter("@PrezzoInDDT", cliente.PrezzoInDDT , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idOperatore", cliente.IdOperatore ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@FatturaPerDestinazione", cliente.FatturaPerDestinazione , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@SoloCigCup", cliente.SoloCigCup ?? 0, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@AddebitoSpeseIncasso", cliente.AddebitoSpeseIncasso , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@ImportoPerScadenza", cliente.ImportoPerScadenza ?? (object)DBNull.Value, System.Data.SqlDbType.Float);
            dal.AddOrReplaceParameter("@Privato", cliente.Privato , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@idBancaAppoggioAzienda", cliente.IdBancaAppoggio ?? (object)DBNull.Value, System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@ValidazioneAutomaticaDDT", cliente.ValidazioneAutomaticaDDT , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@Pubblicita", cliente.Pubblicita , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@CodiceDestinatario", cliente.CodiceDestinatario ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@PECFatturaElettronica", cliente.PECFatturaElettronica ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@MailInvioPreventivo", cliente.MailInvioPreventivo ?? (object)DBNull.Value, System.Data.SqlDbType.NVarChar);
            dal.AddOrReplaceParameter("@ScissionePagamenti", cliente.ScissionePagamenti , System.Data.SqlDbType.Int);
            dal.AddOrReplaceParameter("@DataRecord", DateTime.Now, System.Data.SqlDbType.DateTime2);
            dal.ExecuteNonQuery(query);
        }
    }

        public List<AnagraficheClientiDto> GetAnagraficheClienti(string ricerca)
        {
            var lista = new List<AnagraficheClientiDto>();
            //string query = @"SELECT [idAnagraficaCliente],[RagioneSociale],[Comune],[Prov],[CAP] FROM [ArenaImpianti].[dbo].[AnagraficheClienti] ";
            string query = @"SELECT top 100 * FROM [ArenaImpianti].[dbo].[AnagraficheClienti] ";
            if (!string.IsNullOrWhiteSpace(ricerca))
            {
                query += "WHERE [RagioneSociale] LIKE @search OR [Comune] LIKE @search OR [Prov] LIKE @search OR [CAP] LIKE @search OR [Contatto] LIKE @search";
            }
            query += " order by RagioneSociale";

            using (var dal = new AdoDataLayer(_connectionString))
            {
                if (!string.IsNullOrWhiteSpace(ricerca))
                {
                    dal.AddOrReplaceParameter("@search", "%" + ricerca + "%", System.Data.SqlDbType.NVarChar);
                }
                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var dto = new AnagraficheClientiDto();
                    foreach (PropertyInfo prop in typeof(AnagraficheClientiDto).GetProperties())
                    {
                        if (dt.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(dto, System.Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
                        }
                    }
                    lista.Add(dto);
                }
            }
            return lista;
        }
        public List<AnagraficaClientiDto> GetAnagraficaClienti(int IdCliente)
        {
            var lista = new List<AnagraficaClientiDto>();
            //string query = @"SELECT [idAnagraficaCliente],[RagioneSociale],[Comune],[Prov],[CAP] FROM [ArenaImpianti].[dbo].[AnagraficheClienti] ";
            string query = @"SELECT * FROM [AnagraficaClienti] ";
          
                query += "WHERE IdAnagraficaCliente=" + IdCliente;
           
            using (var dal = new AdoDataLayer(_connectionString))
            {
               
                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var dto = new AnagraficaClientiDto();
                    foreach (PropertyInfo prop in typeof(AnagraficaClientiDto).GetProperties())
                    {
                        if (dt.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                        {
                            prop.SetValue(dto, System.Convert.ChangeType(row[prop.Name], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType));
                        }
                    }
                    lista.Add(dto);
                }
            }
            return lista;
        }
       
        public List<ComboItem> GetCboCategoriaAnagraficaItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT [idCategoriaCliente],[CategoriaCliente] FROM [STA-CategorieClienti]";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem { Value = row["idCategoriaCliente"].ToString(), Text = row["CategoriaCliente"].ToString() };
                    lista.Add(item);
                }
            }
            return lista;
        }
        public List<ComboItem> GetCboStatoAnagraficaItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT  [idStatoAnagrafica],[StatoAnagrafica] FROM [STA-StatiAnagrafica]";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem {  Value = row["idStatoAnagrafica"].ToString() , Text = row["StatoAnagrafica"].ToString()};
                    lista.Add(item);
                }
            }
            return lista;
        }

        public List<ComboItem> GetCboPrvinceItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT [Prov],[Provincia] FROM [STA-Province]";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem { Value = row["Prov"].ToString(), Text = row["Provincia"].ToString() };
                    lista.Add(item);
                }
            }
            return lista;
        }
        public List<ComboItem> GetCboPaeseItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT [CodicePaese],[Paese] FROM [STA-Paesi]";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem { Value = row["CodicePaese"].ToString(), Text = row["Paese"].ToString() };
                    lista.Add(item);
                }
            }
            return lista;
        }

        public List<ComboItem> GetCboPagamentoItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT [IdPagamento],[DescrPag]  FROM [STA-CodiciPagamento]";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem { Value = row["IdPagamento"].ToString(), Text = row["DescrPag"].ToString() };
                    lista.Add(item);
                }
            }
            return lista;
        }

        public List<ComboItem> GetCboBancaItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT [idBancaAppoggioCliente],[Banca] FROM [STA-BancheAppoggioClienti]";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem { Value = row["idBancaAppoggioCliente"].ToString(), Text = row["Banca"].ToString() };
                    lista.Add(item);
                }
            }
            return lista;
        }

        public List<ComboItem> GetCboRegimeIvaItems()
        {
            var lista = new List<ComboItem>();

            string query = "SELECT [idRegimeIVA],[DescrizioneRegimeIVA] FROM [STA-RegimiIVA]";


            using (var dal = new AdoDataLayer(_connectionString))
            {

                DataTable dt = dal.GetDataTable(query);
                foreach (DataRow row in dt.Rows)
                {
                    var item = new ComboItem { Value = row["idRegimeIVA"].ToString(), Text = row["DescrizioneRegimeIVA"].ToString() };
                    lista.Add(item);
                }
            }
            return lista;
        }

    }
}
