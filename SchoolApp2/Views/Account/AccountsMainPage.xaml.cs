using SchoolApp_EFCore.Repositories;
using SchoolApp2.Views.Shared;
using EFAccount = SchoolApp_EFCore.Models.Account;
using SchoolApp2.Views.Shared.Pages;
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

namespace SchoolApp2.Views.Account
{
    /// <summary>
    /// Interaction logic for AccountsMainPage.xaml
    /// </summary>
    public partial class AccountsMainPage : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;
        private List<EFAccount> _accounts;
        private EFAccount _selectedAcc;

        public AccountsMainPage(MainWindow mainWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _mainWindow.DataContext = this;
            _repoPack = repoPack;
            _accounts = (List<EFAccount>?)_repoPack.AccRepo.GetAll();
        }

        public List<EFAccount> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
            }
        }

        public EFAccount SelectedAccount
        {
            get
            { return _selectedAcc; }
            set
            {
                _selectedAcc = value;
            }
        }

        private void AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var item = (EFAccount)listbox.SelectedItem;
            _selectedAcc = item;
        }

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow, _repoPack);
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow, _repoPack);
        }

        private void Teachers_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new TeacherMain(_mainWindow, _repoPack);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow, _repoPack);
        }

        private void AccDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            var detWindow = new Upd_Del_Window();
            detWindow.Content = new AccountDetails(detWindow, this, SelectedAccount, _repoPack);
            detWindow.Show();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new Upd_Del_Window();
            addWindow.Content = new AccountAdd(addWindow, this, _repoPack);
            addWindow.Show();
        }
    }
}
