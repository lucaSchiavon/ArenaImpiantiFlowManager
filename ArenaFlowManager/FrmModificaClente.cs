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
        //todo:tutte queste property vanno spostate come protected in un form base,
        //in modo da poterle utilizzare e valorizzare
        //da tutte le form che ne hanno bisogno, e standardizzare così la gestione delle form in tutta l'applicazione
        private int _idCliente;
        //todo:questa property deve rimanere public nel form base:
        public int IdClienteSalvato { get; private set; }
        private bool ValidazioniFormCorrette { get; set; } = true;
        private bool ObbligatorietaCampiFormRispettata { get; set; } = true;
        //todo:questi verranno iniettati con la dependency injection in netcore
        private FormValidatorManager formValidatorManager;
        private ArenaFlowManager.Models.Clienti.AnagraficaClientiDto _cliente;
        public FrmModificaClente(int idCliente)
        {
            try
            {
                ClientiRepository repo = new ArenaFlowManager.Repositories.ClientiRepository();
                formValidatorManager = new FormValidatorManager();

                InitializeComponent();


                SettaProprietaErrorProvidersPerIcontrolliDaValidare();
                

                AttachValidationHandlers(this); //aggancia la gestione degli eventi (per gestire validazioni varie) per tutti i campi della maschera
                
                //espone idcliente a tutta la classe
                //todo:spsostare in un form base come idEntityOfForm
                _idCliente = idCliente;



                //popola le combo
                //todo:spstare CaricaComboSiNo e CaricaComboDaDb in un form base come metodi protected overridable (così si possono anche sovrascrivere),
                //in modo da poterli riutilizzare per tutte le form che necessitano di combo con si/no o
                //combo popolate da db, e standardizzare così la modalità di caricamento delle combo in tutte le form
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
                    //todo:rivedere completamente le repository che utilizzeranno dapper e restituiranno
                    //oggetti già pronti per essere usati nelle maschere,
                    //in modo da non dover fare ulteriori trasformazioni nelle form (es. trasformare idcategoria in ragione sociale categoria per popolare la combo),
                    //ma avere già tutto pronto dalla repository, e semplificare
                    //così il codice delle form che altrimenti diventano troppo "intelligenti" e complesse
                    //implementare unitsofwork anche per gestire meglio le transazioni
                    //quando si devono salvare più oggetti correlati (es. cliente + contatti + indirizzi, ecc.)
                    var clienti = repo.GetAnagraficaClienti(_idCliente);
                    _cliente = clienti.FirstOrDefault();



                    if (_cliente != null)
                    {
                        // Setto form per aggiornamento

                        LblTitoloForm.Text = $"Gestione Anagrafica Clienti - Modifica Cliente";
                        // Popola i campi della maschera (esempio)
                        //todo:qui gestire meglio i null e i valori di default,
                        //magari con dei metodi helper o estensioni
                        //per evitare di appesantire il codice della form con troppi if e controlli
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
                    // Setto form per Nuovo inserimento
                    LblTitoloForm.Text = $"Gestione Anagrafica Clienti - Nuovo Cliente";
                    
                    _cliente = new ArenaFlowManager.Models.Clienti.AnagraficaClientiDto();
                    //imposta i default
                    //todo:qui usare delle costanti o enumerativi
                    //per i valori di default, per rendere il codice più leggibile e manutenibile
                    CboPrivato.SelectedValue = "0";
                    CboStato.SelectedValue = "1";
                    CboPaese.SelectedValue = "IT";
                    CboPubblicaAmm.SelectedValue= "0";
                    CboScissionePagamenti.SelectedValue = "0";
                    CboConsensoPrivacy.SelectedValue = "0";
                    CboRegimeIva.SelectedValue = "1"; //regime ordinario

                    

                }

                //visualizza su caricamento del form quali sono i campi obbligatori            
                ObbligatorietaCampiFormRispettata= formValidatorManager.ValidateRequiredFields(this);
                
                // Mostra o nasconde il bottone Salva a seconda che vi siano o non vi siano campi obbligatori
                BtnSalva.Visible = ObbligatorietaCampiFormRispettata;

                //pone il focus sul primo campo della maschera
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
                var repo = new ArenaFlowManager.Repositories.ClientiRepository();

                // Recupera dati dai campi della maschera
                _cliente.RagioneSociale = TxtRagSoc.Text;
                _cliente.Privato = Convert.ToInt32(CboPrivato.SelectedValue); //obbligatorio
                _cliente.IdCategoriaCliente = Convert.ToInt32(CboCategoria.SelectedValue); //obbligatorio
                _cliente.IdStatoAnagrafica = Convert.ToInt32(CboStato.SelectedValue); //obbligatorio
                _cliente.Indirizzo = TxtIndirizzo.Text;
                _cliente.CAP = TxtCap.Text;
                _cliente.Comune = TxtComune.Text;
                _cliente.Prov = CboProvincia.SelectedValue.ToString() == "-" ? (string)null : CboProvincia.SelectedValue.ToString();
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
                _cliente.IdRegimeIVA = (CboRegimeIva.SelectedValue == null || CboRegimeIva.SelectedValue.ToString() == "-") ? (int?)null : Convert.ToInt32(CboRegimeIva.SelectedValue);


                
                if (_idCliente == 0)
                {
                    // Inserimento
                    int newId = repo.InsertCliente(_cliente);
                    IdClienteSalvato = newId;
                    MessageBox.Show($"Cliente {_cliente.RagioneSociale} inserito", "Inserimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Aggiornamento
                    _cliente.IdAnagraficaCliente = _idCliente;
                    repo.UpdateCliente(_cliente);
                    IdClienteSalvato = _idCliente;
                    MessageBox.Show($"Cliente {_cliente.RagioneSociale} aggiornato", "Aggiornamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void BtnEsciSenzaSalvare_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }



        private void CboBanca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TxtIban.Text = "IT54N0503459380000000000262";
        }

        #region "gestione della validazione dei campi della maschera"
        //gestione centralizzata degli eventi di validazione dei campi,
        //in modo da non dover scrivere codice di validazione specifico per ogni campo, ma gestire tutto in un unico punto
        //todo:spsostare questo metodo in un form base come abstract,
        //e richiamarlo da tutti i form che necessitano di validazione, in modo da standardizzare la gestione delle validazioni in tutte le form
        private void Field_Validating(object sender, CancelEventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "TxtCodFisc":
                    string cf = TxtCodFisc.Text;

                    if (!formValidatorManager.IsCodiceFiscaleValid(cf))
                    {
                        errorProvider1.SetError(TxtCodFisc, "Codice fiscale non valido");
                        ValidazioniFormCorrette = false;
                        //e.Cancel = true; // impedisce di uscire dal controllo
                    }
                    else
                    {
                        errorProvider1.SetError(TxtCodFisc, "");
                        ValidazioniFormCorrette = true;
                    }
                    //ValidateCodiceFiscale(sender, e);
                    break;
                case "TxtPIva":
                    string piva = TxtPIva.Text;

                    if (!formValidatorManager.IsPartitaIvaValidWithRegex(piva))
                    {
                        errorProvider1.SetError(TxtPIva, "PIVA non valida");
                        ValidazioniFormCorrette = false;
                        //e.Cancel = true; // impedisce di uscire dal controllo
                    }
                    else
                    {
                        errorProvider1.SetError(TxtPIva, "");
                        ValidazioniFormCorrette = true;
                    }
                    break;
                    //Aggiungi altri casi per altri campi se necessario
            }

            //BtnSalva.Visible = allValid && ValidazioniFormCorrette;
            BtnSalva.Visible = ObbligatorietaCampiFormRispettata && ValidazioniFormCorrette;
        }

        //todo:anche qui metodo da spostare come abstract in un form base,
        //e richiamare da tutti i form che necessitano di validazione
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
        //todo:anche qui metodo da spostare come abstract in un form base,
        //e richiamare da tutti i form che necessitano di validazione
        private void RequiredField_Leave(object sender, EventArgs e)
        {
            // Validazione completa del form
            //bool allValid = formValidatorManager.ValidateRequiredFields(this);
            ObbligatorietaCampiFormRispettata = formValidatorManager.ValidateRequiredFields(this);

            // Mostra o nasconde il bottone Salva
            //abilita il bottone salva solo se tutti i campi obbligatori sono valorizzati
            //e le validazioni specifiche (es. codice fiscale) sono corrette
            //BtnSalva.Visible = allValid && ValidazioniFormCorrette;
            BtnSalva.Visible = ObbligatorietaCampiFormRispettata && ValidazioniFormCorrette;
        }

        #endregion


        #region "private methods of form"


        private void SettaProprietaErrorProvidersPerIcontrolliDaValidare()
        {
            //todo:qui spostare in un form base come abstract e richiamare
            //questo metodo da tutti i form che necessitano di validazione,
            //in modo da standardizzare la posizione degli error provider per tutti i form

            // Esempio per TxtCodFisc
            errorProvider1.SetIconAlignment(TxtCodFisc, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(TxtCodFisc, 2);
            // Esempio per TxtPIva
            errorProvider1.SetIconAlignment(TxtPIva, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(TxtPIva, 2);
            // Aggiungi altri controlli se necessario
        }
        //todo:spostare in un controllo base come overridable in modo da poterlo sovrascrivere
        private void AttachValidationHandlers(Control parent)
        {
            //todo:spstare nel un form base
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    //eventi per gestire l'obbligatorietà dei campi
                    c.Enter -= RequiredField_Enter; // evita doppie associazioni
                    c.Enter += RequiredField_Enter;

                    c.Leave -= RequiredField_Leave;
                    c.Leave += RequiredField_Leave;


                    //eventi per validazione in tempo reale
                    c.Validating -= Field_Validating;
                    c.Validating += Field_Validating;

                    //c.TextChanged -= Field_TextChanged;
                    //c.TextChanged += Field_TextChanged;
                }

                // Ricorsione per pannelli, groupbox, tabpage, ecc.
                if (c.HasChildren)
                    AttachValidationHandlers(c);
            }
        }

        //caricamento delle combo:
        //todo:spostare questi metodi in un form base come protected overridable,
        //in modo da poterli sovrascrivere se necessario, e standardizzare così il caricamento delle combo in tutte le form
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
        private void CaricaComboDaDb(ComboBox combo, List<ComboItem> LstItems, Boolean FormInserimento)
        {
            if (FormInserimento)
                LstItems.Add(new ComboItem { Text = "--", Value = "-" });

            combo.DataSource = LstItems;
            combo.DisplayMember = "Text";
            combo.ValueMember = "Value";

            if (FormInserimento)
                combo.SelectedValue = "-";
        }

        #endregion








       

       



        
        //private void Field_TextChanged(object sender, EventArgs e)
        //{
        //    switch (((Control)sender).Name)
        //    {
        //        case "TxtCodFisc":
        //            if (formValidatorManager.IsCodiceFiscaleValid(TxtCodFisc.Text))
        //                errorProvider1.SetError(TxtCodFisc, "");
        //            ValidazioniFormCorrette = true;
        //            break;
        //            //case "TxtPIva":
        //            //    ValidatePartitaIva(sender, e);
        //            //    break;
        //            // Aggiungi altri casi per altri campi se necessario
        //    }
        //}



        

    }
}
