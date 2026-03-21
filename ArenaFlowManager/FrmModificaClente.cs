using ArenaFlowManager.Managers;
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
        private FormValidatorManager formValidatorManager;
        public FrmModificaClente(int idCliente)
        {
            try
            {
                ClientiRepository repo = new ArenaFlowManager.Repositories.ClientiRepository();
                formValidatorManager = new FormValidatorManager();
                InitializeComponent();
                AttachEnterHandlers(this); //aggancia la gestione degli eventi Enter e leave a tutti i campi della maschera
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

                        //LblTitoloForm.Text = $"Gestione Anagrafica Clienti - {_cliente.RagioneSociale}";
                        LblTitoloForm.Text = $"Gestione Anagrafica Clienti - Modifica Cliente";
                        // Popola i campi della maschera (esempio)

                        TxtRagSoc.Text = _cliente.RagioneSociale;
                        CboPrivato.SelectedValue = _cliente.Privato.ToString();                 
                        CboCategoria.SelectedValue = _cliente.IdCategoriaCliente.ToString();
                        CboStato.SelectedValue = _cliente.IdStatoAnagrafica.ToString();
                      
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
                        
                        CboRegimeIva.SelectedValue = _cliente.IdRegimeIVA?.ToString() ?? "_"; //*

                    }
                }
                else
                {
                    LblTitoloForm.Text = $"Gestione Anagrafica Clienti - Nuovo Cliente";
                    // Nuovo inserimento
                    _cliente = new ArenaFlowManager.Models.Clienti.AnagraficaClientiDto();
                    //imposta i default
                    CboPrivato.SelectedValue = "0";
                    CboStato.SelectedValue = "1";
                    CboPaese.SelectedValue = "IT";
                    CboPubblicaAmm.SelectedValue= "0";
                    CboScissionePagamenti.SelectedValue = "0";
                    CboConsensoPrivacy.SelectedValue = "0";
                    CboRegimeIva.SelectedValue = "1"; //regime ordinario

                    

                }

                //visualizza campi obbligatori
                bool allValid = formValidatorManager.ValidateRequiredFields(this);
                // Mostra o nasconde il bottone Salva
                BtnSalva.Visible = allValid;

                TxtRagSoc.Focus();
                
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

        private void BtnEsciSenzaSalvare_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

  

        private void CboPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CboBanca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TxtIban.Text = "IT54N0503459380000000000262";
        }

       
        private void AttachEnterHandlers(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Enter -= RequiredField_Enter; // evita doppie associazioni
                    c.Enter += RequiredField_Enter;

                    c.Leave -= RequiredField_Leave;
                    c.Leave += RequiredField_Leave;
                }

                // Ricorsione per pannelli, groupbox, tabpage, ecc.
                if (c.HasChildren)
                    AttachEnterHandlers(c);
            }
        }
        

        //private bool ValidateRequiredFields(Control parent)
        //{
        //    bool isValid = true;

        //    foreach (Control c in parent.Controls)
        //    {
        //        // TEXTBOX
        //        if (c is TextBox tb && (string)tb.Tag == "required")
        //        {
        //            if (string.IsNullOrWhiteSpace(tb.Text))
        //            {
        //                MarkInvalid(tb);
        //                isValid = false;
        //            }
        //            else
        //            {
        //                ClearInvalid(tb);
        //            }
        //        }

        //        // COMBOBOX
        //        if (c is ComboBox cb && (string)cb.Tag == "required")
        //        {
        //            //if (cb.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cb.Text))
        //            //{
        //            if (cb.SelectedValue.ToString() == "-")
        //            {
        //                MarkInvalid(cb);
        //                isValid = false;
        //            }
        //            else
        //            {
        //                ClearInvalid(cb);
        //            }
        //        }

        //        // Ricorsione per pannelli, groupbox, tabpage, ecc.
        //        if (c.HasChildren)
        //        {
        //            if (!ValidateRequiredFields(c))
        //                isValid = false;
        //        }
        //    }

        //    return isValid;
        //}
        //private void MarkInvalid(Control c)
        //{
        //    c.BackColor = Color.MistyRose;
        //    c.ForeColor = Color.DarkRed;

        //    // Bordo rosso (solo se il controllo lo supporta)
        //    if (c is TextBox || c is ComboBox)
        //    {
        //        c.Padding = new Padding(1);
        //        c.BackColor = Color.MistyRose;
        //    }

        //    RequiredToolTip.SetToolTip(c, "Campo obbligatorio");
        //}

        //private void ClearInvalid(Control c)
        //{
        //    c.BackColor = SystemColors.Window;
        //    c.ForeColor = SystemColors.ControlText;
        //    c.Padding = new Padding(0);

        //    RequiredToolTip.SetToolTip(c, "");
        //}

        private void RequiredField_Enter(object sender, EventArgs e)
        {
            if (sender is Control c)
            {
                // Ripristina colori normali quando l’utente entra nel campo
                c.BackColor = SystemColors.Window;
                c.ForeColor = SystemColors.ControlText;
                c.Padding = new Padding(0);

                formValidatorManager.RequiredToolTip.SetToolTip(c, "");
            }
        }

        private void RequiredField_Leave(object sender, EventArgs e)
        {
            // Validazione completa del form
            bool allValid = formValidatorManager.ValidateRequiredFields(this);

            // Mostra o nasconde il bottone Salva
            BtnSalva.Visible = allValid;
        }
    }
}
