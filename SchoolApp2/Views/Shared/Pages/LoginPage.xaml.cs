using SchoolApp_EFCore.Repositories;
using SchoolApp2.Models;
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

namespace SchoolApp2.Views.Shared.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public static AccountHolder AccountHolder;

        public LoginPage(MainWindow mainWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _repoPack = repoPack;
            DataContext = this;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var accs = _repoPack.AccRepo.GetAll();
                var account = _repoPack.AccRepo.FindAccount(Username, Password);
                if (account == null)
                {
                    MessageBox.Show("Invalid credentials - account not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var accountModel = new AccountModel() { ID = account.ID, HasAdminPrivileges = account.HasAdminPrivileges };
                AccountHolder = new AccountHolder(accountModel);
                _mainWindow.Content = new MainMenuPage(_mainWindow, _repoPack);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid credentials - account not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }
    }
}
