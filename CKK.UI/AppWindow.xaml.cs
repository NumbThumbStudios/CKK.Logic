using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistance.Models;
using CKK.DB;
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
using CKK.DB.UOW;
using CKK.DB.Interfaces;
using CKK.DB.Repository;

namespace CKK.UI
{
    public partial class AppWindow : Window
    {
        // ----    INSTANCE VARIALBES    ---- //
        public static UnitOfWork uow = new UnitOfWork(new DatabaseConnectionFactory());
        




        // ----    CONSTRUCTOR    ---- //
        public AppWindow()
        {
            InitializeComponent();
        }
    }
}
