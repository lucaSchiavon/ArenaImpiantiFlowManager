using ArenaFlowManager.UserControls;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            //rende lo scrolling e le transizioni della UI più fluide
            this.DoubleBuffered = true;
            InitializeComponent();
            
   
        }

        private void TStripBtnNuovo_Click(object sender, EventArgs e) 
        {
            //istanzia e posiziona il menu popup sotto il bottone nuovo della barra degli strumenti

            ToolStripButton btn = sender as ToolStripButton;

            // Converte il punto in coordinate schermo
            var screenPoint = btn.Owner.PointToScreen(new Point(btn.Bounds.Left, btn.Bounds.Bottom));

            // Mostra il menu in quel punto
            contextMenuNuovo.Show(screenPoint);

            //var location = new System.Drawing.Point(0, btn.Bounds.Height);
            //contextMenuNuovo.Show(btn.Owner, btn.Bounds.Left, btn.Bounds.Bottom);
        }

        private void nuovoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormModificaCliente = new FrmModificaClente(0);
            FormModificaCliente.ShowDialog();
        }

    
        private void TStripBtnClienti_Click(object sender, EventArgs e)
        {
            UcClienti moduloClienti = new UcClienti();
            ApriModulo(moduloClienti);
            LblFormName.Text = moduloClienti.FormName;        
        }


        #region "routines private"

            private void ApriModulo(UserControl modulo)
            {

                // Trova l'eventuale UserControl già presente e rimuovilo
                var VecchioModulo = PnlMainContent.Controls.OfType<UserControl>().FirstOrDefault();
                if (VecchioModulo != null)
                {
                    PnlMainContent.Controls.Remove(VecchioModulo);
                    VecchioModulo.Dispose();
                }


                modulo.Dock = DockStyle.Fill;
                PnlMainContent.SuspendLayout();
                PnlMainContent.Controls.Add(modulo);
                //modulo.SendToBack();
                PnlMainContent.ResumeLayout();
            }

        #endregion


    }
}
