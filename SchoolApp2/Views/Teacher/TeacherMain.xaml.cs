using SchoolApp_EFCore.Repositories;
using SchoolApp2.Views.Account;
using SchoolApp2.Views.Shared;
using SchoolApp2.Views.Shared.Pages;
using SchoolApp2.Views.Student;
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

namespace SchoolApp2.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherMain.xaml
    /// </summary>
    public partial class TeacherMain : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;

        public TeacherMain(MainWindow window, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = window;
            _repoPack = repoPack;

        }

        private void TeacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow, _repoPack);
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow, _repoPack);
        }

        private void Accounts_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new AccountsMainPage(_mainWindow, _repoPack);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow, _repoPack);
        }


        private void TeacherDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            var updDelWindow = new Upd_Del_Window();
            updDelWindow.Content = new TeacherDetails(updDelWindow, this);
            updDelWindow.Show();
        }
    }
}
