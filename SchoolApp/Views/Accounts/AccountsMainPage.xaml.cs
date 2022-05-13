using SchoolApp.Views.Pages;
using SchoolApp.Views.Student;
using SchoolApp.Views.Teacher;
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

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow);
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow);
        }

        private void Teachers_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new TeacherMain(_mainWindow);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow);
        }

        private void SortOptions_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new AccountSortOptions(_mainWindow);
        }

        private void PrevPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AccDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new AccountDetails(_mainWindow, this);
        }
    }
}
