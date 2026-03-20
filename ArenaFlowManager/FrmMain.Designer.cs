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
            this.PnlMainContent = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LblFormName = new System.Windows.Forms.Label();
            this.ToolStripMainMenu.SuspendLayout();
            this.contextMenuNuovo.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.ToolStripMainMenu.Size = new System.Drawing.Size(1184, 75);
            this.ToolStripMainMenu.TabIndex = 0;
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
            this.TStripBtnClienti.Click += new System.EventHandler(this.TStripBtnClienti_Click);
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
            // PnlMainContent
            // 
            this.PnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMainContent.Location = new System.Drawing.Point(0, 102);
            this.PnlMainContent.Name = "PnlMainContent";
            this.PnlMainContent.Size = new System.Drawing.Size(1184, 659);
            this.PnlMainContent.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.LblFormName);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1184, 27);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // LblFormName
            // 
            this.LblFormName.AutoSize = true;
            this.LblFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFormName.ForeColor = System.Drawing.Color.Black;
            this.LblFormName.Location = new System.Drawing.Point(3, 3);
            this.LblFormName.Name = "LblFormName";
            this.LblFormName.Size = new System.Drawing.Size(90, 18);
            this.LblFormName.TabIndex = 0;
            this.LblFormName.Text = "Dashboard";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.PnlMainContent);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ToolStripMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arena flow manager - ver 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ToolStripMainMenu.ResumeLayout(false);
            this.ToolStripMainMenu.PerformLayout();
            this.contextMenuNuovo.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Panel PnlMainContent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label LblFormName;
    }
}