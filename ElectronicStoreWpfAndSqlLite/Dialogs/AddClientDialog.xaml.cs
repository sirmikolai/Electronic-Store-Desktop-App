using ElectronicStoreWpfAndSqlLite.Helpers;
using ElectronicStoreWpfAndSqlLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logika interakcji dla klasy AddClientDialog.xaml
    /// </summary>
    public partial class AddClientDialog : Window
    {
        Client client;
        public AddClientDialog()
        {
            InitializeComponent();
            client = new Client();
            AddClientGrid.DataContext = client;
        }
        public Client GetAddedClient()
        {
            return client;
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            client.FirstName = FirstName.Text;
            client.LastName = LastName.Text;
            client.Address = Address.Text;
            DialogResult = true;
        }

        private void NameHelper(object sender, TextCompositionEventArgs e)
        {
            TextInputHelpers.nameHelper(e);
        }
    }
}
