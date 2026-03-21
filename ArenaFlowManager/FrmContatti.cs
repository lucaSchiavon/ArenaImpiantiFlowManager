using ArenaFlowManager.Managers;
using ArenaFlowManager.Models;
using ArenaFlowManager.Models.Clienti;
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
    public partial class FrmContatti : Form
    {
        //private int _idCliente;
        //private ArenaFlowManager.Models.Clienti.AnagraficaClientiDto _cliente;
        private int IdCliente { get; set; }
        private int IdContCliente { get; set; }
        public bool DaInserimento { get; private set; }

        private FormValidatorManager formValidatorManager;
        public FrmContatti(int idCliente)
        {
            try
            {
                IdCliente = idCliente;

                ContattiRepository repo = new ArenaFlowManager.Repositories.ContattiRepository();
                formValidatorManager = new FormValidatorManager();

                InitializeComponent();
                AttachEnterHandlers(this); //aggancia la gestione degli eventi Enter e leave a tutti i campi della maschera
                //nsaconde per ora la sezione di inserimento/modifica contatti e ridimensiona la form per mostrare solo la griglia
                this.Height = 527;

                //_idCliente = idCliente;

                //popola le combo

                CaricaComboDaDb(CboTipo, repo.GetCboTipoContattoItems(), true);


                GrigliaSolaLettura();

                BtnElimina.Visible = false;
                BtnModifica.Visible = false;


                CaricaDati(idCliente);

                ClientiRepository repoClienti = new ClientiRepository();
                LblTitoloForm.Text = $"Contatti cliente: {repoClienti.GetAnagraficaClienti(idCliente).FirstOrDefault().RagioneSociale}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il caricamento dei dati: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmContatti_Load(object sender, EventArgs e)
        {
            try
            {
                
                dataGridViewContatti.ClearSelection();
                dataGridViewContatti.CurrentCell = null;
                this.Height = 527;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il caricamento dei dati: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void BtnChiudi_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void CaricaDati(int IdCliente)
        {
            // Carica i dati dei clienti tramite ClientiRepository e li visualizza nella DataGridView tramite bindingSourceClienti
            var repo = new ContattiRepository();
            var lista = repo.GetContatti(IdCliente);
           
            bindingSourceContatti.DataSource = lista;
            dataGridViewContatti.DataSource = bindingSourceContatti;
        }

        private void GrigliaSolaLettura()
        {
            // Imposta il font della griglia
            dataGridViewContatti.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridViewContatti.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridViewContatti.AutoGenerateColumns = false;
            dataGridViewContatti.ReadOnly = true;
            dataGridViewContatti.AllowUserToAddRows = false;
            dataGridViewContatti.AllowUserToDeleteRows = false;
            dataGridViewContatti.AllowUserToResizeRows = false;
            dataGridViewContatti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void BtnNuovo_Click(object sender, EventArgs e)
        {
            DaInserimento = true;
            //mostra il panel per l'inserimento del nuovo contatto
            this.Height = 743;
            this.ControlBox = false; // Disabilita i pulsanti di chiusura, minimizzazione e massimizzazione
            BtnModifica.Visible = false;
            BtnElimina.Visible = false;

            //congela la griglia per evitare che l'utente possa selezionare un altro contatto durante la modifica
            dataGridViewContatti.Enabled = false;

            //visualizza campi obbligatori
            bool allValid = formValidatorManager.ValidateRequiredFields(this);
            // Mostra o nasconde il bottone Salva
            BtnSalva.Visible = allValid;

            CboTipo.Focus();
        }

        private void BtnModifica_Click(object sender, EventArgs e)
        {
            DaInserimento = false;
            //precarica i dati del contatto selezionato nel pannello di inserimento/modifica e mostra il pannello per la modifica
            var repo = new ContattiRepository();
            var CurrentIdContattoSelectedInGrid = Convert.ToInt32(dataGridViewContatti.CurrentCell.OwningRow.Cells["idContattoCliente"].Value);

            if (CurrentIdContattoSelectedInGrid > 0)
            {
                // carica dati

                var contatti = repo.GetContatto(CurrentIdContattoSelectedInGrid);
                var contatto = contatti.FirstOrDefault();

                if (contatto != null)
                {
                    // Popola i campi della maschera (esempio)
                    this.IdContCliente = contatto.IdContattoCliente;
                    CboTipo.SelectedValue = contatto.IdTipoContatto.ToString();
                    TxtContatto.Text = contatto.Contatto;
                    TxtNote.Text = contatto.NotaContatto;
                }

                //mostra il panel per l'inserimento del nuovo contatto
                this.Height = 743;
                BtnElimina.Visible = false;
                BtnNuovo.Visible = false;
                this.ControlBox = false; // Disabilita i pulsanti di chiusura, minimizzazione e massimizzazione

                //congela la griglia per evitare che l'utente possa selezionare un altro contatto durante la modifica
                dataGridViewContatti.Enabled = false;

                //visualizza campi obbligatori
                bool allValid = formValidatorManager.ValidateRequiredFields(this);
                // Mostra o nasconde il bottone Salva
                BtnSalva.Visible = allValid;

                CboTipo.Focus();
            }

        }

        private void BtnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                AnagraficaClienti_Contatto Contatto=new AnagraficaClienti_Contatto();
                

                var repo = new ContattiRepository();

                Contatto.IdAnagraficaCliente = this.IdCliente;
                Contatto.IdTipoContatto = Convert.ToInt32(CboTipo.SelectedValue);
                Contatto.Contatto = TxtContatto.Text;
                Contatto.NotaContatto = TxtNote.Text;

                if (DaInserimento)
                {
                    // Recupera dati dai campi della maschera                 
                   
                    // Inserimento
                    int newId = repo.InsertContatto(Contatto);
                    MessageBox.Show($"Contatto inserito", "Inserimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                    //todo:aggiornare la griglia
                 
                    PulisciForm();
                    this.Height = 527;
                    this.ControlBox = true;
                    dataGridViewContatti.Enabled = true;

                    CaricaDati(IdCliente);
                    SelezionaRigaContatto(newId);
                }
                else
                {
                    var CurrentIdContattoSelectedInGrid = Convert.ToInt32(dataGridViewContatti.CurrentCell.OwningRow.Cells["idContattoCliente"].Value);

                    if (CurrentIdContattoSelectedInGrid > 0)
                    {
                        Contatto.IdContattoCliente = this.IdContCliente; //todo:mettere campo idcontatto cliente
                        // Aggiornamento              
                        repo.UpdateContatto(Contatto);

                        MessageBox.Show("Contatto aggiornato", "Aggiornamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //todo:aggiornare la griglia

                        PulisciForm();
                        this.Height = 527;
                        this.ControlBox = true;
                        dataGridViewContatti.Enabled = true;

                        CaricaDati(IdCliente);
                        SelezionaRigaContatto(this.IdContCliente);
                    }
                       
                }
                BtnElimina.Visible = true;
                BtnModifica.Visible = true;
                BtnNuovo.Visible = true;

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

        private void dataGridViewContatti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnElimina.Visible = true;
            BtnModifica.Visible = true;
            BtnNuovo.Visible = true;
        }

        private void dataGridViewContatti_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnElimina.Visible = true;
            BtnModifica.Visible = true;
            BtnNuovo.Visible = true;
        }

        private void FrmContatti_Shown(object sender, EventArgs e)
        {
            //dataGridViewContatti.ClearSelection();
        }

        private void BtnEsciSenzaSalvare_Click(object sender, EventArgs e)
        {
            PulisciForm();
            this.Height = 527;
            this.ControlBox = true;
            dataGridViewContatti.Enabled = true;

            BtnElimina.Visible = true;
            BtnModifica.Visible = true;
            BtnNuovo.Visible = true;
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }
        private void PulisciForm()
        {
            CboTipo.SelectedValue = "-";
            TxtContatto.Text = string.Empty;
            TxtNote.Text = string.Empty;
        }

        private void dataGridViewContatti_SelectionChanged(object sender, EventArgs e)
        {
         
        }

        private void dataGridViewContatti_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnElimina.Visible = true;
            BtnModifica.Visible = true;
            BtnNuovo.Visible = true;

            this.Height = 527;
        }

        private void dataGridViewContatti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnElimina.Visible = true;
            BtnModifica.Visible = true;
            BtnNuovo.Visible = true;

            this.Height = 527;

        }

        private void BtnElimina_Click(object sender, EventArgs e)
        {
            var CurrentIdContattoSelectedInGrid = Convert.ToInt32(dataGridViewContatti.CurrentCell.OwningRow.Cells["idContattoCliente"].Value);

            if (CurrentIdContattoSelectedInGrid >= 0)
            {
                var repo = new ContattiRepository();
                var Contatto = repo.GetContatto(CurrentIdContattoSelectedInGrid)[0];

                if (MessageBox.Show($"Sei sicuro di voler eliminare il contatto : {Contatto.Contatto}?", "Conferma Eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    repo.EliminaContatto(CurrentIdContattoSelectedInGrid);

                    CaricaDati(IdCliente);
                }
                ;
            }
        }

        private void SelezionaRigaContatto(int idContatto)
        {
            // Deseleziona tutto prima di iniziare
            dataGridViewContatti.ClearSelection();

            foreach (DataGridViewRow row in dataGridViewContatti.Rows)
            {
                if (row.Cells["idContattoCliente"].Value != null &&
                    Convert.ToInt32(row.Cells["idContattoCliente"].Value) == idContatto)
                {
                    // Trovata!
                    row.Selected = true;

                    // Troviamo la prima colonna visibile
                    var colVisibile = dataGridViewContatti.Columns.Cast<DataGridViewColumn>()
                                        .FirstOrDefault(c => c.Visible);

                    if (colVisibile != null)
                    {
                        // Impostare la CurrentCell è fondamentale, ma facciamolo con cautela
                        dataGridViewContatti.CurrentCell = row.Cells[colVisibile.Index];
                    }

                    // Scroll automatico
                    dataGridViewContatti.FirstDisplayedScrollingRowIndex = row.Index;
                    return; // Esci subito dopo aver trovato il cliente
                }
            }
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
