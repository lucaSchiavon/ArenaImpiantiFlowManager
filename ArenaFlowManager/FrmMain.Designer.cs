namespace ArenaFlowManager
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.ToolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.TStripBtnNuovo = new System.Windows.Forms.ToolStripButton();
            this.TStripBtnDashboard = new System.Windows.Forms.ToolStripButton();
            this.TStripBtnClienti = new System.Windows.Forms.ToolStripButton();
            this.TStripBtnScheduler = new System.Windows.Forms.ToolStripButton();
            this.TStripBtnAltro = new System.Windows.Forms.ToolStripButton();
            this.contextMenuNuovo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuovoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSecondaryMenu = new System.Windows.Forms.ToolStrip();
            this.TStripLblPageTitle = new System.Windows.Forms.ToolStripLabel();
            this.TStripBtnFiltra = new System.Windows.Forms.ToolStripButton();
            this.TStripTxtRicercaGenerale = new System.Windows.Forms.ToolStripTextBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.ToolStripMainMenu.SuspendLayout();
            this.contextMenuNuovo.SuspendLayout();
            this.ToolStripSecondaryMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStripMainMenu
            // 
            this.ToolStripMainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStripMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.ToolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TStripBtnNuovo,
            this.TStripBtnDashboard,
            this.TStripBtnClienti,
            this.TStripBtnScheduler,
            this.TStripBtnAltro});
            this.ToolStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.ToolStripMainMenu.Name = "ToolStripMainMenu";
            this.ToolStripMainMenu.Size = new System.Drawing.Size(1193, 75);
            this.ToolStripMainMenu.TabIndex = 0;
            this.ToolStripMainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStripMainMenu_ItemClicked);
            // 
            // TStripBtnNuovo
            // 
            this.TStripBtnNuovo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TStripBtnNuovo.ForeColor = System.Drawing.Color.Black;
            this.TStripBtnNuovo.Image = ((System.Drawing.Image)(resources.GetObject("TStripBtnNuovo.Image")));
            this.TStripBtnNuovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TStripBtnNuovo.Margin = new System.Windows.Forms.Padding(2);
            this.TStripBtnNuovo.Name = "TStripBtnNuovo";
            this.TStripBtnNuovo.Padding = new System.Windows.Forms.Padding(2);
            this.TStripBtnNuovo.Size = new System.Drawing.Size(56, 71);
            this.TStripBtnNuovo.Text = "Nuovo";
            this.TStripBtnNuovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TStripBtnNuovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TStripBtnNuovo.Click += new System.EventHandler(this.TStripBtnNuovo_Click);
            // 
            // TStripBtnDashboard
            // 
            this.TStripBtnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TStripBtnDashboard.ForeColor = System.Drawing.Color.Black;
            this.TStripBtnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("TStripBtnDashboard.Image")));
            this.TStripBtnDashboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TStripBtnDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.TStripBtnDashboard.Name = "TStripBtnDashboard";
            this.TStripBtnDashboard.Padding = new System.Windows.Forms.Padding(2);
            this.TStripBtnDashboard.Size = new System.Drawing.Size(72, 71);
            this.TStripBtnDashboard.Text = "Dashboard";
            this.TStripBtnDashboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TStripBtnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // TStripBtnClienti
            // 
            this.TStripBtnClienti.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TStripBtnClienti.ForeColor = System.Drawing.Color.Black;
            this.TStripBtnClienti.Image = ((System.Drawing.Image)(resources.GetObject("TStripBtnClienti.Image")));
            this.TStripBtnClienti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TStripBtnClienti.Margin = new System.Windows.Forms.Padding(2);
            this.TStripBtnClienti.Name = "TStripBtnClienti";
            this.TStripBtnClienti.Padding = new System.Windows.Forms.Padding(2);
            this.TStripBtnClienti.Size = new System.Drawing.Size(56, 71);
            this.TStripBtnClienti.Text = "Clienti";
            this.TStripBtnClienti.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TStripBtnClienti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // TStripBtnScheduler
            // 
            this.TStripBtnScheduler.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TStripBtnScheduler.ForeColor = System.Drawing.Color.Black;
            this.TStripBtnScheduler.Image = ((System.Drawing.Image)(resources.GetObject("TStripBtnScheduler.Image")));
            this.TStripBtnScheduler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TStripBtnScheduler.Margin = new System.Windows.Forms.Padding(2);
            this.TStripBtnScheduler.Name = "TStripBtnScheduler";
            this.TStripBtnScheduler.Padding = new System.Windows.Forms.Padding(2);
            this.TStripBtnScheduler.Size = new System.Drawing.Size(84, 71);
            this.TStripBtnScheduler.Text = "Schedulatore";
            this.TStripBtnScheduler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TStripBtnScheduler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // TStripBtnAltro
            // 
            this.TStripBtnAltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TStripBtnAltro.ForeColor = System.Drawing.Color.Black;
            this.TStripBtnAltro.Image = ((System.Drawing.Image)(resources.GetObject("TStripBtnAltro.Image")));
            this.TStripBtnAltro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TStripBtnAltro.Margin = new System.Windows.Forms.Padding(2);
            this.TStripBtnAltro.Name = "TStripBtnAltro";
            this.TStripBtnAltro.Padding = new System.Windows.Forms.Padding(2);
            this.TStripBtnAltro.Size = new System.Drawing.Size(56, 71);
            this.TStripBtnAltro.Text = "Altro...";
            this.TStripBtnAltro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TStripBtnAltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // contextMenuNuovo
            // 
            this.contextMenuNuovo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoClienteToolStripMenuItem,
            this.nuovoToolStripMenuItem,
            this.entitaToolStripMenuItem});
            this.contextMenuNuovo.Name = "contextMenuNuovo";
            this.contextMenuNuovo.Size = new System.Drawing.Size(156, 70);
            this.contextMenuNuovo.Text = "Altra entità...";
            // 
            // nuovoClienteToolStripMenuItem
            // 
            this.nuovoClienteToolStripMenuItem.Image = global::ArenaFlowManager.Properties.Resources.Customer_;
            this.nuovoClienteToolStripMenuItem.Name = "nuovoClienteToolStripMenuItem";
            this.nuovoClienteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.nuovoClienteToolStripMenuItem.Text = "Cliente";
            this.nuovoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuovoClienteToolStripMenuItem_Click);
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Image = global::ArenaFlowManager.Properties.Resources.Schedulatore;
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.nuovoToolStripMenuItem.Text = "Appuntamento";
            // 
            // entitaToolStripMenuItem
            // 
            this.entitaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("entitaToolStripMenuItem.Image")));
            this.entitaToolStripMenuItem.Name = "entitaToolStripMenuItem";
            this.entitaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.entitaToolStripMenuItem.Text = "Altra entità";
            // 
            // ToolStripSecondaryMenu
            // 
            this.ToolStripSecondaryMenu.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ToolStripSecondaryMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.ToolStripSecondaryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TStripLblPageTitle,
            this.TStripBtnFiltra,
            this.TStripTxtRicercaGenerale});
            this.ToolStripSecondaryMenu.Location = new System.Drawing.Point(0, 75);
            this.ToolStripSecondaryMenu.Name = "ToolStripSecondaryMenu";
            this.ToolStripSecondaryMenu.Size = new System.Drawing.Size(1193, 32);
            this.ToolStripSecondaryMenu.TabIndex = 1;
            // 
            // TStripLblPageTitle
            // 
            this.TStripLblPageTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TStripLblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.TStripLblPageTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.TStripLblPageTitle.Name = "TStripLblPageTitle";
            this.TStripLblPageTitle.Size = new System.Drawing.Size(119, 29);
            this.TStripLblPageTitle.Text = "text example";
            // 
            // TStripBtnFiltra
            // 
            this.TStripBtnFiltra.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TStripBtnFiltra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TStripBtnFiltra.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.TStripBtnFiltra.ForeColor = System.Drawing.Color.Gainsboro;
            this.TStripBtnFiltra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TStripBtnFiltra.Name = "TStripBtnFiltra";
            this.TStripBtnFiltra.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.TStripBtnFiltra.Size = new System.Drawing.Size(78, 29);
            this.TStripBtnFiltra.Text = "Filtra";
            // 
            // TStripTxtRicercaGenerale
            // 
            this.TStripTxtRicercaGenerale.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TStripTxtRicercaGenerale.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TStripTxtRicercaGenerale.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TStripTxtRicercaGenerale.Name = "TStripTxtRicercaGenerale";
            this.TStripTxtRicercaGenerale.Size = new System.Drawing.Size(200, 32);
            this.TStripTxtRicercaGenerale.Text = "Cerca...";
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 107);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(1193, 483);
            this.radGridView1.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1193, 590);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.ToolStripSecondaryMenu);
            this.Controls.Add(this.ToolStripMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arena flow manager - ver 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ToolStripMainMenu.ResumeLayout(false);
            this.ToolStripMainMenu.PerformLayout();
            this.contextMenuNuovo.ResumeLayout(false);
            this.ToolStripSecondaryMenu.ResumeLayout(false);
            this.ToolStripSecondaryMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStripMainMenu;
        private System.Windows.Forms.ToolStripButton TStripBtnAltro;
        private System.Windows.Forms.ToolStripButton TStripBtnNuovo;
        private System.Windows.Forms.ToolStripButton TStripBtnDashboard;
        private System.Windows.Forms.ToolStripButton TStripBtnClienti;
        private System.Windows.Forms.ToolStripButton TStripBtnScheduler;
        private System.Windows.Forms.ContextMenuStrip contextMenuNuovo;
        private System.Windows.Forms.ToolStripMenuItem menuItemCliente;
        private System.Windows.Forms.ToolStripMenuItem menuItemImpegno;
        private System.Windows.Forms.ToolStripMenuItem menuItemAltraEntita;
        private System.Windows.Forms.ToolStripMenuItem nuovoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entitaToolStripMenuItem;
        private System.Windows.Forms.ToolStrip ToolStripSecondaryMenu;
        private System.Windows.Forms.ToolStripLabel TStripLblPageTitle;
        private System.Windows.Forms.ToolStripTextBox TStripTxtRicercaGenerale;
        private System.Windows.Forms.ToolStripButton TStripBtnFiltra;
        private Telerik.WinControls.UI.RadGridView radGridView1;
    }
}