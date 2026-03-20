using ArenaFlowManager.Data;
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

namespace ArenaFlowManager.UserControls
{
    public partial class UcClienti : UserControl
    {
        [Category("Dati Personalizzati")]
        [Description("Il nome del form visualizzato nella barra del titolo")]
        [Browsable(true)] // Forza la visibilità nel Designer
        public String FormName { get; set; }
        //public int CurrentIdCustomerSelectedInGrid { get; set; }
        //BindingList<AnagraficheClientiDto> LstClienti = new BindingList<AnagraficheClientiDto>();
        public UcClienti()
        {
            try
            {
                InitializeComponent();
                FormName = "Clienti";
                GrigliaSolaLettura();

                BtnElimina.Enabled = false;
                BtnModifica.Enabled = false;
                BtnGestioneContatti.Enabled = false;
                BtnDestinazioniDiverse.Enabled = false;

                caricaDati();
                // Sottoscrivi l'evento: scatta ogni volta che i dati cambiano
                dataGridViewClienti.DataBindingComplete += DataGridViewClienti_DataBindingComplete;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Errore durante l'inizializzazione del controllo: " + Ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewClienti_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewClienti.ClearSelection();
            dataGridViewClienti.CurrentCell = null; // Rimuove anche il rettangolo del focus
        }

        private void UcClienti_Load(object sender, EventArgs e)
        {
           
        }

       

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                caricaDati();

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Errore nel caricamento dei dati: " + Ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtRicerca.Text = "";
            var repo = new ClientiRepository();
            var lista = repo.GetAnagraficheClienti(TxtRicerca.Text);
            //var ListaFiltrata = lista.Select(c => new
            //{
            //    c.idAnagraficaCliente,
            //    c.RagioneSociale,
            //    c.Comune,
            //    c.Prov
            //}).ToList();
            bindingSourceClienti.DataSource = lista;
            dataGridViewClienti.DataSource = bindingSourceClienti;

            TxtRicerca.Focus();
        }
        private void TxtRicerca_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                caricaDati();

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Errore nel caricamento dei dati: " + Ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewClienti_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //mi salvo il rowindex a livello pubblico
            //così da poterlo riutilizzare dopo la chiusura del form di modifica cliente
            //per ricaricare i dati e posizionarmi sulla stessa riga

            if (e.RowIndex >= 0)
            {
                var row = dataGridViewClienti.Rows[e.RowIndex];
                var id = row.Cells["idAnagraficaCliente"].Value?.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    //CurrentIdCustomerSelectedInGrid = Convert.ToInt32(id);
                    var FormModificaCliente = new FrmModificaClente(int.Parse(id));
                    if (FormModificaCliente.ShowDialog() == DialogResult.OK)
                    {
                        int idToSelect = FormModificaCliente.IdClienteSalvato;
                        caricaDati();
                        SelezionaRigaCliente(idToSelect);
                        if (dataGridViewClienti.CurrentRow != null)
                        {
                            dataGridViewClienti_SelectionChanged(dataGridViewClienti, EventArgs.Empty);
                        }
                    }
                }
            }
        }

        private void dataGridViewClienti_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            

            if (e.RowIndex >= 0)
            {
                var row = dataGridViewClienti.Rows[e.RowIndex];
                var id = row.Cells["idAnagraficaCliente"].Value?.ToString();

                if (!string.IsNullOrEmpty(id))
                {
                    //CurrentIdCustomerSelectedInGrid = Convert.ToInt32(id);
                    var FormModificaCliente = new FrmModificaClente(int.Parse(id));
                    if (FormModificaCliente.ShowDialog() == DialogResult.OK)
                    {
                        int idToSelect = FormModificaCliente.IdClienteSalvato;
                        caricaDati();
                        SelezionaRigaCliente(idToSelect);
                        if (dataGridViewClienti.CurrentRow != null)
                        {
                            dataGridViewClienti_SelectionChanged(dataGridViewClienti, EventArgs.Empty);
                        }
                    }
                }
            }
        }

        private void BtnNuovo_Click(object sender, EventArgs e)
        {
            var FormModificaCliente = new FrmModificaClente(0);
            if (FormModificaCliente.ShowDialog() == DialogResult.OK)
            {
                int idToSelect = FormModificaCliente.IdClienteSalvato;
                caricaDati();
                SelezionaRigaCliente(idToSelect);

                if (dataGridViewClienti.CurrentRow != null)
                {
                    dataGridViewClienti_SelectionChanged(dataGridViewClienti, EventArgs.Empty);
                }
            }
        }

        //private void dataGridViewClienti_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewClienti.SelectedRows.Count == 0 && dataGridViewClienti.SelectedCells.Count == 0)
        //    {
        //        SvuotaDettagli(); // Un metodo che svuota le textbox a destra
        //        return;
        //    }


        //    var cliente = dataGridViewClienti.CurrentRow.DataBoundItem as Models.Clienti.AnagraficheClientiDto;
        //    if (cliente == null)
        //        return;

        //    //CurrentIdCustomerSelectedInGrid = cliente.idAnagraficaCliente;

        //    TxtRagSoc.Text = cliente.RagioneSociale;
        //    TxtPrivato.Text = cliente.Privato ? "Sì" : "No";
        //    //TxtCodice.Text = cliente.CodiceCliente;
        //    TxtCategoria.Text = cliente.CategoriaCliente;
        //    TxtStato.Text = cliente.StatoAnagrafica;

        //    TxtIndirizzo.Text = cliente.Indirizzo;
        //    TxtCap.Text = cliente.CAP;
        //    TxtComune.Text = cliente.Comune;
        //    TxtProvincia.Text = cliente.Prov;
        //    TxtPaese.Text = cliente.Paese;
        //    TxtPIva.Text = cliente.PIVA;
        //    TxtCodFisc.Text = cliente.CodiceFiscale;
        //    TxtContatto.Text = cliente.Contatto;

        //    TxtPubblicaAmm.Text = cliente.PubblicaAmministrazione ? "Sì" : "No";
        //    TxtScissionepagamenti.Text = cliente.ScissionePagamenti ? "Sì" : "No";
        //    //todo:da bindare
        //    TxtConsensoPrivacy.Text = "NO";

        //    TxtCodDest.Text = cliente.CodiceDestinatario;
        //    TxtPecInvioFattura.Text = cliente.PECFatturaElettronica;
        //    TxtPagamento.Text = cliente.Pagamento;
        //    TxtBanca.Text = cliente.Banca;
        //    TxtIban.Text = cliente.IBAN;
        //    TxtRegimeIva.Text = cliente.DescrizioneRegimeIVA;


        //    // Booleano → Sì/No
        //    //TxtPubblicaAmm.Text = cliente.PubblicaAmministrazione ? "Sì" : "No";

        //    BtnElimina.Enabled = true;
        //    BtnModifica.Enabled = true;
        //    BtnGestioneContatti.Enabled = true;
        //    BtnDestinazioniDiverse.Enabled = true;
        //}

        private void dataGridViewClienti_SelectionChanged(object sender, EventArgs e)
        {
            // 1. Controllo di sicurezza: se non c'è selezione o se la riga corrente è null
            if (dataGridViewClienti.CurrentRow == null ||
                (dataGridViewClienti.SelectedRows.Count == 0 && dataGridViewClienti.SelectedCells.Count == 0))
            {
                SvuotaDettagli();
                return;
            }

            // 2. Uso il ?. per evitare crash se DataBoundItem non è ancora pronto
            var cliente = dataGridViewClienti.CurrentRow.DataBoundItem as Models.Clienti.AnagraficheClientiDto;

            if (cliente == null)
            {
                SvuotaDettagli();
                return;
            }

            // 3. Popolamento dati (il tuo codice attuale...)
            TxtRagSoc.Text = cliente.RagioneSociale;
            TxtPrivato.Text = cliente.Privato ? "Sì" : "No";
            //TxtCodice.Text = cliente.CodiceCliente;
            TxtCategoria.Text = cliente.CategoriaCliente;
            TxtStato.Text = cliente.StatoAnagrafica;

            TxtIndirizzo.Text = cliente.Indirizzo;
            TxtCap.Text = cliente.CAP;
            TxtComune.Text = cliente.Comune;
            TxtProvincia.Text = cliente.Prov;
            TxtPaese.Text = cliente.Paese;
            TxtPIva.Text = cliente.PIVA;
            TxtCodFisc.Text = cliente.CodiceFiscale;
            TxtContatto.Text = cliente.Contatto;

            TxtPubblicaAmm.Text = cliente.PubblicaAmministrazione ? "Sì" : "No";
            TxtScissionepagamenti.Text = cliente.ScissionePagamenti ? "Sì" : "No";
            //todo:da bindare
            TxtConsensoPrivacy.Text = "NO";

            TxtCodDest.Text = cliente.CodiceDestinatario;
            TxtPecInvioFattura.Text = cliente.PECFatturaElettronica;
            TxtPagamento.Text = cliente.Pagamento;
            TxtBanca.Text = cliente.Banca;
            TxtIban.Text = cliente.IBAN;
            TxtRegimeIva.Text = cliente.DescrizioneRegimeIVA;


            BtnElimina.Enabled = true;
            BtnModifica.Enabled = true;
            BtnGestioneContatti.Enabled = true;
            BtnDestinazioniDiverse.Enabled = true;
        }

        //private void dataGridViewClienti_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewClienti.SelectedRows.Count == 0 && dataGridViewClienti.SelectedCells.Count == 0)
        //    {
        //        SvuotaDettagli(); // Un metodo che svuota le textbox a destra
        //        return;
        //    }


        //    var cliente = dataGridViewClienti.CurrentRow.DataBoundItem as Models.Clienti.AnagraficheClientiDto;
        //    if (cliente == null)
        //        return;

        //    //CurrentIdCustomerSelectedInGrid = cliente.idAnagraficaCliente;

        //    TxtRagSoc.Text = cliente.RagioneSociale;
        //    TxtPrivato.Text = cliente.Privato ? "Sì" : "No";
        //    //TxtCodice.Text = cliente.CodiceCliente;
        //    TxtCategoria.Text = cliente.CategoriaCliente;
        //    TxtStato.Text = cliente.StatoAnagrafica;

        //    TxtIndirizzo.Text = cliente.Indirizzo;
        //    TxtCap.Text = cliente.CAP;
        //    TxtComune.Text = cliente.Comune;
        //    TxtProvincia.Text = cliente.Prov;
        //    TxtPaese.Text = cliente.Paese;
        //    TxtPIva.Text = cliente.PIVA;
        //    TxtCodFisc.Text = cliente.CodiceFiscale;
        //    TxtContatto.Text = cliente.Contatto;

        //    TxtPubblicaAmm.Text = cliente.PubblicaAmministrazione ? "Sì" : "No";
        //    TxtScissionepagamenti.Text = cliente.ScissionePagamenti ? "Sì" : "No";
        //    //todo:da bindare
        //    TxtConsensoPrivacy.Text = "NO";

        //    TxtCodDest.Text = cliente.CodiceDestinatario;
        //    TxtPecInvioFattura.Text = cliente.PECFatturaElettronica;
        //    TxtPagamento.Text = cliente.Pagamento;
        //    TxtBanca.Text = cliente.Banca;
        //    TxtIban.Text = cliente.IBAN;
        //    TxtRegimeIva.Text = cliente.DescrizioneRegimeIVA;


        //    // Booleano → Sì/No
        //    //TxtPubblicaAmm.Text = cliente.PubblicaAmministrazione ? "Sì" : "No";

        //    BtnElimina.Enabled = true;
        //    BtnModifica.Enabled = true;
        //    BtnGestioneContatti.Enabled = true;
        //    BtnDestinazioniDiverse.Enabled = true;
        //}

        private void SvuotaDettagli()
        {
            // Campi Anagrafica Principale
            TxtRagSoc.Text = string.Empty;
            TxtPrivato.Text = string.Empty;
            TxtCategoria.Text = string.Empty;
            TxtStato.Text = string.Empty;

            // Campi Indirizzo e Località
            TxtIndirizzo.Text = string.Empty;
            TxtCap.Text = string.Empty;
            TxtComune.Text = string.Empty;
            TxtProvincia.Text = string.Empty;
            TxtPaese.Text = string.Empty;
            TxtPIva.Text = string.Empty;
            TxtCodFisc.Text = string.Empty;
            TxtContatto.Text = string.Empty;

            // Campi Amministrativi e Privacy
            TxtPubblicaAmm.Text = string.Empty;
            TxtScissionepagamenti.Text = string.Empty;
            TxtConsensoPrivacy.Text = string.Empty;

            // Campi Fatturazione e Pagamenti
            TxtCodDest.Text = string.Empty;
            TxtPecInvioFattura.Text = string.Empty;
            TxtPagamento.Text = string.Empty;
            TxtBanca.Text = string.Empty;
            TxtIban.Text = string.Empty;
            TxtRegimeIva.Text = string.Empty;

            // Reset pulsanti azione (opzionale ma consigliato)
            BtnElimina.Enabled = false;
            BtnModifica.Enabled = false;
            BtnGestioneContatti.Enabled = false;
            BtnDestinazioniDiverse.Enabled = false;
        }

        private void GrigliaSolaLettura()
        {
            //foreach (DataGridViewColumn col in dataGridViewClienti.Columns)
            //{
            //    col.ReadOnly = true;
            //}

            // Imposta il font della griglia
            dataGridViewClienti.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridViewClienti.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            // Imposta le colonne a larghezza fissa e abilita l'andata a capo
            //foreach (DataGridViewColumn col in dataGridViewClienti.Columns)
            //{
            //    col.ReadOnly = true;
            //    col.Width = 300; // Imposta la larghezza fissa desiderata (puoi modificarla)
            //    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //}
            dataGridViewClienti.AutoGenerateColumns = false;
            dataGridViewClienti.ReadOnly = true;
            dataGridViewClienti.AllowUserToAddRows = false;
            dataGridViewClienti.AllowUserToDeleteRows = false;
            dataGridViewClienti.AllowUserToResizeRows = false;
            dataGridViewClienti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClienti.MultiSelect = false;

            //abilita l'oirdinamento automatico cliccando sull'intestazione della colonna
            //non funziona con list....
            foreach (DataGridViewColumn col in dataGridViewClienti.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }

        }
        private void caricaDati()
        {
            // Carica i dati dei clienti tramite ClientiRepository e li visualizza nella DataGridView tramite bindingSourceClienti
            var repo = new ClientiRepository();
            var lista = repo.GetAnagraficheClienti(TxtRicerca.Text);
           
            bindingSourceClienti.DataSource = lista;
            dataGridViewClienti.DataSource = bindingSourceClienti;

        }

        private void BtnGestioneContatti_Click(object sender, EventArgs e)
        {
            var CurrentIdCustomerSelectedInGrid = Convert.ToInt32(dataGridViewClienti.CurrentCell.OwningRow.Cells["idAnagraficaCliente"].Value);

            if (CurrentIdCustomerSelectedInGrid >= 0)
            {

                var FrmContatti = new FrmContatti(CurrentIdCustomerSelectedInGrid);

                FrmContatti.ShowDialog();
                //if (FrmContatti.ShowDialog() == DialogResult.OK)
                //{
                //    int idToSelect = FormModificaCliente.IdClienteSalvato;
                //    caricaDati();
                //    SelezionaRigaCliente(idToSelect);
                //}
            }
        }

        private void BtnModifica_Click(object sender, EventArgs e)
        {
            var CurrentIdCustomerSelectedInGrid = Convert.ToInt32(dataGridViewClienti.CurrentCell.OwningRow.Cells["idAnagraficaCliente"].Value);
            
            if (CurrentIdCustomerSelectedInGrid >= 0)
            {
                
                var FormModificaCliente = new FrmModificaClente(CurrentIdCustomerSelectedInGrid);
                if (FormModificaCliente.ShowDialog() == DialogResult.OK)
                {
                    int idToSelect = FormModificaCliente.IdClienteSalvato;
                    caricaDati();
                    SelezionaRigaCliente(idToSelect);
                    if (dataGridViewClienti.CurrentRow != null)
                    {
                        dataGridViewClienti_SelectionChanged(dataGridViewClienti, EventArgs.Empty);
                    }
                }
            }

       
        }
        //private void SelezionaRigaCliente(int idCliente)
        //{
        //    foreach (DataGridViewRow row in dataGridViewClienti.Rows)
        //    {
        //        if (row.Cells["idAnagraficaCliente"].Value != null && Convert.ToInt32(row.Cells["idAnagraficaCliente"].Value) == idCliente)
        //        {
        //            row.Selected = true;
        //            // Imposta la cella corrente (sposta la freccia nera)
        //            //dataGridViewClienti.CurrentCell = row.Cells[0];
        //            // Trova la prima colonna visibile
        //            DataGridViewColumn colVisibile = dataGridViewClienti.Columns
        //                .Cast<DataGridViewColumn>()
        //                .FirstOrDefault(c => c.Visible);

        //            if (colVisibile != null)
        //            {
        //                dataGridViewClienti.CurrentCell = row.Cells[colVisibile.Index];
        //            }
        //            // Scrolla fino alla riga
        //            dataGridViewClienti.FirstDisplayedScrollingRowIndex = row.Index;
        //            break;
        //        }
        //    }
        //}

        private void SelezionaRigaCliente(int idCliente)
        {
            // Deseleziona tutto prima di iniziare
            dataGridViewClienti.ClearSelection();

            foreach (DataGridViewRow row in dataGridViewClienti.Rows)
            {
                if (row.Cells["idAnagraficaCliente"].Value != null &&
                    Convert.ToInt32(row.Cells["idAnagraficaCliente"].Value) == idCliente)
                {
                    // Trovata!
                    row.Selected = true;

                    // Troviamo la prima colonna visibile
                    var colVisibile = dataGridViewClienti.Columns.Cast<DataGridViewColumn>()
                                        .FirstOrDefault(c => c.Visible);

                    if (colVisibile != null)
                    {
                        // Impostare la CurrentCell è fondamentale, ma facciamolo con cautela
                        dataGridViewClienti.CurrentCell = row.Cells[colVisibile.Index];
                    }

                    // Scroll automatico
                    dataGridViewClienti.FirstDisplayedScrollingRowIndex = row.Index;
                    return; // Esci subito dopo aver trovato il cliente
                }
            }
        }

        private void BtnElimina_Click(object sender, EventArgs e)
        {
            var CurrentIdCustomerSelectedInGrid = Convert.ToInt32(dataGridViewClienti.CurrentCell.OwningRow.Cells["idAnagraficaCliente"].Value);

            if (CurrentIdCustomerSelectedInGrid >= 0)
            {
                var repo = new ClientiRepository();
                var Cliente = repo.GetAnagraficaClienti(CurrentIdCustomerSelectedInGrid)[0];

                if (MessageBox.Show($"Sei sicuro di voler eliminare il cliente con ragione sociale: {Cliente.RagioneSociale}?", "Conferma Eliminazione", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            
                            repo.EliminaCliente(CurrentIdCustomerSelectedInGrid);
                            caricaDati();
                        };
            }
        }
    }
}
