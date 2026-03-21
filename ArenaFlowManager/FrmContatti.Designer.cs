namespace ArenaFlowManager
{
    partial class FrmContatti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContatti));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblTitoloForm = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TxtNote = new System.Windows.Forms.TextBox();
            this.TxtContatto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.CboTipo = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dataGridViewContatti = new System.Windows.Forms.DataGridView();
            this.IdContattoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoContatto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contatto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnNuovo = new System.Windows.Forms.Button();
            this.BtnModifica = new System.Windows.Forms.Button();
            this.BtnElimina = new System.Windows.Forms.Button();
            this.bindingSourceContatti = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnSalva = new System.Windows.Forms.Button();
            this.BtnEsciSenzaSalvare = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContatti)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceContatti)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.LblTitoloForm);
            this.panel1.ForeColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 52);
            this.panel1.TabIndex = 4;
            // 
            // LblTitoloForm
            // 
            this.LblTitoloForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitoloForm.ForeColor = System.Drawing.Color.White;
            this.LblTitoloForm.Location = new System.Drawing.Point(0, 11);
            this.LblTitoloForm.Name = "LblTitoloForm";
            this.LblTitoloForm.Size = new System.Drawing.Size(1013, 32);
            this.LblTitoloForm.TabIndex = 0;
            this.LblTitoloForm.Text = "Gestione Contatti";
            this.LblTitoloForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel6.Controls.Add(this.TxtNote);
            this.panel6.Controls.Add(this.TxtContatto);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.CboTipo);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Location = new System.Drawing.Point(12, 489);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1013, 139);
            this.panel6.TabIndex = 42;
            // 
            // TxtNote
            // 
            this.TxtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNote.Location = new System.Drawing.Point(19, 68);
            this.TxtNote.Multiline = true;
            this.TxtNote.Name = "TxtNote";
            this.TxtNote.Size = new System.Drawing.Size(977, 55);
            this.TxtNote.TabIndex = 50;
            // 
            // TxtContatto
            // 
            this.TxtContatto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtContatto.Location = new System.Drawing.Point(509, 14);
            this.TxtContatto.Name = "TxtContatto";
            this.TxtContatto.Size = new System.Drawing.Size(487, 24);
            this.TxtContatto.TabIndex = 49;
            this.TxtContatto.Tag = "required";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(419, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 24);
            this.label15.TabIndex = 34;
            this.label15.Text = "Contatto:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(977, 26);
            this.label14.TabIndex = 31;
            this.label14.Text = "Note:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CboTipo
            // 
            this.CboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipo.FormattingEnabled = true;
            this.CboTipo.Location = new System.Drawing.Point(112, 14);
            this.CboTipo.Name = "CboTipo";
            this.CboTipo.Size = new System.Drawing.Size(287, 26);
            this.CboTipo.TabIndex = 47;
            this.CboTipo.Tag = "required";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 26);
            this.label22.TabIndex = 29;
            this.label22.Text = "Tipo contatto:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewContatti
            // 
            this.dataGridViewContatti.AllowUserToAddRows = false;
            this.dataGridViewContatti.AllowUserToDeleteRows = false;
            this.dataGridViewContatti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContatti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdContattoCliente,
            this.TipoContatto,
            this.Contatto,
            this.Nota});
            this.dataGridViewContatti.Location = new System.Drawing.Point(12, 70);
            this.dataGridViewContatti.Name = "dataGridViewContatti";
            this.dataGridViewContatti.ReadOnly = true;
            this.dataGridViewContatti.Size = new System.Drawing.Size(1013, 345);
            this.dataGridViewContatti.TabIndex = 44;
            this.dataGridViewContatti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContatti_CellContentClick);
            this.dataGridViewContatti.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContatti_CellDoubleClick);
            this.dataGridViewContatti.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewContatti_RowHeaderMouseClick);
            this.dataGridViewContatti.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewContatti_RowHeaderMouseDoubleClick);
            this.dataGridViewContatti.SelectionChanged += new System.EventHandler(this.dataGridViewContatti_SelectionChanged);
            // 
            // IdContattoCliente
            // 
            this.IdContattoCliente.DataPropertyName = "idContattoCliente";
            this.IdContattoCliente.HeaderText = "IdContattoCliente";
            this.IdContattoCliente.Name = "IdContattoCliente";
            this.IdContattoCliente.ReadOnly = true;
            this.IdContattoCliente.Visible = false;
            this.IdContattoCliente.Width = 5;
            // 
            // TipoContatto
            // 
            this.TipoContatto.DataPropertyName = "TipoContatto";
            this.TipoContatto.HeaderText = "Tipo";
            this.TipoContatto.Name = "TipoContatto";
            this.TipoContatto.ReadOnly = true;
            this.TipoContatto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TipoContatto.Width = 200;
            // 
            // Contatto
            // 
            this.Contatto.DataPropertyName = "Contatto";
            this.Contatto.HeaderText = "Contatto";
            this.Contatto.Name = "Contatto";
            this.Contatto.ReadOnly = true;
            this.Contatto.Width = 250;
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "NotaContatto";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.ReadOnly = true;
            this.Nota.Width = 520;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.flowLayoutPanel2.Controls.Add(this.BtnNuovo);
            this.flowLayoutPanel2.Controls.Add(this.BtnModifica);
            this.flowLayoutPanel2.Controls.Add(this.BtnElimina);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 421);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1013, 62);
            this.flowLayoutPanel2.TabIndex = 45;
            // 
            // BtnNuovo
            // 
            this.BtnNuovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuovo.Location = new System.Drawing.Point(935, 8);
            this.BtnNuovo.Name = "BtnNuovo";
            this.BtnNuovo.Size = new System.Drawing.Size(75, 39);
            this.BtnNuovo.TabIndex = 0;
            this.BtnNuovo.Text = "Nuovo";
            this.BtnNuovo.UseVisualStyleBackColor = true;
            this.BtnNuovo.Click += new System.EventHandler(this.BtnNuovo_Click);
            // 
            // BtnModifica
            // 
            this.BtnModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModifica.Location = new System.Drawing.Point(846, 8);
            this.BtnModifica.Name = "BtnModifica";
            this.BtnModifica.Size = new System.Drawing.Size(83, 39);
            this.BtnModifica.TabIndex = 2;
            this.BtnModifica.Text = "Modifica";
            this.BtnModifica.UseVisualStyleBackColor = true;
            this.BtnModifica.Click += new System.EventHandler(this.BtnModifica_Click);
            // 
            // BtnElimina
            // 
            this.BtnElimina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElimina.Location = new System.Drawing.Point(765, 8);
            this.BtnElimina.Name = "BtnElimina";
            this.BtnElimina.Size = new System.Drawing.Size(75, 39);
            this.BtnElimina.TabIndex = 1;
            this.BtnElimina.Text = "Elimina";
            this.BtnElimina.UseVisualStyleBackColor = true;
            this.BtnElimina.Click += new System.EventHandler(this.BtnElimina_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.BtnSalva);
            this.flowLayoutPanel1.Controls.Add(this.BtnEsciSenzaSalvare);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 634);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1013, 62);
            this.flowLayoutPanel1.TabIndex = 46;
            // 
            // BtnSalva
            // 
            this.BtnSalva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalva.Location = new System.Drawing.Point(935, 8);
            this.BtnSalva.Name = "BtnSalva";
            this.BtnSalva.Size = new System.Drawing.Size(75, 39);
            this.BtnSalva.TabIndex = 0;
            this.BtnSalva.Text = "Salva";
            this.BtnSalva.UseVisualStyleBackColor = true;
            this.BtnSalva.Click += new System.EventHandler(this.BtnSalva_Click);
            // 
            // BtnEsciSenzaSalvare
            // 
            this.BtnEsciSenzaSalvare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEsciSenzaSalvare.Location = new System.Drawing.Point(765, 8);
            this.BtnEsciSenzaSalvare.Name = "BtnEsciSenzaSalvare";
            this.BtnEsciSenzaSalvare.Size = new System.Drawing.Size(164, 39);
            this.BtnEsciSenzaSalvare.TabIndex = 1;
            this.BtnEsciSenzaSalvare.Text = "Esci senza salvare";
            this.BtnEsciSenzaSalvare.UseVisualStyleBackColor = true;
            this.BtnEsciSenzaSalvare.Click += new System.EventHandler(this.BtnEsciSenzaSalvare_Click);
            // 
            // FrmContatti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 705);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.dataGridViewContatti);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContatti";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione Contatti";
            this.Load += new System.EventHandler(this.FrmContatti_Load);
            this.Shown += new System.EventHandler(this.FrmContatti_Shown);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContatti)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceContatti)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTitoloForm;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CboTipo;
        private System.Windows.Forms.TextBox TxtContatto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridViewContatti;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button BtnNuovo;
        private System.Windows.Forms.Button BtnModifica;
        private System.Windows.Forms.Button BtnElimina;
        private System.Windows.Forms.TextBox TxtNote;
        private System.Windows.Forms.BindingSource bindingSourceContatti;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnSalva;
        private System.Windows.Forms.Button BtnEsciSenzaSalvare;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdContattoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoContatto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contatto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
    }
}