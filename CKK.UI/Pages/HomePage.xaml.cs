using CKK.Logic.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CKK.UI.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            //AppWindow.store.Load();
            //LoadStoreItems();
        }

        private void add_product_Button_Click(object sender, RoutedEventArgs e)
        {
            AddProductPage addProductPage = new AddProductPage();
            Application.Current.MainWindow.Content = addProductPage;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppWindow.store.Load();
            searchbar_TextBox.Text = AppWindow.store.search_terms.ToString();
            LoadStoreItems();
        }

        private void LoadStoreItems()
        {

            main_content_area_Grid.Children.Clear();
            main_content_area_Grid.RowDefinitions.Clear();

            if(AppWindow.store.GetStoreItems().Count == 0)
            {
                TextBlock tb_empty = new TextBlock();
                tb_empty.Text = "No Products Added";
                tb_empty.FontWeight = FontWeights.SemiBold;
                tb_empty.SetValue(Grid.RowProperty, 0);
                tb_empty.SetValue(Grid.ColumnProperty, 0);
                tb_empty.SetValue(Grid.ColumnSpanProperty, 6);
                tb_empty.Margin = new Thickness(10);
                tb_empty.HorizontalAlignment = HorizontalAlignment.Center;
                tb_empty.VerticalAlignment = VerticalAlignment.Center;
                main_content_area_Grid.Children.Add(tb_empty);
                return;
            }

            List<StoreItem> list = AppWindow.store.GetStoreItems();

            if(searchbar_TextBox.Text.Length > 0)
            {
                string selected_item = ((ComboBoxItem)SearchBy_ComboBox.SelectedItem).Content.ToString();
                switch (selected_item)
                {
                    case "Search by Name":
                        try
                        {
                            string search_by_name = searchbar_TextBox.Text;

                            list =
                            (from item in AppWindow.store.GetStoreItems()
                             orderby item.GetProduct().GetId()
                             where item.GetProduct().GetName().ToString().ToLower().Contains(search_by_name.ToString().ToLower())
                             select item).ToList();
                        }
                        catch { }
                        break;

                    case "Search by Quantity":
                        try
                        {
                            int search_by_quantity = int.Parse(searchbar_TextBox.Text);

                            list =
                            (from item in AppWindow.store.GetStoreItems()
                             orderby item.GetProduct().GetId()
                             where item.Quantity.ToString().Contains(searchbar_TextBox.Text)
                             select item).ToList();
                        }
                        catch { }
                        break;

                    case "Search by Price":
                        try
                        {
                            decimal search_by_price = decimal.Parse(searchbar_TextBox.Text);

                            list =
                            (from item in AppWindow.store.GetStoreItems()
                             orderby item.GetProduct().GetId()
                             where item.GetProduct().GetPrice().ToString().Contains(searchbar_TextBox.Text)
                             select item).ToList();
                        }
                        catch { }
                        break;
                }
            }

            int count = 0;

            foreach(var item in list)
            {
                int child_count = main_content_area_Grid.RowDefinitions.Count;
                main_content_area_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

                Thickness margin = new Thickness(10, 5, 10, 5);
                Color even = Color.FromArgb(40, 0, 0, 0);
                Color odd = Color.FromArgb(40, 50, 50, 50);

                // Rectangle background...
                Rectangle rect = new Rectangle();
                rect.SetValue(Grid.RowProperty, child_count);
                rect.SetValue(Grid.ColumnProperty, 0);
                rect.SetValue(Grid.ColumnSpanProperty, 6);
                if (count % 2 == 0) { rect.Fill = new SolidColorBrush(even); } else { rect.Fill = new SolidColorBrush(odd); }
                count++;
                main_content_area_Grid.Children.Add(rect);

                // Set product ID...
                TextBlock tb_id = new TextBlock();
                tb_id.Text = item.GetProduct().GetId().ToString();
                tb_id.SetValue(Grid.RowProperty, child_count);
                tb_id.SetValue(Grid.ColumnProperty, 0);
                tb_id.Margin = margin;
                main_content_area_Grid.Children.Add(tb_id);

                // Set product Name...
                TextBlock tb_name = new TextBlock();
                tb_name.Text = item.GetProduct().Name;
                tb_name.SetValue(Grid.RowProperty, child_count);
                tb_name.SetValue(Grid.ColumnProperty, 1);
                tb_name.Margin = margin;
                main_content_area_Grid.Children.Add(tb_name);

                // Set quantity...
                TextBlock tb_quantity = new TextBlock();
                tb_quantity.Text = $"{item.GetQuantity():n0}";
                tb_quantity.SetValue(Grid.RowProperty, child_count);
                tb_quantity.SetValue(Grid.ColumnProperty, 2);
                tb_quantity.Margin = margin;
                main_content_area_Grid.Children.Add(tb_quantity);

                // Set Price...
                TextBlock tb_price = new TextBlock();
                tb_price.Text = $"{item.GetProduct().GetPrice():C}";
                tb_price.SetValue(Grid.RowProperty, child_count);
                tb_price.SetValue(Grid.ColumnProperty, 3);
                tb_price.Margin = margin;
                main_content_area_Grid.Children.Add(tb_price);

                // Remove button...
                Button tb_remove = new Button();
                tb_remove.Content = "Remove";
                tb_remove.SetValue(Grid.RowProperty, child_count);
                tb_remove.SetValue(Grid.ColumnProperty, 4);
                tb_remove.Background = new SolidColorBrush(Color.FromRgb(255,128,128));
                tb_remove.BorderBrush = new SolidColorBrush(Color.FromRgb(128, 0, 0));
                tb_remove.Foreground = new SolidColorBrush(Colors.White);
                tb_remove.FontWeight = FontWeights.SemiBold;
                tb_remove.MaxWidth = 100;
                tb_remove.Margin = margin;
                tb_remove.Uid = item.GetProduct().GetId().ToString();
                string bt_name = item.GetProduct().Name;
                bt_name = bt_name.Replace(" ", "_");
                tb_remove.Name = bt_name;
                tb_remove.Click += new RoutedEventHandler(RemoveItem);
                main_content_area_Grid.Children.Add(tb_remove);

                // Edit button...
                Button tb_edit = new Button();
                tb_edit.Content = "Edit";
                tb_edit.SetValue(Grid.RowProperty, child_count);
                tb_edit.SetValue(Grid.ColumnProperty, 5);
                tb_edit.Background = new SolidColorBrush(Color.FromRgb(80, 180, 80));
                tb_edit.BorderBrush = new SolidColorBrush(Color.FromRgb(43, 41, 41));
                tb_edit.Foreground = new SolidColorBrush(Colors.White);
                tb_edit.FontWeight = FontWeights.SemiBold;
                tb_edit.MaxWidth = 100;
                tb_edit.Margin = margin;
                main_content_area_Grid.Children.Add(tb_edit);
            }
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            int uid = int.Parse(btn.Uid);
            string name = btn.Name;
            name = name.Replace("_", " ");

            MessageBoxResult result = MessageBox.Show($"Are you sure you want to remove '{name}' from the store inventory system?\nThis action cannot be undone.", "Remove Item", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes) 
            {
                AppWindow.store.DeleteStoreItem(uid);
                LoadStoreItems();

                AppWindow.store.Save();
            }
        }

        private void searchbar_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AppWindow.store.search_terms = searchbar_TextBox.Text;
            LoadStoreItems();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadStoreItems();
        }

        private void searchbar_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                LoadStoreItems();
            }
        }
    }
}
