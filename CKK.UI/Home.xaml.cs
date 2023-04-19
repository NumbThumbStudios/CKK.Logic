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
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private IStore store;

        public Home()
        {
            store = new Store();
            InitializeComponent();
        }

        private void add_product_Button_Click(object sender, RoutedEventArgs e)
        {
            Page p = new Page();
            
            //Debug Code...
            /*int child_count = main_content_area_Grid.Children.Count;
            main_content_area_Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            TextBlock tb = new TextBlock();
            tb.Text = "Hello!";
            tb.SetValue(Grid.RowProperty, child_count);
            tb.SetValue(Grid.ColumnProperty, 0);

            main_content_area_Grid.Children.Add(tb);*/
        }
    }
}
