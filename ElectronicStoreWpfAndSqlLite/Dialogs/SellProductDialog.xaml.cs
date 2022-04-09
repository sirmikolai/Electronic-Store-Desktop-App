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
using Xceed.Wpf.Toolkit;

namespace ElectronicStoreWpfAndSqlLite.Dialogs
{
    /// <summary>
    /// Logika interakcji dla klasy SellProductDialog.xaml
    /// </summary>
    public partial class SellProductDialog : Window
    {
        private ApplicationDbContext dbContext;
        private Product product;
        private Transaction transaction = new Transaction();
        public SellProductDialog(ApplicationDbContext dbContext, Product selectedProduct)
        {
            InitializeComponent();
            this.dbContext = dbContext;
            this.product = selectedProduct;
            SellProductGrid.DataContext = transaction;
            productNameLabel.Content = product.FullName;
            clientsComboBox.ItemsSource = dbContext.Clients.ToList();
            clientsComboBox.SelectedItem = dbContext.Clients.FirstOrDefault();
            clientsComboBox.DisplayMemberPath = "FullName";
        }

        public Product GetUpdatedProduct()
        {
            return product;
        }
        public Transaction GetAddedTransaction()
        {
            return transaction;
        }
        private void Sprzedaj_Click(object sender, RoutedEventArgs e)
        {
            transaction.ProductId = product.IdProduct;
            Client client = clientsComboBox.SelectedItem as Client;
            transaction.ClientId = client.IdClient;
            transaction.DateOfTransaction = DateTime.Parse(DateTimePicker.Text, new CultureInfo("pl-PL"));
            transaction.QuantityOfTransaction = int.Parse(quantityOfTransaction.Text);
            transaction.PriceOfTransaction = decimal.Parse(priceOfTransaction.Content.ToString());
            product.Quantity = product.Quantity - transaction.QuantityOfTransaction;
            DialogResult = true;
        }
        private void QuantityOfTransactionPreviewInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^\\d+$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void PriceTextChanged(object sender, RoutedEventArgs e)
        {
            if (quantityOfTransaction.Text.Length > 0)
            {
                int d = int.Parse(quantityOfTransaction.Text);
                if (d <= product.Quantity)
                {
                    priceOfTransaction.Content = (d * product.Price).ToString();
                }
                else
                {
                    quantityOfTransaction.Text = product.Quantity.ToString();
                    priceOfTransaction.Content = (product.Quantity * product.Price).ToString();
                }
                
            }
            else
            {
                quantityOfTransaction.Text = "0";
                priceOfTransaction.Content = (0 * product.Price).ToString();
            }
        }
    }
}
