using SchoolApp2.Views.Shared;
using EFAccount = SchoolApp_EFCore.Models.Account;
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
using SchoolApp_EFCore.Repositories;

namespace SchoolApp2.Views.Account
{
    /// <summary>
    /// Interaction logic for AccountDetails.xaml
    /// </summary>
    public partial class AccountDetails : Page
    {
        private Upd_Del_Window _updDelWindow;
        private readonly AccountsMainPage _accMain;
        private readonly EFAccount _acc;
        private readonly RepoPack _repoPack;
        private string _username;
        private string _password;

        public AccountDetails(Upd_Del_Window updDelWindow, AccountsMainPage accMain, EFAccount acc, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _accMain = accMain;
            _acc = acc;
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _updDelWindow.Show();
        }

        public string SName => _acc.Name;

        public string Surname => _acc.Surname;

        public bool HasAdminPrivileges => _acc.HasAdminPrivileges;

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

        private void Password_Show_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Password = _acc.Password;
        }

        private void Username_Show_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Username = _acc.Username;
        }


        private void Username_Show_Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Username = string.Empty;
        }

        private void Password_Show_Checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Password = string.Empty;
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            var updatedAcc = _accMain.Accounts.Find(x => x.ID == _acc.ID);
            updatedAcc = _acc;
            _accMain.AccountsListBox.Items.Refresh();
            _updDelWindow?.Close();
        }

        private void UpdateAcc_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new AccountUpdate(_updDelWindow, this);
        }

        private void DeleteAcc_Button_Click(object sender, RoutedEventArgs e)
        {
            var removedAcc = _accMain.Accounts.Remove(_acc);
            _accMain.AccountListBox.Items.Refresh();
            _repoPack.AccRepo.Remove(_acc);
            _repoPack.AccRepo.Save();
            _updDelWindow.Close();
        }
    }
}
