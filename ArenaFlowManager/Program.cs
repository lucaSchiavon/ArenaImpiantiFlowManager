using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaFlowManager
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmLogin());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostra il login in modo modale
            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK)
                {
                    // Login fallito o annullato → esci dall'app
                    return;
                }
            }

            // Avvia la form principale
            Application.Run(new FrmMain());
        }
    }
}
