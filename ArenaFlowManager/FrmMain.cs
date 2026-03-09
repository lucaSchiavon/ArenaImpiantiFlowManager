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
            InitializeComponent();
            // Associa evento click per mostrare il menu popup
            //TStripBtnNuovo.Click += TStripBtnNuovo_Click;
        }

        //private void TStripBtnNuovo_Click(object sender, EventArgs e)
        //{
        //    // Mostra il menu popup sotto il bottone
        //    var btn = TStripBtnNuovo;
        //    var location = new System.Drawing.Point(0, btn.Bounds.Height);
        //    contextMenuNuovo.Show(btn.Owner, btn.Bounds.Left, btn.Bounds.Bottom);
        //}

        private void TStripBtnNuovo_Click(object sender, EventArgs e) 
        {
            //var btn = TStripBtnNuovo;
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

        }

        private void ToolStripMainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
