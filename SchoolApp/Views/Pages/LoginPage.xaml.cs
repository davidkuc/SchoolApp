using Microsoft.EntityFrameworkCore;
using SchoolApp_EFCore.Models;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;

        public string Username { get; set; }
        public string Password { get; set; }

        private Account Account { get; set; }

        public LoginPage(MainWindow mainWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _repoPack = repoPack;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            var validCreds = CheckCredentials();
            _mainWindow.Content = new MainMenuPage(_mainWindow, _repoPack);
        }

        private bool CheckCredentials()
        {
            var userName =  
        }
    }
}
