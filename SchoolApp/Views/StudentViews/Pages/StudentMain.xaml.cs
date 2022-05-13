using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using SchoolApp.Views.Accounts;
using SchoolApp.Views.Pages;
using SchoolApp.Views.Teacher;
using SchoolApp_EFCore.Repositories;
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

namespace SchoolApp.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for StudentMain.xaml
    /// </summary>
    public partial class StudentMain : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;
        private readonly List<StudentModel> _students;

        public StudentMain(MainWindow mainWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _repoPack = repoPack;

        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow, _repoPack);
        }

        private void Teacher_Nav_Button_Click(object sender, RoutedEventArgs e)
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

        private void StudDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            var updDelWindow = new Upd_Del_Window();
            updDelWindow.Content = new StudentDetails(updDelWindow, this);
            updDelWindow.Show();
        }

        private void StudSortOptions_Button_Click(object sender, RoutedEventArgs e)
        {
            var sortOptionsWindow = new SortOptionsWindow();
            sortOptionsWindow.Content = new StudSortOptions(sortOptionsWindow, this);
            sortOptionsWindow.Show();
        }

        private void PrevPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
