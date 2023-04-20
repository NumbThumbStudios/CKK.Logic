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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void add_product_Button_Click(object sender, RoutedEventArgs e)
        {
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
