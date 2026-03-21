using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaFlowManager.Managers
{
    public class FormValidatorManager
    {
        public ToolTip RequiredToolTip = new ToolTip();
        public bool ValidateRequiredFields(Control parent)
        {
            bool isValid = true;

            foreach (Control c in parent.Controls)
            {
                // TEXTBOX
                if (c is TextBox tb && (string)tb.Tag == "required")
                {
                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        MarkInvalid(tb);
                        isValid = false;
                    }
                    else
                    {
                        ClearInvalid(tb);
                    }
                }

                // COMBOBOX
                if (c is ComboBox cb && (string)cb.Tag == "required")
                {
                    //if (cb.SelectedIndex < 0 || string.IsNullOrWhiteSpace(cb.Text))
                    //{
                    if (cb.SelectedValue.ToString() == "-")
                    {
                        MarkInvalid(cb);
                        isValid = false;
                    }
                    else
                    {
                        ClearInvalid(cb);
                    }
                }

                // Ricorsione per pannelli, groupbox, tabpage, ecc.
                if (c.HasChildren)
                {
                    if (!ValidateRequiredFields(c))
                        isValid = false;
                }
            }

            return isValid;
        }
        private void MarkInvalid(Control c)
        {
            c.BackColor = Color.MistyRose;
            c.ForeColor = Color.DarkRed;

            // Bordo rosso (solo se il controllo lo supporta)
            if (c is TextBox || c is ComboBox)
            {
                c.Padding = new Padding(1);
                c.BackColor = Color.MistyRose;
            }

            RequiredToolTip.SetToolTip(c, "Campo obbligatorio");
        }

        private void ClearInvalid(Control c)
        {
            c.BackColor = SystemColors.Window;
            c.ForeColor = SystemColors.ControlText;
            c.Padding = new Padding(0);

            RequiredToolTip.SetToolTip(c, "");
        }

        public bool IsCodiceFiscaleValid(string cf)
        {
            if (string.IsNullOrWhiteSpace(cf))
                return false;

            cf = cf.ToUpper().Trim();

            // Lunghezza
            if (cf.Length != 16)
                return false;

            // Regex formale
            var regex = new System.Text.RegularExpressions.Regex(
                @"^[A-Z]{6}[0-9]{2}[A-Z][0-9]{2}[A-Z][0-9]{3}[A-Z]$"
            );

            //if (!regex.IsMatch(cf))
            //    return false;

            //if (!regex.IsMatch(cf))
                return regex.IsMatch(cf);

            //// Controllo carattere di controllo
            //const string evenMap = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //const string oddMap = "BAKPLCQDREVOSFTGUHMINJWZYX";

            //int sum = 0;

            //for (int i = 0; i < 15; i++)
            //{
            //    char c = cf[i];
            //    int value;

            //    if (char.IsDigit(c))
            //        value = c - '0';
            //    else
            //        value = c - 'A';

            //    if ((i % 2) == 0) // posizione dispari (0-based)
            //        sum += oddMap[value] - 'A';
            //    else
            //        sum += evenMap[value] - 'A';
            //}

            //char check = (char)('A' + (sum % 26));
            //return check == cf[15];
        }

        public bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim();

            var regex = new System.Text.RegularExpressions.Regex(
                @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase
            );

            return regex.IsMatch(email);
        }

        public bool IsPartitaIvaValidWithChecksum(string piva)
        {
            if (string.IsNullOrWhiteSpace(piva))
                return false;

            piva = piva.Trim();

            // Deve essere lunga 11 cifre
            if (piva.Length != 11 || !piva.All(char.IsDigit))
                return false;

            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                int n = piva[i] - '0';

                if ((i % 2) == 0) // posizioni pari (0-based)
                {
                    sum += n;
                }
                else // posizioni dispari
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                    sum += n;
                }
            }

            int checkDigit = (10 - (sum % 10)) % 10;

            return checkDigit == (piva[10] - '0');
        }

        public bool IsPartitaIvaValidWithRegex(string piva)
        {
            if (string.IsNullOrWhiteSpace(piva))
                return false;

            piva = piva.Trim();

            // Regex: esattamente 11 cifre
            var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]{11}$");

            return regex.IsMatch(piva);
        }

        public bool IsPartitaIvaValid(string piva)
        {
            if (string.IsNullOrWhiteSpace(piva))
                return false;

            piva = piva.Trim();

            // Regex: esattamente 11 cifre
            var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]{11}$");
            if (!regex.IsMatch(piva))
                return false;

            // Checksum ufficiale
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                int n = piva[i] - '0';

                if ((i % 2) == 0) // posizioni pari (0-based)
                {
                    sum += n;
                }
                else // posizioni dispari
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                    sum += n;
                }
            }

            int checkDigit = (10 - (sum % 10)) % 10;

            return checkDigit == (piva[10] - '0');
        }





    }
}
