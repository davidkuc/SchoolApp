using Microsoft.EntityFrameworkCore;
using SchoolApp.Views.Accounts;
using SchoolApp.Views.Student;
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

namespace SchoolApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly AccRepository _accRepo;
        private readonly TeaRepository _teaRepo;
       private readonly StudRepository _studRepo;

        public MainMenuPage(MainWindow mainWindow,
             AccRepository accRepo,
            TeaRepository teaRepo,
            StudRepository studRepo
)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _accRepo = accRepo;
            _teaRepo = teaRepo;
            _studRepo = studRepo;
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow, _studRepo);
        }

        private void Teachers_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new TeacherMain(_mainWindow, _TeaRepo);
        }

        private void Accounts_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new AccountsMainPage(_mainWindow, _AccRepo);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow, _accRepo, _teaRepo, _studRepo);
        }
    }
}
