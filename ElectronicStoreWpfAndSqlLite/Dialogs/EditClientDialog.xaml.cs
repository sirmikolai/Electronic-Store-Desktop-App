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
    public partial class EditClientDialog : Window
    {
        Client client;
        public EditClientDialog(Client selectedClient)
        {
            InitializeComponent();
            client = selectedClient;
            UpdateClientGrid.DataContext = client;
        }
        public Client GetUpdatedClient()
        {
            return client;
        }
        private void Zapisz_Click(object sender, RoutedEventArgs e)
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
