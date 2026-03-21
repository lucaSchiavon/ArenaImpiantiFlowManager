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
    }
}
