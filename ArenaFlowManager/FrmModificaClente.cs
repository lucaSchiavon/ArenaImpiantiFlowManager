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
    public partial class FrmModificaClente : Form
    {
        private int _idCliente;
        private ArenaFlowManager.Models.Clienti.AnagraficaClientiDto _cliente;
        public int IdClienteSalvato { get; private set; }

        public FrmModificaClente(int idCliente)
        {
            try
            {
                ClientiRepository repo = new ArenaFlowManager.Repositories.ClientiRepository();

                InitializeComponent();
                _idCliente = idCliente;

                //popola le combo
                CaricaComboSiNo(CboPrivato, true);

                CaricaComboDaDb(CboCategoria, repo.GetCboCategoriaAnagraficaItems(), true);
                CaricaComboDaDb(CboStato, repo.GetCboStatoAnagraficaItems(), true);
                CaricaComboDaDb(CboProvincia, repo.GetCboPrvinceItems(), true);
                CaricaComboDaDb(CboPaese, repo.GetCboPaeseItems(), true);
                CaricaComboDaDb(CboPagamento, repo.GetCboPagamentoItems(), true);
                CaricaComboDaDb(CboBanca, repo.GetCboBancaItems(), true);
                CaricaComboDaDb(CboRegimeIva, repo.GetCboRegimeIvaItems(), true);


                CaricaComboSiNo(CboPubblicaAmm, true);
                CaricaComboSiNo(CboScissionePagamenti, true);
                CaricaComboSiNo(CboConsensoPrivacy, true);


                if (_idCliente > 0)
                {
                    // carica dati

                    var clienti = repo.GetAnagraficaClienti(_idCliente);
                    _cliente = clienti.FirstOrDefault();



                    if (_cliente != null)
                    {
                        //LblTitoloForm.Text = $"Modifica Cliente: {_cliente.RagioneSociale}";

                       
                        //CaricaComboSiNo(CboPrivato, true);

                        //CaricaComboDaDb(CboCategoria, repo.GetCboCategoriaAnagraficaItems(), true);
                        //CaricaComboDaDb(CboStato, repo.GetCboStatoAnagraficaItems(), true);
                        //CaricaComboDaDb(CboProvincia, repo.GetCboPrvinceItems(), true);
                        //CaricaComboDaDb(CboPaese, repo.GetCboPaeseItems(), true);
                        //CaricaComboDaDb(CboPagamento, repo.GetCboPagamentoItems(), true);
                        //CaricaComboDaDb(CboBanca, repo.GetCboBancaItems(), true);
                        //CaricaComboDaDb(CboRegimeIva, repo.GetCboRegimeIvaItems(), true);

                        //CaricaComboSiNo(CboPubblicaAmm, true);
                        //CaricaComboSiNo(CboScissionePagamenti, true);
                        //CaricaComboSiNo(CboConsensoPrivacy, true);

                        // Popola i campi della maschera (esempio)

                        TxtRagSoc.Text = _cliente.RagioneSociale;
                        CboPrivato.SelectedValue = _cliente.Privato.ToString();
                        //TxtCodice.Text = _cliente.CodiceCliente;
                        CboCategoria.SelectedValue = _cliente.IdCategoriaCliente.ToString();
                        CboStato.SelectedValue = _cliente.IdStatoAnagrafica.ToString();
                        //TxtCategoria.Text = _cliente.CategoriaCliente;
                        //TxtStato.Text = _cliente.StatoAnagrafica;

                        TxtIndirizzo.Text = _cliente.Indirizzo;
                        TxtCap.Text = _cliente.CAP;
                        TxtComune.Text = _cliente.Comune;
                        CboProvincia.SelectedValue = _cliente.Prov ?? "-"; //*
                        CboPaese.SelectedValue = _cliente.CodicePaese ?? "-"; //*

                        TxtPIva.Text = _cliente.PIVA;
                        TxtCodFisc.Text = _cliente.CodiceFiscale;
                        TxtContatto.Text = _cliente.Contatto;

                        CboPubblicaAmm.SelectedValue = _cliente.PubblicaAmministrazione.ToString(); //obbligatorio
                        CboScissionePagamenti.SelectedValue = _cliente.ScissionePagamenti.ToString(); //obbligatorio
                        CboConsensoPrivacy.SelectedValue = 0; //todo: da bindare

                        TxtCodDest.Text = _cliente.CodiceDestinatario;
                        TxtPecInvioFattura.Text = _cliente.PECFatturaElettronica;

                        CboPagamento.SelectedValue = _cliente.IdPagamento?.ToString() ?? "_"; //*
                        CboBanca.SelectedValue = _cliente.IdBancaAppoggio?.ToString() ?? "_"; //*
                        //TxtIban.Text = _cliente.; //todo: toglierlo dalla anagrafica
                        CboRegimeIva.SelectedValue = _cliente.IdRegimeIVA?.ToString() ?? "_"; //*

                    }
                }
                else
                {
                    //LblTitoloForm.Text = $"Nuovo Cliente";




                    // Nuovo inserimento
                    _cliente = new ArenaFlowManager.Models.Clienti.AnagraficaClientiDto();
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show($"Errore durante il caricamento dei dati: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                // Recupera dati dai campi della maschera
                _cliente.RagioneSociale = TxtRagSoc.Text;
                _cliente.Privato = Convert.ToInt32(CboPrivato.SelectedValue); //obbligatorio
                //_cliente.CodiceCliente = "L536"; //non c'è nella anagrafica ma lo salvo per non mandare in crash
                _cliente.IdCategoriaCliente = Convert.ToInt32(CboCategoria.SelectedValue); //obbligatorio
                _cliente.IdStatoAnagrafica = Convert.ToInt32(CboStato.SelectedValue); //obbligatorio
                _cliente.Indirizzo = TxtIndirizzo.Text;
                _cliente.CAP = TxtCap.Text;
                _cliente.Comune = TxtComune.Text;
                _cliente.Prov =  CboProvincia.SelectedValue.ToString() == "-" ? (string)null : CboProvincia.SelectedValue.ToString();
                //_cliente.IdBancaAppoggio = (CboBanca.SelectedValue == null || CboBanca.SelectedValue.ToString() == "-") ? (int?)null : Convert.ToInt32(CboBanca.SelectedValue);
                _cliente.CodicePaese = CboPaese.SelectedValue.ToString() == "-" ? (string)null : CboPaese.SelectedValue.ToString();
                _cliente.PIVA = TxtPIva.Text;
                _cliente.CodiceFiscale = TxtCodFisc.Text;
                _cliente.Contatto = TxtContatto.Text;
                _cliente.PubblicaAmministrazione = Convert.ToInt32(CboPubblicaAmm.SelectedValue); //obbligatorio
                _cliente.ScissionePagamenti = Convert.ToInt32(CboScissionePagamenti.SelectedValue);  //obbligatorio      
                //manca consenso privacy.....
                _cliente.CodiceDestinatario = TxtCodDest.Text;
                _cliente.PECFatturaElettronica = TxtPecInvioFattura.Text;
                _cliente.IdPagamento = (CboPagamento.SelectedValue == null || CboPagamento.SelectedValue.ToString() == "-") ? (int?)null : Convert.ToInt32(CboPagamento.SelectedValue);
                _cliente.IdBancaAppoggio = (CboBanca.SelectedValue == null || CboBanca.SelectedValue.ToString() == "-") ? (int?)null : Convert.ToInt32(CboBanca.SelectedValue);
                //il regime iva è obbligatorio per salvare la maschera
                _cliente.IdRegimeIVA= (CboRegimeIva.SelectedValue == null || CboRegimeIva.SelectedValue.ToString() == "-") ? (int?)null : Convert.ToInt32(CboRegimeIva.SelectedValue);


                var repo = new ArenaFlowManager.Repositories.ClientiRepository();
                if (_idCliente == 0)
                {
                    // Inserimento
                    int newId = repo.InsertCliente(_cliente);
                    IdClienteSalvato = newId;
                    MessageBox.Show($"Cliente inserito con id: {newId}", "Inserimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Aggiornamento
                    _cliente.IdAnagraficaCliente = _idCliente;
                    repo.UpdateCliente(_cliente);
                    IdClienteSalvato = _idCliente;
                    MessageBox.Show("Cliente aggiornato", "Aggiornamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                //ricarica i dati del datagridview della form principale


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

            //if (FormInserimento)
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

        private void BtnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void label10_Click(object sender, EventArgs e)
        //{

        //}
        //private void BtnSalva_Click(object sender, EventArgs e)
        //{

        //}
    }
}
