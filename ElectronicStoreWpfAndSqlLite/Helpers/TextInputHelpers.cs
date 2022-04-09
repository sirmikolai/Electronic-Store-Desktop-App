using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ElectronicStoreWpfAndSqlLite.Helpers
{
    public static class TextInputHelpers
    {
        public static void yearOfProductionHelper(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^\\d+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        public static void quantityHelper(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^\\d+$");
            e.Handled = !regex.IsMatch(e.Text);
        }
        public static void priceHelper(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^\\d+\\.?\\d*]");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static void nameHelper(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^\\d+$");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
