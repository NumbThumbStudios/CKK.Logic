using CKK.Logic.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CKK.UI.Pages
{
    /// <summary>
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
        }

        private void cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            Application.Current.MainWindow.Content = homePage;
        }

        private void save_Button_Click(object sender, RoutedEventArgs e)
        {
            Product prod = new Product();
            prod.Name = name_TextBox.Text;
            prod.Price = decimal.Parse(price_TextBox.Text);
            int quantity = int.Parse(quantity_TextBox.Text);

            AppWindow.store.AddStoreItem(prod, quantity);

            // If success...
            HomePage homePage = new HomePage();
            Application.Current.MainWindow.Content = homePage;
        }

        private void id_TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            id_TextBox.Text = (AppWindow.store.GetStoreItems().Count + 1).ToString();
            id_TextBox.IsEnabled = false;
        }
    }
}
