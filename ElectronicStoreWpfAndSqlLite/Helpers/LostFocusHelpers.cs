using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ElectronicStoreWpfAndSqlLite.Helpers
{
    public static class LostFocusHelpers
    {
        public static void quantityHelper(TextBox textBox)
        {
            if (textBox.Text.Length <= 0)
            {
                textBox.Text = "0";
            }
        }

        public static void yearOfProductionHelper(TextBox textBox)
        {
            if (textBox.Text.Length > 0)
            {
                int d = int.Parse(textBox.Text);
                if (d < 1990 || d > DateTime.Now.Year + 2)
                {
                    textBox.Text = "1990";
                }
            }
            else
            {
                textBox.Text = "0";
            }
        }
    }
}
