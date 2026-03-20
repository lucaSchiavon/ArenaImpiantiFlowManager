using ArenaFlowManager.Models;
using ArenaFlowManager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaFlowManager
{
    public partial class FrmModificaClenteTemp : Form
    {
        private int _idCliente;
        private ArenaFlowManager.Models.Clienti.AnagraficaClientiDto _cliente;

        public FrmModificaClenteTemp(int idCliente)
        {
            ClientiRepository repo = new ArenaFlowManager.Repositories.ClientiRepository();

            InitializeComponent();
            _idCliente = idCliente;

            //carica le combo
            //var items = new List<ComboItem>
            //        {
            //            new ComboItem { Text = "Sì", Value = 1 },
            //            new ComboItem { Text = "No", Value = 0 }
            //        };

            //CboPrivato.DataSource = items;
            //CboPrivato.DisplayMember = "Text";
            //CboPrivato.ValueMember = "Value";
            


            if (_idCliente > 0)
            {
                // Modifica: carica dati
               
               // var clienti = repo.GetAnagraficheClienti("");
                var clienti = repo.GetAnagraficaClienti(_idCliente);
               // _cliente = clienti.FirstOrDefault(c => c.idAnagraficaCliente == _idCliente);
                _cliente = clienti.FirstOrDefault();

               

                if (_cliente != null)
                {
                    LblTitoloForm.Text = $"Modifica Cliente: {_cliente.RagioneSociale}";

                    //popola le combo
                    CaricaComboSiNo(CboPrivato,false);

                    CaricaComboDaDb(CboCategoria, repo.GetCboCategoriaAnagraficaItems(), false);
                    CaricaComboDaDb(CboStato, repo.GetCboStatoAnagraficaItems(), false);
                    CaricaComboDaDb(CboProvincia, repo.GetCboPrvinceItems(), false);
                    CaricaComboDaDb(CboPaese, repo.GetCboPaeseItems(), false);
                    CaricaComboDaDb(CboPagamento, repo.GetCboPagamentoItems(), false);
                    CaricaComboDaDb(CboBanca, repo.GetCboBancaItems(), false);

                    CaricaComboSiNo(CboPubblicaAmm, false);
                    CaricaComboSiNo(CboScissionePagamenti, false);
                    CaricaComboSiNo(CboConsensoPrivacy, false);

                    // Popola i campi della maschera (esempio)

                    TxtRagSoc.Text = _cliente.RagioneSociale;
                    CboPrivato.SelectedValue = _cliente.Privato;
                    TxtCodice.Text = _cliente.CodiceCliente;
                    //TxtCategoria.Text = _cliente.CategoriaCliente;
                    //TxtStato.Text = _cliente.StatoAnagrafica;

                    TxtIndirizzo.Text = _cliente.Indirizzo;
                    TxtCap.Text = _cliente.CAP;
                    TxtComune.Text = _cliente.Comune;
                    CboProvincia.SelectedValue = _cliente.Prov;
                    //TxtPaese.Text = _cliente.Paese;
                    TxtPIva.Text = _cliente.PIVA;
                    TxtCodFisc.Text = _cliente.CodiceFiscale;
                    TxtContatto.Text = _cliente.Contatto;

                    //TxtPubblicaAmm.Text = _cliente.PubblicaAmministrazione ? "Sì" : "No";
                    //TxtScissionepagamenti.Text = _cliente.ScissionePagamenti ? "Sì" : "No";
                    //TxtConsensoPrivacy.Text = cliente.conse

                    TxtCodDest.Text = _cliente.CodiceDestinatario;
                    TxtPecInvioFattura.Text = _cliente.PECFatturaElettronica;
                    //TxtPagamento.Text = _cliente.Pagamento;
                    //TxtBanca.Text = _cliente.Banca;
                    //TxtIban.Text = _cliente.IBAN;
                    //TxtRegimeIva.Text = _cliente.DescrizioneRegimeIVA;


                    // Booleano → Sì/No
                    //TxtPubblicaAmm.Text = _cliente.PubblicaAmministrazione ? "Sì" : "No";
                }
            }
            else
            {
                LblTitoloForm.Text = $"Nuovo Cliente";

                CaricaComboSiNo(CboPrivato, true);

                CaricaComboDaDb(CboCategoria, repo.GetCboCategoriaAnagraficaItems(), true);
                CaricaComboDaDb(CboStato, repo.GetCboStatoAnagraficaItems(), true);
                CaricaComboDaDb(CboProvincia, repo.GetCboPrvinceItems(), true);
                CaricaComboDaDb(CboPaese, repo.GetCboPaeseItems(), true);
                CaricaComboDaDb(CboPagamento, repo.GetCboPagamentoItems(), true);
                CaricaComboDaDb(CboBanca, repo.GetCboBancaItems(), true);

                CaricaComboSiNo(CboPubblicaAmm, true);
                CaricaComboSiNo(CboScissionePagamenti, true);
                CaricaComboSiNo(CboConsensoPrivacy, true);

                //carica default delle combo
                //CboPrivato.SelectedValue = "-";
                //CboCategoria.SelectedValue = "-";
                //CboStato.SelectedValue = "-";
                //CboProvincia.SelectedValue = "-";
                //CboPaese.SelectedValue = "-";
                //CboPagamento.SelectedValue = "-";
                //CboBanca.SelectedValue = "-";
                //CboPubblicaAmm.SelectedValue = "-";
                //CboScissionePagamenti.SelectedValue = "-";
                //CboConsensoPrivacy.SelectedValue = "-";

                // Nuovo inserimento
                _cliente = new ArenaFlowManager.Models.Clienti.AnagraficaClientiDto();
            }
        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            try 
            {
                // Recupera dati dai campi della maschera
                _cliente.RagioneSociale = TxtRagSoc.Text;
                _cliente.Privato =Convert.ToInt32(CboPrivato.SelectedValue) ;
                _cliente.CodiceCliente = TxtCodice.Text;
                _cliente.IdCategoriaCliente = Convert.ToInt32(CboCategoria.SelectedValue);
                _cliente.IdStatoAnagrafica = Convert.ToInt32(CboStato.SelectedValue);
                _cliente.Indirizzo = TxtIndirizzo.Text;
                _cliente.CAP = TxtCap.Text;
                _cliente.Comune = TxtComune.Text;
                _cliente.Prov = CboPaese.SelectedValue.ToString();
                _cliente.PIVA = TxtPIva.Text;
                _cliente.CodiceFiscale = TxtCodFisc.Text;
                _cliente.Contatto = TxtContatto.Text;
                _cliente.PubblicaAmministrazione = Convert.ToInt32(CboPubblicaAmm.SelectedValue);
                _cliente.ScissionePagamenti = Convert.ToInt32(CboScissionePagamenti.SelectedValue);
                //manca consenso privacy.....
                _cliente.CodiceDestinatario = TxtCodDest.Text;
                _cliente.PECFatturaElettronica = TxtPecInvioFattura.Text;
                //_cliente.IdPagamento = Convert.ToInt32(CboPagamento.SelectedValue);
                //_cliente.IdBancaAppoggio = Convert.ToInt32(CboPagamento.SelectedValue);
                _cliente.IdPagamento = 1;
                _cliente.IdBancaAppoggio = 1;
                //_cliente.IBAN = TxtIban.Text;
                //_cliente.idRegimeIVA = GetIdRegimeIVA(TxtRegimeIva.Text);

                _cliente.Prov = CboProvincia.SelectedValue.ToString();
                // ...recupera altri campi...

                var repo = new ArenaFlowManager.Repositories.ClientiRepository();
                if (_idCliente == 0)
                {
                    // Inserimento
                    int newId = repo.InsertCliente(_cliente);
                    MessageBox.Show($"Cliente inserito con id: {newId}", "Inserimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Aggiornamento
                    _cliente.IdAnagraficaCliente = _idCliente;
                    repo.UpdateCliente(_cliente);
                    MessageBox.Show("Cliente aggiornato", "Aggiornamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il salvataggio: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void CaricaComboSiNo(ComboBox combo, Boolean FormInserimento)
        {
            var items = new List<ComboItem>
            {           
              
                new ComboItem { Text = "Sì", Value = "1" },
                new ComboItem { Text = "No", Value = "0" }
            };

            if (FormInserimento)
                items.Add(new ComboItem { Text = "--", Value = "-" });
           
            combo.DataSource = items;
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";

            if (FormInserimento)
                combo.SelectedValue = "-";
        }
        private void CaricaComboDaDb(ComboBox combo,List<ComboItem> LstItems, Boolean FormInserimento)
        {
            if (FormInserimento)
                LstItems.Add(new ComboItem { Text = "--", Value = "-" });

            combo.DataSource = LstItems;
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";

            if (FormInserimento)
                combo.SelectedValue = "-";
        }
        //private void BtnSalva_Click(object sender, EventArgs e)
        //{

        //}
    }
}
