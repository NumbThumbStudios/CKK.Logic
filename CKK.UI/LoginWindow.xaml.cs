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

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }




        // ----    LOGIN BUTTON CLICKED    ---- //
        private void login_Button_Click(object sender, RoutedEventArgs e)
        {
            // Validation done here...

            // Create Main App Window...
            AppWindow app = new AppWindow();
            Application.Current.MainWindow = app;
            app.Show();

            app.Content = new CKK.UI.Pages.HomePage();

            // Create home screen upon proper validation...
            /*Home home = new Home();
            Application.Current.MainWindow = home;
            home.Show();*/

            // Close login screen window...
            this.Close();
        }
    }
}
