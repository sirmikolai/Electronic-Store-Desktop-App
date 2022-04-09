using ElectronicStoreWpfAndSqlLite.Dialogs;
using ElectronicStoreWpfAndSqlLite.Models;
using System.Linq;
using System.Windows;

namespace ElectronicStoreWpfAndSqlLite
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationDbContext dbContext;
        Product selectedProduct = new Product();
        Client selectedClient = new Client();
        public MainWindow(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetProducts();
            GetClients();
            GetTransactions();
        }

        private void GetProducts()
        {
            Products.ItemsSource = dbContext.Products.ToList();
        }

        private void GetClients()
        {
            Clients.ItemsSource = dbContext.Clients.ToList();
        }
        private void GetTransactions()
        {
            Transactions.ItemsSource = dbContext.Transactions.ToList();
        }

        private void DodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            var addProductDialog = new AddProductDialog();
            if (addProductDialog.ShowDialog() == true)
            {
                dbContext.Products.Add(addProductDialog.GetAddedProduct());
                dbContext.SaveChanges();
                GetProducts();
            }
        }

        private void EdytujProdukt_Click(object sender, RoutedEventArgs e)
        {
            selectedProduct = (sender as FrameworkElement).DataContext as Product;
            var editProductDialog = new EditProductDialog(selectedProduct);
            if (editProductDialog.ShowDialog() == true)
            {
                dbContext.Products.Update(editProductDialog.GetUpdatedProduct());
                dbContext.SaveChanges();
                GetProducts();
            }
        }

        private void UsunProdukt_Click(object sender, RoutedEventArgs e)
        {
            Product productToBeDeleted = (sender as FrameworkElement).DataContext as Product;
            dbContext.Products.Remove(productToBeDeleted);
            dbContext.SaveChanges();
            GetProducts();
            GetTransactions();
        }

        private void SprzedajProdukt_Click(object sender, RoutedEventArgs e)
        {
            selectedProduct = (sender as FrameworkElement).DataContext as Product;
            var sellProductDialog = new SellProductDialog(dbContext, selectedProduct);
            if (sellProductDialog.ShowDialog() == true)
            {
                dbContext.Products.Update(sellProductDialog.GetUpdatedProduct());
                dbContext.Transactions.Add(sellProductDialog.GetAddedTransaction());
                dbContext.SaveChanges();
                GetProducts();
                GetTransactions();
            }
        }

        private void DodajKlienta_Click(object sender, RoutedEventArgs e)
        {
            var addClientDialog = new AddClientDialog();
            if (addClientDialog.ShowDialog() == true)
            {
                dbContext.Clients.Add(addClientDialog.GetAddedClient());
                dbContext.SaveChanges();
                GetClients();
            }
        }

        private void UsunKlienta_Click(object sender, RoutedEventArgs e)
        {
            Client clientToBeDeleted = (sender as FrameworkElement).DataContext as Client;
            dbContext.Clients.Remove(clientToBeDeleted);
            dbContext.SaveChanges();
            GetClients();
            GetTransactions();
        }

        private void EdytujKlienta_Click(object sender, RoutedEventArgs e)
        {
            selectedClient = (sender as FrameworkElement).DataContext as Client;
            var editClientDialog = new EditClientDialog(selectedClient);
            if (editClientDialog.ShowDialog() == true)
            {
                dbContext.Clients.Update(editClientDialog.GetUpdatedClient());
                dbContext.SaveChanges();
                GetClients();
            }
        }
    }
}
