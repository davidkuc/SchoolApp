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

namespace SchoolApp.Views.Accounts
{
    /// <summary>
    /// Interaction logic for AccountsMainPage.xaml
    /// </summary>
    public partial class AccountsMainPage : Page
    {
        private readonly MainWindow _mainWindow;
        public AccountsMainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
