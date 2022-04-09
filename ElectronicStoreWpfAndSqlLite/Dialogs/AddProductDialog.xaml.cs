using ElectronicStoreWpfAndSqlLite.Enums;
using ElectronicStoreWpfAndSqlLite.Helpers;
using ElectronicStoreWpfAndSqlLite.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ElectronicStoreWpfAndSqlLite.Dialogs
{
    /// <summary>
    /// Logika interakcji dla klasy AddProductDialog.xaml
    /// </summary>
    public partial class AddProductDialog : Window
    {
        public Product product;
        public AddProductDialog()
        {
            InitializeComponent();
            product = new Product();
            AddProductGrid.DataContext = product;
            TypeOfProduct.ItemsSource = Enum.GetValues(typeof(TypeOfProductEnum)).Cast<TypeOfProductEnum>();
            TypeOfProduct.SelectedItem = Enum.GetValues(typeof(TypeOfProductEnum)).Cast<TypeOfProductEnum>().First();
        }
        public Product GetAddedProduct()
        {
            return product;
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
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
