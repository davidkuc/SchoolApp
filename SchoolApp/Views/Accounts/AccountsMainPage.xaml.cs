using Microsoft.EntityFrameworkCore;
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
        private readonly DbContext _dbContext;

        public AccountsMainPage(MainWindow mainWindow, DbContext dbContext)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _dbContext = dbContext;
        }

        private void AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow, _dbContext);
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow, _dbContext);
        }

        private void Teachers_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new TeacherMain(_mainWindow, _dbContext);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow, _dbContext);
        }

        private void SortOptions_Button_Click(object sender, RoutedEventArgs e)
        {
            var sortOptions = new SortOptionsWindow();
            sortOptions.Content = new AccountSortOptions(sortOptions, this);
            sortOptions.Show();
        }

        private void PrevPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AccDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            var detWindow = new Upd_Del_Window();
            detWindow.Content = new AccountDetails(detWindow, this);
            detWindow.Show();
        }
    }
}
