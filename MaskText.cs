using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Parametrizador_PROCFIT
{
    class MaskText
    {
        public void MaskCnpj(TextBox txt)
        {
            txt.MaxLength = 18;

            if (txt.Text.Length == 2)
            {
                txt.Text = txt.Text + ".";
                txt.SelectionStart = txt.Text.Length + 1;
            }
            else if (txt.Text.Length == 6)
            {
                txt.Text = txt.Text + ".";
                txt.SelectionStart = txt.Text.Length + 1;
            }
            else if (txt.Text.Length == 10)
            {
                txt.Text = txt.Text + "/";
                txt.SelectionStart = txt.Text.Length + 1;
            }
            else if (txt.Text.Length == 15)
            {
                txt.Text = txt.Text + "-";
                txt.SelectionStart = txt.Text.Length + 1;
            }
        }
    }
}
