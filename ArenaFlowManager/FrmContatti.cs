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
        public FrmContatti(int idCliente)
        {
            try
            {
                IdCliente = idCliente;

                ContattiRepository repo = new ArenaFlowManager.Repositories.ContattiRepository();

                InitializeComponent();
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
                    MessageBox.Show($"Contatto inserito con id: {newId}", "Inserimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    var CurrentIdContattoSelectedInGrid = Convert.ToInt32(dataGridViewContatti.CurrentCell.OwningRow.Cells["idContattoCliente"].Value);

                    if (CurrentIdContattoSelectedInGrid > 0)
                    {
                        Contatto.IdContattoCliente = this.IdContCliente; //todo:mettere campo idcontatto cliente
                        // Aggiornamento              
                        repo.UpdateContatto(Contatto);
              
                        //MessageBox.Show("Contatto aggiornato", "Aggiornamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //todo:aggiornare la griglia
                    }
                       
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
            this.DialogResult = DialogResult.OK;
            this.Close();
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
    }
}
