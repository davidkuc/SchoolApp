using SchoolApp_EFCore.Repositories;
using SchoolApp2.Views.Account;
using SchoolApp2.Views.Student;
using SchoolApp2.Views.Teacher;
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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;

        public MainMenuPage(MainWindow mainWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = this;
            _repoPack = repoPack;
            if (!LoginPage.AccountHolder.HasAdminPrivileges)
            {
                Accounts_Nav_Button.Visibility = Visibility.Hidden;
            }
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow, _repoPack);
        }

        private void Teachers_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new TeacherMain(_mainWindow, _repoPack);
        }

        private void Accounts_Nav_Button_Click(object sender, RoutedEventArgs e)
        {         
            _mainWindow.Content = new AccountsMainPage(_mainWindow, _repoPack);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow, _repoPack);
        }
    }
}
