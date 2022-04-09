using ElectronicStoreWpfAndSqlLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ElectronicStoreWpfAndSqlLite.Helpers;
using System.Globalization;

namespace ElectronicStoreWpfAndSqlLite.Dialogs
{
    /// <summary>
    /// Logika interakcji dla klasy EditProductDialog.xaml
    /// </summary>
    public partial class EditProductDialog : Window
    {
        public Product product;
        public EditProductDialog(Product selectedProduct)
        {
            InitializeComponent();
            this.product = selectedProduct;
            UpdateProductGrid.DataContext = product;
        }

        public Product GetUpdatedProduct()
        {
            return product;
        }
        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            product.TypeOfProduct = TypeOfProduct.Text;
            product.Producer = Producer.Text;
            product.Model = Model.Text;
            product.YearOfProduction = int.Parse(YearOfProduction.Text);
            product.Quantity = int.Parse(Quantity.Text);
            product.Price = decimal.Parse(Price.Text, CultureInfo.InvariantCulture);
            DialogResult = true;
        }

        private void QuantityPreviewInput(object sender, TextCompositionEventArgs e)
        {
            TextInputHelpers.quantityHelper(e);
        }

        private void PricePreviewInput(object sender, TextCompositionEventArgs e)
        {
            TextInputHelpers.priceHelper(e);
        }

        private void YearOfProductionPreviewInput(object sender, TextCompositionEventArgs e)
        {
            TextInputHelpers.yearOfProductionHelper(e);
        }

        private void YearOfProductionHelper(object sender, KeyboardFocusChangedEventArgs e)
        {
            LostFocusHelpers.yearOfProductionHelper(YearOfProduction);
        }

        private void QuantityHelper(object sender, KeyboardFocusChangedEventArgs e)
        {
            LostFocusHelpers.quantityHelper(Quantity);
        }
    }
}
